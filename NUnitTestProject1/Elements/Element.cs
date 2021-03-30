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
    public class Element
    {
        IWebDriver driver;
        IWebElement element;
        public Element(IWebDriver setdriver) { driver = setdriver; }
        public void SetElement(string xpath)
        {
            element = driver.FindByXpath(xpath);
        }
        /// <summary>
        /// Клик по элементу
        /// </summary>
        public void Click()
        {
            element.Click();
        }
        /// <summary>
        /// Навести курсор на элемент
        /// </summary>
        public void MoveOn()
        {
            Actions move = new Actions(driver);
            move.MoveToElement(element).Build().Perform();
        }
        /// <summary>
        /// Ввод текста
        /// </summary>
        /// <param name="text">Текст</param>
        public void Input(string text)
        {
            element.SendKeys(text);
        }
        /// <summary>
        /// Очистить поле ввода элемента
        /// </summary>
        public void Clear()
        {
            element.Clear();
        }
        /// <summary>
        /// Ввести новый текст в элемент. Старый текст стирается
        /// </summary>
        /// <param name="text">Текст</param>
        public void Rewrite(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        /// <summary>
        /// Возвращает элемент
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement Get()
        {
            return element;
        }
        /// <summary>
        /// Возвращает текст элемента
        /// </summary>
        /// <returns>Текст элемента</returns>
        public string GetText()
        {
            return element.Text;
        }
    }
}
