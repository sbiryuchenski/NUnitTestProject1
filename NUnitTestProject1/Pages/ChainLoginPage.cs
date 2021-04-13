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
        public ChainLoginPage Email(string log)
        {
            WebElement("//input[@class='login']").SendKeys(log);
            return this;
        }             
        public ChainLoginPage Password(string password)
        {
            WebElement("//input[@class='login']").SendKeys(password);
            return this;
        }
        public ChainLoginPage Login()
        {
            WebElement("//input[@value='Log in']").Click();
            return this;
        }
    }
}
