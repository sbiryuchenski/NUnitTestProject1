using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    [Description("Ожидания")]
    static class Waiting
    {
        static public void WaitForAnimation(IWebDriver driver, string xpath)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }

        static public void WaitElementExist(IWebDriver driver, string xpath)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }
    }
}
