using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;

namespace NUnitTestProject1
{
    
    public class BaseTest
    {
        protected IWebDriver driver;
        protected IWebElement tab;
        protected IWebElement movetab;


        [OneTimeSetUp]
        public void Initialization()
        {
            string path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
            
        }
        [OneTimeSetUp, Order(1)]
        virtual public void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/";
        }
        virtual protected void SetTab(string i)
        {   
            tab = driver.FindElement(By.XPath("//a[normalize-space(text())='" + i + "']"));
            tab.Click();
        }
        virtual protected void MoveOnTab(string i)
        {
            movetab = driver.FindElement(By.XPath("//a[normalize-space(text())='" + i + "']"));
            Actions move = new Actions(driver);
            move.MoveToElement(movetab).Build().Perform();
        }

        virtual protected void Check(string check)
        {
            string url = driver.Url;
            Assert.IsTrue(url.Contains(check), "URL не совпадает с ожидаемым");
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}