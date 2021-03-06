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
using System.Collections.Generic;

namespace NUnitTestProject1
{
    class SearchPage:Page
    {
        public IWebDriver driver;
        /// <summary>
        /// Содержит элементы страницы поиска
        /// </summary>
        /// <param name="searchdriver">driver</param>
        public SearchPage(IWebDriver searchdriver):base(searchdriver)
        {
            driver = searchdriver;
            driver.FindByXpath("//input[@id='As']").Click();
        }


        Dictionary<string, string> webpath = new Dictionary<string, string>
        {
            {"advanced", "//input[@name='As']" },
            {"searchbox", "//input[@class='search-text']" },
            {"category", "//select[@id='Cid']" },
            {"pricefrom", "//input[@id='Pf']" },
            {"priceto", "//input[@id='Pt']" },
            {"searchsub", "//input[@id='Isc']" },
            {"searchdescr", "//input[@id='Sid']" },
            {"search", "//input[@class='button-1 search-button']" }
        };
        /// <summary>
        /// Возвращает Элемент страницы
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <returns></returns>
        public IWebElement WebElement(string name)
        {
            return driver.FindByXpath(webpath[name]);
        }

        /// <summary>
        /// Возвращает Select element
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <returns></returns>
        public SelectElement SelectWebElement(string name)
        {
            return new SelectElement(driver.FindByXpath(webpath[name]));
        }
    }

    
}
