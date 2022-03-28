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
using System.Linq;
using System.Threading;

namespace NUnitTestProject1.Tests
{
    [TestFixture, Description("Проверка сортировки")]

    class find :BaseTest
    {
        [Test]
        public void CheckGoogle()
        {
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys("Русский беспилотник орлан леер");
            driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys(Keys.Enter);
            Thread.Sleep(10000);
        }
    }
}
