using OpenQA.Selenium;
using Shop.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    /// <summary>
    /// Управление элементами страницы
    /// </summary>
    static class UIController
    {
        /// <summary>
        /// Заполнить элемент
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        /// <param name="isClear"></param>
        static public void ElementFill(Context context, By locator, string value, bool isClear = true)
        {
            var element = Waiting.WaitElementExist(context, locator);
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Клик по элементу
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locator"></param>
        static public void ElementClick(Context context, By locator)
        {
            Waiting.WaitElementExist(context, locator).Click();
        }
    }
}
