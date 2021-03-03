using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProject1.Tests
{ 
    [TestFixture, Description("Проврека входа в учётную запись")]
    class LoginPage:BaseTest
    {
        private string urlbefore;
        private string urlafter;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/login";
        }
        Page logpage;
        public override void InitPage()
        {
            logpage = new Page(driver);
        }
        private void LogButtonClick()
        {

        }
        public override void FillDictionary()
        {
            logpage.SetElement("email", "//input[@Name='Email']");
            logpage.SetElement("password", "//input[@Name='Password']");
            logpage.SetElement("logbutton", "//input[@type='submit']");
        }
        [Test, Order(1), Description("Тест с неправильными данными для входа")]
        public void LoginWrongTest()
        {
            logpage.webelement["email"].Input("123");
            logpage.webelement["password"].Input("123");
            urlbefore = driver.Url;
            logpage.webelement["logbutton"].Click();
            urlafter = driver.Url;
            Assert.IsTrue(urlafter.Contains(urlbefore), "Тест с неправильными данными для входа не выполняется");
        }
        [Test, Order(2), Description("Тест с верными данными для входа")]
        public void LoginTrueTest()
        {
            logpage.webelement["email"].Input("email@email.email");
            logpage.webelement["password"].Input("PaSsWoRd123");
            urlbefore = driver.Url;
            logpage.webelement["logbutton"].Click();
            urlafter = driver.Url;
            Assert.IsFalse(urlafter.Contains(urlbefore), "Тест с верными данными для входа не выполнен");
        }
    }
}

