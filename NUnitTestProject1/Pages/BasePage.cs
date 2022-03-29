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
using Shop.Test;
using System.Linq;

namespace NUnitTestProject1
{
    /// <summary>
    /// Базовый класс страницы
    /// </summary>
    public class BasePage
    {
        public Context Context { get; private set; }
        BasePage(Context context)
        {
            Context = context;
        }

        private List<UIMapper> Elements()
        {
            List<UIMapper> elements = new List<UIMapper>
            {
                new UIMapper{ Name = "", Locator = By.XPath("") },
            };
            return elements;
        }

        /// <summary>
        /// Получить локатор элемента
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public By GetElement(string name)
        {
            By locator = Elements().Where(_ => _.Name == name).Select(_ => _.Locator).FirstOrDefault();
            if (locator == null)
                throw new Exception($"Локатор элемента с именем {name} не найден");
            else
                return locator;
        }
        
    }
}
