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
    static class DriverExtention
    {
        static public void SetUrl(this IWebDriver driver, string url)
        {
            driver.Url = url;
        }
        static public string GetUrl(this IWebDriver driver)
        {
            return driver.Url;
        }
        static public IWebElement FindByXpath(this IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        static public IWebElement FindByCss(this IWebDriver driver, string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }
    }
}
