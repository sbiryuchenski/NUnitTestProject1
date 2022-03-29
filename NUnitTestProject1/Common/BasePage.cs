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
    }
}
