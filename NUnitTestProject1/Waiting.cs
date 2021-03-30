using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace NUnitTestProject1
{
    [Description("Ожидания")]
    static class Waiting
    {
        static WebDriverWait wait;
        /// <summary>
        /// Ожидать окончания анимации
        /// </summary>
        /// <param name="xpath">Селектор элемента анимации</param>
        static public void WaitForAnimation(string xpath)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }

        static public void WaitForExist(string xpath)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
    }
}
