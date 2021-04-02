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
        #region 
        Page searchpg;
        SelectElement category;
        public override void InitPage()
        {
            driver.SetUrl("http://demowebshop.tricentis.com/search");            
            searchpg = new Page(driver);
        }
        private string SetItem(string value)// Установить значение элементу в category
        {
            new SelectElement(searchpg.WebElement("category")).SelectByValue(value);
            return new SelectElement(searchpg.WebElement("category")).SelectedOption.Text;
        }
        private void CheckCategory(string check)
        {
            bool ch = driver.CountElements("//h2[@class='product-title']/a")>0;
            if(check == "Computers" || check.Contains("Desktops") || check == "All")
            {
                Assert.IsTrue(ch, "При выборе параметра " + check + " и вводе в поиск слова \"computer\" нет результатов поиска");
            }
            else
            {
                Assert.IsFalse(ch, "При выборе параметра " + check + " и вводе в поиск слова \"computer\" есть результаты поиска");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inp">Что было введено</param>
        /// <param name="result">Должен ли быть при этом результат поиска</param>
        private void CheckInput(string inp, bool result)
        {
            bool check = driver.CountElements("//strong[@class='warning']") > 0;
            if (result)
            {
                Assert.IsFalse(check, "При вводе \"" + inp + "\" нет результата");
            }
            else
            {
                Assert.IsTrue(check, "При вводе \"" + inp + "\" в поиске нет сообщения об ошибке");
            }
        }
        private void CheckLongInput()
        {
            bool check = driver.CountElements("//strong[@class='result']") > 0;
            Assert.IsTrue(check, "При вводе очень длинной строки нет сообщения об ошибке");
        }
        private void InputSearchText(string text)
        {
            searchpg.WebElement("searchbox").Clear();
            searchpg.WebElement("searchbox").SendKeys(text);
            searchpg.WebElement("search").Click();
        }

        private void InputLongText(int n)// Генерация очень длинной строки
        {
            searchpg.WebElement("searchbox").SendKeys(new string('a', n));
            searchpg.WebElement("search").Click();
        }
        private void CheckPrice()
        {
            bool ch = driver.CountElements("//span[@class='price actual-price']") > 0;
            Assert.IsTrue(ch, "Не отображаются результаты поиска если поставить фильтр по цене");
        }


        private void CheckPriceFrom(string pricestr)
        {
            int price = int.Parse(pricestr);
            var elements = driver.FindElements(By.XPath("//span[@class='price actual-price']"));
            var prices = elements.Select(p => float.Parse(p.Text)).Where(p => p>=price).Count()>0;
            Assert.IsTrue(prices, "При установке цены от " + pricestr + " нет верных результатов поиска");
        }
        private void CheckPriceTo(string pricestr)
        {
            int price = int.Parse(pricestr);
            var elements = driver.FindElements(By.XPath("//span[@class='price actual-price']"));
            var prices = elements.Select(p => float.Parse(p.Text)).Where(p => p <= price).Count() > 0;
            Assert.IsTrue(prices, "При установке цены до " + pricestr + " нет верных результатов поиска");
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
        #endregion

        [Test, Order(1), Description("Проверяет отображение результатов при выборе категории")]
        public void CategoryTest()
        {
            string curtext;
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
                curtext = SetItem(val);
                searchpg.WebElement("search").Click();
                CheckCategory(curtext);
            }
        }
        [Test, Order(2), Description("Проверяет различне длины слов при вводе в search")]
        public void WrongInputTest()
        {
            searchpg.WebElement("search").Click();
            CheckInput(" ", false);

            InputSearchText("c");
            CheckInput("c", false);

            InputSearchText("co");
            CheckInput("co", false);

            InputSearchText("com");
            CheckInput("com", true);
        }
        [Test, Order(3), Description("Проверка ввода очень длинной строки в поиск")]
        public void LongInputTest()
        {
            InputLongText(2000);
            CheckLongInput();
        }
        [Test, Order(4), Description("Проверка границ цены")]
        public void PriceTest()
        {
            string price = "1000";
            searchpg.WebElement("searchbox").Clear();
            searchpg.WebElement("searchbox").SendKeys("Computer");
            searchpg.WebElement("pricefrom").SendKeys(price);
            searchpg.WebElement("search").Click();
            CheckPrice();
            CheckPriceFrom(price);
            searchpg.WebElement("pricefrom").Clear();
            searchpg.WebElement("priceto").SendKeys(price);
            searchpg.WebElement("search").Click();
            CheckPrice();
            CheckPriceTo(price);
        }
    }
}
