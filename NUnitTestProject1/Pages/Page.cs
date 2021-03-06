﻿ using System;
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
        public IWebDriver driver;
        public IWebElement element;

        public Dictionary<string, Element> webelement = new Dictionary<string, Element>();// Словарь, в котором хранятся все элементы страницы
        public Dictionary<string, string> webpath = new Dictionary<string, string>();
        public Page(IWebDriver setdriver) { driver = setdriver; }

        private void FillDictionary(string xpath, string name)// Метод, добавляющий элемент в словарь
        {
            webelement.Add(name, new Element(driver));
            webelement[name].SetElement(xpath);
        }
        /// <summary>
        /// Добавить WebElement в словарь webelement
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="xpath">Xpath селектор</param>
        public void SetElement(string name, string xpath)// Добавить элемент в словарь из другого класса
        {
            FillDictionary(xpath, name);
        }
        public IWebElement WebElement(string name)
        {
            return driver.FindByXpath(webpath[name]);
        }
        public void SetElementLocator(string name, string xpath)
        {
            webpath.Add(name, xpath);
        }
        /// <summary>
        /// Получить элемент из словаря
        /// </summary>
        /// <param name="name">Имя элемента в словаре</param>
        /// <returns>Тип IWebElement</returns>
        public IWebElement GetElement(string name)
        {
            IWebElement element = webelement[name].Get();
            return element;
        }

    }
}
