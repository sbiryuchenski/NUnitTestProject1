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
    public class Element:BaseTest
    {
        
        IWebElement element;
        public Element(IWebDriver setdriver) { driver = setdriver; }
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
        public void Input(string text)
        {
            element.SendKeys(text);
        }
        public void Clear()
        {
            element.Clear();
        }
        public void Rewrite(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
