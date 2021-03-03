 using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProject1
{
    public class Page
    {
        IWebDriver driver;
        public Dictionary<string, Element> webelement = new Dictionary<string, Element>();
        public Page(IWebDriver setdriver) { driver = setdriver; }
        private void FillDictionary(string xpath, string name)
        {
            webelement.Add(name, new Element(driver));
            webelement[name].SetElement(xpath);
        }
        public void SetElement(string name, string xpath)
        {
            FillDictionary(xpath, name);
        }
        public IWebElement element;       
    }
}
