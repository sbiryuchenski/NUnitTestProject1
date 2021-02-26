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
    abstract public class AbstractElement
    {
        protected IWebDriver driver;
        public IWebElement element;
        public void SetElement(string xpath)
        {
            element = driver.FindElement(By.XPath(xpath));
        }
        public void Click()
        {
            element.Click();
        }
        public void MoveOn()
        {
            Actions move = new Actions(driver);
            move.MoveToElement(element).Build().Perform();
        }
    }
}
