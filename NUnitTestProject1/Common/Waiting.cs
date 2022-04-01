using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnitTestProject1.Enums;
using Shop.Test;
using NUnit.Framework;

namespace NUnitTestProject1
{
    /// <summary>
    /// Класс с ожиданиями
    /// </summary>
    static class Waiting
    {
        /// <summary>
        /// Ожидание, что элемент перестанет отображаться
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        static public bool WaitElementInvisible(Context context, By locator)
        {
            return new WebDriverWait(context.Driver, TimeSpan.FromSeconds((int)WaitTime.Normal)).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        /// <summary>
        /// Ожидание появления элемента на странице
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        static public IWebElement WaitElementExist(Context context, By locator)
        {
            IWebElement element = null;
            try
            {
                element = new WebDriverWait(context.Driver, TimeSpan.FromSeconds((int)WaitTime.Normal)).Until(ExpectedConditions.ElementExists(locator));
            }
            catch
            {
                Assert.Fail($"Элемент с локатором {locator} не найден");
            }
            return element;
        }

        /// <summary>
        /// Ожидание кликабельности элемента на странице
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        static public IWebElement WaitElementClickable(Context context, By locator)
        {
            IWebElement element = null;
            try
            {
                element = new WebDriverWait(context.Driver, TimeSpan.FromSeconds((int)WaitTime.Normal)).Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch
            {
                Assert.Fail($"Элемент с локатором {locator} не найден");
            }
            return element;
        }
    }
}
