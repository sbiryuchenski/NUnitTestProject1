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
        static public void WaitForAnimation(IWebDriver driver, string xpath)
        {
            (new WebDriverWait(driver, TimeSpan.FromSeconds(10))).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }

        static public void WaitForExist(IWebDriver driver, string xpath)
        {
            (new WebDriverWait(driver, TimeSpan.FromSeconds(10))).Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
    }
}
