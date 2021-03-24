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
using System.Collections.Generic;

namespace NUnitTestProject1.Tests
{
    [TestFixture, Description("Проверка сортировки")]
    class CheckSort:BaseTest
    {
        List<string> names = new List<string>();
        List<string> prices = new List<string>();
        List<string> sortednames = new List<string>();
        List<string> sortedprices = new List<string>();

        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/books";
        }

        private void SetSort(string key)
        {
            IWebElement orderelement = driver.FindElement(By.XPath("//select[@id='products-orderby']"));
            SelectElement order = new SelectElement(orderelement);
            order.SelectByText(key);
        }

        private void GetAllNames()
        {
           var nameelements = driver.FindElements(By.XPath("//h2[@class='product-title']/a"));
           foreach(var name in nameelements)
            {
                names.Add(name.Text);
            }
            sortednames = names;
            sortednames.Sort();
        }
        private void GetAllPrices()
        {
            var priceelements = driver.FindElements(By.XPath("//span[@class='price actual-price']"));
            foreach(var price in priceelements)
            {
                prices.Add(price.Text);
            }
            sortedprices = prices;
            sortedprices.Sort();
        }
        private void Clear(List<string> one, List<string> two)
        {
            one.Clear();
            two.Clear();
        }
        [Test, Order(1), Description("Проверка сортировки по имени A-Z")]
        public void CheckNamesAZ()
        {
            SetSort("Name: A to Z");
            GetAllNames();
            Assert.AreEqual(sortednames, names, "Сортировка по имени A-Z работает не так как ожидалось");
            names.Clear();
            sortednames.Clear();
        }
        [Test, Order(2), Description("Проверка сортировки по имени Z-A")]
        public void CheckNamesZA()
        {
            SetSort("Name: Z to A");
            GetAllNames();
            sortednames.Reverse();
            Assert.AreEqual(sortednames, names, "Сортировка по имени Z-A работает не так как ожидалось");
            Clear(names, sortednames);
        }
        [Test, Order(3), Description("Проверка сортировки по цене Low to Hign")]
        public void CheckPriceLowToHigh()
        {
            SetSort("Price: Low to High");
            GetAllPrices();
            Assert.AreEqual(prices, sortedprices, "Сортировка по цене Low to High работает не так, как ожидалось");
            Clear(prices, sortedprices);
        }
        [Test, Order(4), Description("Проверка сортировки по цене High to Low")]
        public void CheckPriceHighToLow()
        {
            SetSort("Price: High to Low");
            GetAllPrices();
            sortedprices.Reverse();
            Assert.AreEqual(prices, sortedprices, "Сортировка по цене High to Low работает не так, как ожидалось");
            Clear(prices, sortedprices);
        }
    }
}
