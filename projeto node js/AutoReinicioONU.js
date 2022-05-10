/**
 * Scritp para reiniciar ONU 1100 e 101
 * Autor: Lucas M. Alves
 * Data: 03/05/2022
 * Dependências: framework Selenium
 */

 var argumentoIP = process.argv

const { Builder, By } = require('selenium-webdriver');

async function autoReinicioONU(ip) {
    try {
        let driver = await new Builder().forBrowser('MicrosoftEdge').build();

        await driver.get('http://'+ip);

        await driver.manage().window().maximize();

        if (await driver.getTitle() === 'Parks S/A') {
            // ONU 1100
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.findElement(By.id('id_userloggin')).sendKeys('admin');
            await driver.findElement(By.id('id_userpass')).sendKeys('parks');
            await driver.findElement(By.id('Entrar')).click();
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.findElement(By.id('link_class_5')).click();
            await driver.findElement(By.id('link_class_sub_5_2')).click();
            // await driver.executeScript("window.location='/port/reboot.cgi'");
        } else {
            // ONU 101
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.findElement(By.name('Username')).sendKeys('admin');
            await driver.findElement(By.name('Password')).sendKeys('parks');
            await driver.findElement(By.id('LoginId')).click();
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.switchTo().frame(1);
            await driver.findElement(By.id('mmManager')).click();
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.findElement(By.id('smSysMgr')).click();
            await driver.manage().setTimeouts({ implicit: 10000 });
            await driver.findElement(By.id('Submit1')).click();
            await driver.manage().setTimeouts({ implicit: 10000 })
            //  await driver.findElement(By.id("msgconfirmb")).click();
        }
        await driver.quit();

    } catch (erro) {
        console.log(erro.msg);
    }
}

//autoReinicioONU(argumentoIP[2]);
autoReinicioONU('172.16.33.181');



