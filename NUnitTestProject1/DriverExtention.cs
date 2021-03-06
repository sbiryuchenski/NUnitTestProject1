﻿using NUnit.Framework;
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
using System.Linq;

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
        static public string OpenNewTab(this IWebDriver driver, string url)
        {
            string currentwindow = driver.CurrentWindowHandle;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open()");
            string newwindow = driver.WindowHandles.Where(s => s != currentwindow).Single();
            SwitchTab(driver, newwindow);
            driver.Url = url;
            return newwindow;
        }
        static public void SwitchTab(this IWebDriver driver, string tab)// Переключить браузер на нужную вкладку
        {
            driver.SwitchTo().Window(tab);
        }
        static public int CountElements(this IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath)).Count();
        }

        static public void Rewrite(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
