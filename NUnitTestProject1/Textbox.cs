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
    class Textbox
    {
        private IWebElement box;
        private IWebDriver driver;
        public void InitializeDriver(IWebDriver basedriver)
        {
            driver = basedriver;   
        }
        public void InitializeTextBox(string path)
        {
            box = driver.FindElement(By.XPath(path));
        }
        public void Input(string text)
        {
            box.SendKeys(text);   
        }
        public void Click()
        {
            box.Click();
        }
        public void MoveOn()
        {
            Actions move = new Actions(driver);
            move.MoveToElement(box).Build().Perform();
        }
        public void Clear()
        {
            box.Clear();
        }
    }
}
