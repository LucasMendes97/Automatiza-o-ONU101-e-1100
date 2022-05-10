const {Builder, By, Key, until} = require('selenium-webdriver');


(async function autoReinicioONU101() {
    try {

        let driver = await new Builder().forBrowser('MicrosoftEdge').build();

        await driver.get('http://172.16.33.181/');

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
        await driver.findElement(By.id("msgconfirmb")).click();

        await driver.quit();

    } catch (error) {
        console.log(error)
    }
})();