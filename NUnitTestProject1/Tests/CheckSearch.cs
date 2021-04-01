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
using System.Linq;
using System.Collections.Generic;


namespace NUnitTestProject1.Tests
{
    [TestFixture]
    class CheckSearch:BaseTest
    {
        Page searchpg;
        SelectElement category;
        public override void InitPage()
        {
            driver.SetUrl("http://demowebshop.tricentis.com/search");            
            searchpg = new Page(driver);
        }
        private void SetItem(string value)
        {
            new SelectElement(searchpg.WebElement("category")).SelectByValue(value);
        }

        public override void FillDictionary()
        {
            searchpg.SetElementLocator("advanced", "//input[@name='As']");
            searchpg.WebElement("advanced").Click();
            searchpg.SetElementLocator("searchbox", "//input[@class='search-text']");
            searchpg.SetElementLocator("category", "//select[@id='Cid']");
            category = new SelectElement(searchpg.WebElement("category"));
            searchpg.SetElementLocator("manufacturer", "//select[@id='Mid']");
            searchpg.SetElementLocator("pricefrom", "//input[@id='Pf']");
            searchpg.SetElementLocator("priceto", "//input[@id='Pt']");
            searchpg.SetElementLocator("searchsub", "//input[@id='Isc']");
            searchpg.SetElementLocator("searchdescr", "//input[@id='Sid']");
            searchpg.SetElementLocator("search", "//input[@class='button-1 search-button']");
        }

        [Test, Order(1)]
        public void CategoryTest()
        {
            searchpg.WebElement("searchbox").SendKeys("Computer");
            var selected = category.Options;
            //var values = selected.Select(s => s.s.GetAttribute("value"));
            List<string> values = new List<string>();
            
            foreach(IWebElement s in selected)
            {
                values.Add(s.GetAttribute("value"));
            }
            foreach(string val in values)
            {
                SetItem(val);
                searchpg.WebElement("search").Click();

            }
        }
    }
}
