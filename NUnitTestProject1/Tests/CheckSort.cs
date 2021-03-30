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
        #region Utils
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

        private void TestSort(string xpath, bool isSort, string sortkey)
        {
            string expected = "";
            string fact = "";
            var elements = driver.FindElements(By.XPath(xpath));
            var sortedelements = elements.Select(t => t.Text);
            if (isSort) { sortedelements = elements.Select(t => t.Text).OrderByDescending(t => t); }
            else { sortedelements = elements.Select(t => t.Text).OrderBy(t => t); }
            var notsortedelements = elements.Select(t => t.Text);
            foreach(string str in sortedelements)
            {
                expected = expected + str + " ";
            }
            foreach (string str in notsortedelements)
            {
                fact = fact + str + " ";
            }
            Assert.AreEqual(notsortedelements, sortedelements, "Сортировка " + sortkey + " работает не так, как ожидалось\nОжидалось " + expected + "\nВстречено " + fact);
        }

        #endregion
        
        [Test, Order(1), Description("Проверка сортировки по имени A-Z")]
        public void CheckNamesAZ()
        {
            reverse = false;
            string sortkey = "Name: A to Z";
            SetSort(sortkey);
            TestSort("//h2[@class='product-title']/a", reverse, sortkey);
        }
        [Test, Order(2), Description("Проверка сортировки по имени Z-A")]
        public void CheckNamesZA()
        {
            reverse = true;
            string sortkey = "Name: Z to A";
            SetSort(sortkey);
            TestSort("//h2[@class='product-title']/a", reverse, sortkey);
        }
        [Test, Order(3), Description("Проверка сортировки по цене Low to Hign")]
        public void CheckPriceLowToHigh()
        {
            reverse = false;
            string sortkey = "Price: Low to High";
            SetSort(sortkey);
            TestSort("//span[@class='price actual-price']", reverse, sortkey);
        }
        [Test, Order(4), Description("Проверка сортировки по цене High to Low")]
        public void CheckPriceHighToLow()
        {
            reverse = true;
            string sortkey = "Price: High to Low";
            SetSort(sortkey);
            TestSort("//span[@class='price actual-price']", reverse, sortkey);
        }
    }
}
