using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Collections.Generic;

namespace NUnitTestProject1.Tests
{
    [TestFixture, Description("Проверка логина с помощью chain")]
    class CheckLoginWChain:BaseTest
    {
        ChainLoginPage logpage;
        public override void InitPage()
        {
            driver.Url = "http://demowebshop.tricentis.com/login";
            logpage = new ChainLoginPage(driver);
        }
        [Test]
        public void LoginTest()
        {
            logpage.SetLogin("123@321.com");
            logpage.SetPassword("123321");
            var url = driver.Url;
            logpage.Login();
            Assert.AreEqual(url, driver.Url, "Вход в учётную запись не выполняется");
        }
    }
}
