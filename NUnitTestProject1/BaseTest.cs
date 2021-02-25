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
        protected IWebElement textbox;
        protected IWebElement button;


        [OneTimeSetUp]
        public void Initialization()
        {
            string path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
            
        }
        [OneTimeSetUp, Order(1)]
        public virtual void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/";
        }
        protected virtual string SetPath()
        {
            string path = "//a[normalize-space(text())='";
            return path;
        }
        protected virtual void SetTab(string i)
        {
            var path = SetPath();
            tab = driver.FindElement(By.XPath(path + i + "']"));
            tab.Click();
        }
        protected virtual void MoveOnTab(string i)
        {
            movetab = driver.FindElement(By.XPath("//a[normalize-space(text())='" + i + "']"));
            Actions move = new Actions(driver);
            move.MoveToElement(movetab).Build().Perform();
        }

        protected virtual void Check(string check)
        {
            string url = driver.Url;
            Assert.IsTrue(url.Contains(check), "URL не совпадает с ожидаемым");
        }
        protected void InputText(string box, string input)
        {
            textbox = driver.FindElement(By.XPath("//input[@name='"+ box +"']"));
            textbox.SendKeys(input);
        }
        protected void DeleteText(string box)
        {
            textbox = driver.FindElement(By.XPath("//input[@name='" + box + "']"));
            textbox.Clear();
        }
        public virtual void SetButton()
        {
            button = driver.FindElement(By.XPath("//input[@name='register-button']"));
        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}