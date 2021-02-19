using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProject1
{
    
    public class BaseTest
    {
        protected IWebDriver driver;
        protected IWebElement search;
        protected IWebElement button;
        protected IAction enter;

        [OneTimeSetUp]
        public void Initialization()
        {
            string path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
        }
        [SetUp, Order(2)]
        virtual public void FindOnPage()
        {
            search = driver.FindElement(By.XPath("//input[@name = 'q']"));
        }
        [OneTimeSetUp, Order(1)]
        virtual public void SetURL()
        {
            driver.Url = "http://www.google.com";
        }

        virtual public void FindButton()
        {
            button = driver.FindElement(By.XPath("//button[@type = 'submit']"));
        }
        virtual public bool Check()
        {
            return(driver.FindElement(By.CssSelector("#result-stats")).Displayed);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }    
    }
}