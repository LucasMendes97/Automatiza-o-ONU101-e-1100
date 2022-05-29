namespace Reload_ONU
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnArquivo = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAbrirEExecutar = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.barraProgresso = new System.Windows.Forms.ToolStripProgressBar();
            this.onu_101 = new System.Windows.Forms.CheckBox();
            this.onu_1100 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnArquivo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(527, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnArquivo
            // 
            this.btnArquivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirEExecutar});
            this.btnArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnArquivo.Image")));
            this.btnArquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(62, 22);
            this.btnArquivo.Text = "Arquivo";
            // 
            // btnAbrirEExecutar
            // 
            this.btnAbrirEExecutar.Name = "btnAbrirEExecutar";
            this.btnAbrirEExecutar.Size = new System.Drawing.Size(157, 22);
            this.btnAbrirEExecutar.Text = "Abrir e executar";
            this.btnAbrirEExecutar.Click += new System.EventHandler(this.btnAbrirEExecutar_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barraProgresso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 299);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(527, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // barraProgresso
            // 
            this.barraProgresso.Name = "barraProgresso";
            this.barraProgresso.Size = new System.Drawing.Size(100, 16);
            // 
            // onu_101
            // 
            this.onu_101.AutoSize = true;
            this.onu_101.Location = new System.Drawing.Point(6, 42);
            this.onu_101.Name = "onu_101";
            this.onu_101.Size = new System.Drawing.Size(71, 17);
            this.onu_101.TabIndex = 2;
            this.onu_101.Text = "ONU 101";
            this.onu_101.UseVisualStyleBackColor = true;
            // 
            // onu_1100
            // 
            this.onu_1100.AutoSize = true;
            this.onu_1100.Location = new System.Drawing.Point(6, 19);
            this.onu_1100.Name = "onu_1100";
            this.onu_1100.Size = new System.Drawing.Size(77, 17);
            this.onu_1100.TabIndex = 3;
            this.onu_1100.Text = "ONU 1100";
            this.onu_1100.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onu_1100);
            this.groupBox1.Controls.Add(this.onu_101);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habilitar reinicio para";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Reload ONU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AntesDeFecharForm);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnArquivo;
        private System.Windows.Forms.ToolStripMenuItem btnAbrirEExecutar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar barraProgresso;
        private System.Windows.Forms.CheckBox onu_101;
        private System.Windows.Forms.CheckBox onu_1100;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

