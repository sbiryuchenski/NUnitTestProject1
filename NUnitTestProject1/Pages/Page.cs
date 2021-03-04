 using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class Page
    {
        IWebDriver driver;
        public IWebElement element;

        public Dictionary<string, Element> webelement = new Dictionary<string, Element>();// Словарь, в котором хранятся все элементы страницыЫ
        public Page(IWebDriver setdriver) { driver = setdriver; }
        private void FillDictionary(string xpath, string name)// Метод, добавляющий элемент в словарь
        {
            webelement.Add(name, new Element(driver));
            webelement[name].SetElement(xpath);
        }
        public void SetElement(string name, string xpath)// Добавить элемент в словарь из другого класса
        {
            FillDictionary(xpath, name);
        }

    }
}
