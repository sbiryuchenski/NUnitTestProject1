using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Shop.Test;
using System.Linq;
using NUnit.Framework;

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

        /// <summary>
        /// Ввести текст в элемент
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        /// <param name="isClear"></param>
        /// <returns></returns>
        public BasePage ElementFill(By locator, string value, bool isClear = true)
        {
            UIController.ElementFill(Context, locator, value, isClear);
            return this;
        }
        public virtual BasePage ElementFill(string element, string value, bool isClear = true) => ElementFill(GetElement(element), value, isClear);

        /// <summary>
        /// Клик по элементу
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public BasePage ElementClick(By locator)
        {
            UIController.ElementClick(Context, locator);
            return this;
        }
        public virtual BasePage ElementClick(string element) => ElementClick(GetElement(element));

        /// <summary>
        /// Проверка существования элемента на странице
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public BasePage CheckElementExist(By locator)
        {
            IWebElement element;
            element = Waiting.WaitElementExist(Context, locator);
            Assert.IsNotNull(element, $"Ожидалось, что элемент с локатором {locator} будет найден");
            return this;
        }

        /// <summary>
        /// Получить IWebElement
        /// </summary>
        /// <returns></returns>
        public IWebElement GetWebElement(By locator)
        {
            return Waiting.WaitElementExist(Context, locator);
        }
        public IWebElement GetWebElement(string element) => GetWebElement(GetElement(element));
    }
}
