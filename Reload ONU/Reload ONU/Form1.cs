using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using System.Media;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Reload_ONU
{
    public partial class Form1 : Form
    {
        //Caminho do arquivo xls
        private string caminhoArquivo;
        //vetor de ips
        private string[] ips;
        //Variável do driver
        EdgeDriver driver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Desabilita balão de texto
            btnArquivo.AutoToolTip = false;
            barraProgresso.Minimum = 0;
            //Desabilita o console
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if ((onu_101.CheckState != CheckState.Checked) && (onu_1100.CheckState != CheckState.Checked))
            {
                MessageBox.Show("Nenhum modelo selecionado");
            }
            else
            {
                Executar();
            }
        }

        private void btnAbrirEExecutar_Click(object sender, EventArgs e)
        {
            BuscarArquivo();
        }

        private void LeitorExcell(string caminho)
        {
            FileInfo existingFile = new FileInfo(caminho);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int totalLinha = worksheet.Dimension.End.Row;

                ips = new string[totalLinha - 3];
                barraProgresso.Maximum = ips.Length;

                try
                {
                    int contatorEndVetor = 0;
                    for (int i = 3; i < totalLinha; i++)
                    {
                        ips[contatorEndVetor] = worksheet.GetValue(i, 8).ToString();
                        contatorEndVetor++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void BuscarArquivo()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione a Planilha do MK";
            ofd.Filter = "Arquivo XLSX (.xlsx)|*.xlsx";
            ofd.Multiselect = false;

            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:

                    caminhoArquivo = ofd.FileName;
                    LeitorExcell(caminhoArquivo);
                    backgroundWorker.RunWorkerAsync();

                    break;

                case DialogResult.Cancel:

                    MessageBox.Show("Nenhuma ação será realizada", "Operação cancelada");

                    break;
            }
        }
        private void autoReinicioONU(string ip)
        {
            try
            {
                EdgeDriverService driverService = EdgeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                driver = new EdgeDriver(driverService, new EdgeOptions());
                driver.Manage().Window.Minimize();
                driver.Navigate().GoToUrl("http://" + ip);

                if (driver.Title.Contains("Parks S/A") && (onu_1100.CheckState == CheckState.Checked))
                {
                    // ONU 1100
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Id("id_userloggin")).SendKeys("admin");
                    driver.FindElement(By.Id("id_userpass")).SendKeys("parks");
                    driver.FindElement(By.Id("Entrar")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Id("link_class_5")).Click();
                    driver.FindElement(By.Id("link_class_sub_5_2")).Click();
                    driver.ExecuteScript("window.location='/port/reboot.cgi'");
                    driver.Close();
                }
                else if (driver.Title.Contains("Parks S/A") && (onu_1100.CheckState == CheckState.Unchecked))
                {
                    driver.Close();
                }

                else if (driver.Title.Contains("FiberLink101") && (onu_101.CheckState == CheckState.Checked))
                {
                    // ONU 101
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Name("Username")).SendKeys("admin");
                    driver.FindElement(By.Name("Password")).SendKeys("parks");
                    driver.FindElement(By.Id("LoginId")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.SwitchTo().Frame(1);
                    driver.FindElement(By.Id("mmManager")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Id("smSysMgr")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Id("Submit1")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
                    driver.FindElement(By.Id("msgconfirmb")).Click();
                    driver.Close();
                }
                else if (driver.Title.Contains("FiberLink101") && (onu_101.CheckState == CheckState.Unchecked))
                {
                    driver.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Executar()
        {
            Ping ping = new Ping();
            try
            {
                foreach (string ip in ips)
                {
                    //remove espaço da string
                    PingReply c = ping.Send(ip.Replace(" ", ""));
                    if (c.Status == IPStatus.Success)
                    {
                        /*TODO
                        * IMPLEMENTAR STATUS DO PROCESSO DE PING, EX: QUANTIDADE TOTAL, IP ATUAL, POSIÇÃO ATUAL E UMA BARRA DE PROGRESSO
                        */
                           
                        autoReinicioONU(ip);
                        barraProgresso.Value++;
                    }
                    else
                    {
                        MessageBox.Show("IP inacessível ", ip, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        barraProgresso.Value++;
                    }
                }
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Operação finalizada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                barraProgresso.Value = 0;
            }
            catch (Exception e)
            {
               MessageBox.Show(e.ToString());
            }
        }

        private void AntesDeFecharForm(object sender, FormClosingEventArgs e)
        {
            if ((driver != null) && (backgroundWorker.IsBusy))
            {
                driver.Quit();
                driver.Dispose();
                backgroundWorker.CancelAsync();
                backgroundWorker.Dispose();
            }
        }
    }
}


