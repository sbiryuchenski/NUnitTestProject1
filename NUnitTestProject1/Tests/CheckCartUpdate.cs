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

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    class CheckCartUpdate:BaseTest
    {
        string bookname = "Fiction";
        string cartpage;
        string bookpage;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/books";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            bookpage = driver.CurrentWindowHandle;
            js.ExecuteScript("window.open()");
            var windows = driver.WindowHandles;
            foreach(string w in windows)
            {
                if(w!=bookpage)
                {
                    cartpage = w;
                }
            }
        }
        private void SwitchTab(string tab)
        {
            driver.SwitchTo().Window(tab);
        }
        protected override void Check(string check)
        {
            var bookcount = driver.FindElements(By.XPath("//a[normalize-space(text())='" + check + "']")).Count > 0;
            Assert.IsTrue(bookcount, "Товара " + check + " нет в корзине после update cart");
        }
        [Test, Order(1)]
        public void CheckFirstAdd()
        {
            var addbutton = SetElement("//input[@value='Add to cart']");
            addbutton.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loading-image']")));
        }
        [Test, Order(2)]
        public void CheckInCart()
        {
            SwitchTab(cartpage);
            driver.Url = "http://demowebshop.tricentis.com/cart";
            SwitchTab(bookpage);
            var addbutton = SetElement("//a[normalize-space(text())='"+ bookname +"']/../..//input[@value='Add to cart']");
            addbutton.Click();
            SwitchTab(cartpage);
            var updatebutton = SetElement("//input[@name='updatecart']");
            updatebutton.Click();
            Check(bookname);
            SwitchTab(bookpage);
            driver.Close();
            SwitchTab(cartpage);
        }
    }
}
