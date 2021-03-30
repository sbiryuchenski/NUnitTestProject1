using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1.Tests
{ 
    [TestFixture, Description("Проврека входа в учётную запись")]
    class LoginPage:BaseTest
    {
        #region Utils
        private string urlbefore;
        private string urlafter;
        WebDriverWait wait;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/login";
        }
        Page logpage;
        public override void InitPage()
        {
            logpage = new Page(driver); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));// Инициализация ожидания
        }
        private void CheckUrlWrong(string errormessage)
        {
            Assert.IsTrue(urlafter.Contains(urlbefore), errormessage);

        }
        private void CheckUrlTrue(string errormessage)
        {
            Assert.IsFalse(urlafter.Contains(urlbefore), errormessage);
        }
        private void LogButtonClick()
        {
            urlbefore = driver.Url;
            logpage.webelement["logbutton"].Click();
            urlafter = driver.Url;
        }
        public override void FillDictionary()
        {
            logpage.SetElement("email", "//input[@Name='Email']");
            logpage.SetElement("password", "//input[@Name='Password']");
            logpage.SetElement("logbutton", "//input[@value='Log in']");
        }
        #endregion
        
        [Test, Order(1), Description("Тест с неправильными данными для входа")]
        public void LoginWrongTest()
        {
            logpage.webelement["email"].Input("123");
            logpage.webelement["password"].Input("123");
            LogButtonClick();
            CheckUrlWrong("Тест с неверными данными для входа не прошёл проверку");
        }
        [Test, Order(2), Description("Тест с верными данными для входа")]
        public void LoginTrueTest()
        {
            logpage.webelement["email"].Rewrite("email@email.email");
            logpage.webelement["password"].Rewrite("PaSsWoRd123");
            LogButtonClick();
            CheckUrlTrue("Тест с верными данными для входа не прошёл проверку");
        }
    }
}

