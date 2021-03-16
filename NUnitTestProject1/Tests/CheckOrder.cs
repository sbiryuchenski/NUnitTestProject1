using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1.Tests
{
    [TestFixture("Fiction", "Science", "Computing and Internet"), Description("Проверка добавления товаров в корзину")]
    class CheckOrder:BaseTest
    {
        string name1, name2, name3;
        List<string> books;
        public CheckOrder(string name1, string name2, string name3)
        {
            this.name1 = name1;
            this.name2 = name2;
            this.name3 = name3;
        }
        private void AddToCart()
        {
            orderpage.webelement["fiction"].Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loading-image']")));
            orderpage.webelement["science"].Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loading-image']")));
            orderpage.webelement["health"].Click();
        }
        protected override void Check(string check)
        {
            bool firstbookexist = driver.FindElements(By.XPath("//a[normalize-space(text())='" + check + "']")).Count > 0;
            Assert.IsTrue(firstbookexist, check + " нет в корзине");
        }
        private void CheckBooksInCart()
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='bar-notification']")));
            driver.FindElement(By.XPath("//li[@id='topcartlink']//a")).Click();
            Check(name1);
            Check(name2);
            Check(name3);
            driver.FindElement(By.XPath("//a[normalize-space(text())='Fiction']/../../td[@class='qty nobr']/input"));// Нахожу input для Fiction
            driver.FindElement(By.XPath("//a[normalize-space(text())='Fiction']/../..//span[@class='product-unit-price']"));// Нахожу Price
            driver.FindElement(By.XPath("//a[normalize-space(text())='Fiction']/../..//span[@class='product-subtotal']"));// Нахожу Total
        }
        private void DeleteFromCart(string name)
        {
            driver.FindElement(By.XPath("//a[normalize-space(text())='" + name + "']/../..//input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//input[@name='updatecart']")).Click();
        }
        private void DeleteAllFromCart(params string[] names)
        {
            foreach(string name in books)
            {
                driver.FindElement(By.XPath("//a[normalize-space(text())='" + name + "']/../..//input[@type='checkbox']")).Click();
            }
            driver.FindElement(By.XPath("//input[@name='updatecart']")).Click();
        }
        Page orderpage;
        public override void InitPage()
        {
            orderpage = new Page(driver);
        }
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/books";
        }
        private void FillList()
        {
            books = new List<string>() { name1, name2, name3 };
        }
        public override void FillDictionary()
        {
            orderpage.SetElement("fiction", "//a[normalize-space(text())='" + name1 + "']/../..//input[@type='button']");
            orderpage.SetElement("science", "//a[normalize-space(text())='" + name2 + "']/../..//input[@type='button']");
            orderpage.SetElement("health", "//a[normalize-space(text())='" + name3 + "']/../..//input[@type='button']");
            orderpage.SetElement("cartbutton", "//li[@id='topcartlink']//a");
            FillList();
        }
        [Test, Order(1), Description("Добавление 3 книг в корзину, проверка что они есть в корзине и их удаление")]
        public void AddToCartTest()
        {
            AddToCart();
            CheckBooksInCart();
            // DeleteFromCart();
            DeleteAllFromCart();
        }
    }
}
