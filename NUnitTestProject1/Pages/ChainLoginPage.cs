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

namespace NUnitTestProject1
{
    class ChainLoginPage:Page
    {
        public ChainLoginPage(IWebDriver searchdriver) : base(searchdriver)
        {
            driver = searchdriver;
        }

        private IWebElement WebElement(string xpath)
        {
            return driver.FindByXpath(xpath);
        }
        /// <summary>
        /// Установить email
        /// </summary>
        /// <param name="login"></param>
        public void SetLogin(string login)
        {
            WebElement("//input[@class='login']").SendKeys(login);
        }
        /// <summary>
        /// Установить пароль
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            WebElement("//input[@class='password']").SendKeys(password);
        }
        /// <summary>
        /// Нажать на кнопку Login
        /// </summary>
        public void Login()
        {
            WebElement("//input[@value='Log in']").Click();
        }
    }
}
