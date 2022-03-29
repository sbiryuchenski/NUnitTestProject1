using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Shop.Test;
using System.Linq;

namespace NUnitTestProject1.Common
{
    /// <summary>
    /// Базовый класс страницы
    /// </summary>
    public class BasePage
    {
        protected Context Context;
        public void Initialize(Context context) => Context = context;
        public BasePage(Context context)
        {
            Context = context;
        }

        virtual public List<UIMapper> Elements()
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
