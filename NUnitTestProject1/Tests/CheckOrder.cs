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
    [TestFixture("Fiction", "Health Book", "Computing and Internet"), Description("Проверка добавления товаров в корзину")]
    class CheckOrder:BaseTest
    {
        #region Utils
        string baranim = "//div[@id='bar-notification']";
        string loadanim = "//div[@class='loading-image']";
        List<string> books = new List<string>();
        public CheckOrder(string name1, string name2, string name3)
        {
            books.Add(name1);
            books.Add(name2);
            books.Add(name3);
        }
        private void AddToCart()
        {
            foreach(string name in books)
            {
                orderpage.webelement[name].Click();
                Waiting.WaitForAnimation(driver, loadanim);
            }

        }
        protected override void Check(string check)
        {
            bool firstbookexist = driver.FindElements(By.XPath("//a[normalize-space(text())='" + check + "']")).Count > 0;
            Assert.IsTrue(firstbookexist, check + " нет в корзине");
        }
        private void CheckBooksInCart()
        {
            Waiting.WaitForAnimation(driver, baranim);
            driver.FindElement(By.XPath("//li[@id='topcartlink']//a")).Click();
            foreach (string name in books)
            {
                Check(name);
            }
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
            driver.SetUrl("http://demowebshop.tricentis.com/books");
        }
        
        public override void FillDictionary()
        {
            foreach(string name in books)
            {
                orderpage.SetElement(name, "//a[normalize-space(text())='" + name + "']/../..//input[@type='button']");
            }
            
            orderpage.SetElement("cartbutton", "//li[@id='topcartlink']//a");
        }
        #endregion
       
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
