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
using System.Linq;

namespace NUnitTestProject1.Tests
{
    [TestFixture, Description("Проверка сортировки")]
    class CheckSort:BaseTest
    {
        bool reverse = false;

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

        private void GetAllNames(bool reverse)
        {
            if (reverse) { var sortednames = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")).OrderByDescending(n => n) select n; }
            else { var sortednames = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")).OrderBy(n => n) select n; }
            var names = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")) select n;
        }
        private void GetAllPrices(bool reverse)
        {
            if (reverse) { var sortedprices = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")).OrderByDescending(n => n) select n; }
            else { var sortedprices = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")).OrderBy(n => n) select n; }
            var prices = from n in driver.FindElements(By.XPath("//h2[@class='product-title']/a")) select n;
        }
        private void Clear(List<string> one, List<string> two)
        {
            one.Clear();
            two.Clear();
        }
        [Test, Order(1), Description("Проверка сортировки по имени A-Z")]
        public void CheckNamesAZ()
        {
            reverse = false;
            SetSort("Name: A to Z");
            GetAllNames(reverse);
            Assert.AreEqual(sortednames, names, "Сортировка по имени A-Z работает не так как ожидалось");
            names.Clear();
            sortednames.Clear();
        }
        [Test, Order(2), Description("Проверка сортировки по имени Z-A")]
        public void CheckNamesZA()
        {
            reverse = true;
            SetSort("Name: Z to A");
            GetAllNames(reverse);
            Assert.AreEqual(sortednames, names, "Сортировка по имени Z-A работает не так как ожидалось");
            Clear(names, sortednames);
        }
        [Test, Order(3), Description("Проверка сортировки по цене Low to Hign")]
        public void CheckPriceLowToHigh()
        {
            reverse = false;
            SetSort("Price: Low to High");
            GetAllPrices(reverse);
            Assert.AreEqual(prices, sortedprices, "Сортировка по цене Low to High работает не так, как ожидалось");
            Clear(prices, sortedprices);
        }
        [Test, Order(4), Description("Проверка сортировки по цене High to Low")]
        public void CheckPriceHighToLow()
        {
            reverse = true;
            SetSort("Price: High to Low");
            GetAllPrices(reverse);
            Assert.AreEqual(prices, sortedprices, "Сортировка по цене High to Low работает не так, как ожидалось");
            Clear(prices, sortedprices);
        }
    }
}
