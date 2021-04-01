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

namespace NUnitTestProject1.Tests
{
    [TestFixture, Description("Проверка наличия товара в корзине после нажатия update cart")]
    class CheckCartUpdate:BaseTest
    {
        #region Utils

        string bookname = "Fiction";
        string cartpage;
        string bookpage;
        string loadimg = "//div[@class='loading-image']";
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/books";
            bookpage = driver.CurrentWindowHandle;
        }
       
        protected override void Check(string check)
        {
            var bookcount = driver.FindElements(By.XPath("//a[normalize-space(text())='" + check + "']")).Count > 0;
            Assert.IsTrue(bookcount, "Товара " + check + " нет в корзине после update cart");
        }
        private void FirstAdd()
        {
            var addbutton = SetElement("//input[@value='Add to cart']");
            addbutton.Click();
            Waiting.WaitForAnimation(driver, loadimg);
        }
        #endregion

        [Test, Order(2), Description("Добавление элемента в корзину, нажатие кнопки и проверка наличия")]
        public void CheckInCart()
        {
            FirstAdd();
            cartpage = driver.OpenNewTab("http://demowebshop.tricentis.com/cart");
            driver.SwitchTab(bookpage);
            var addbutton = SetElement("//a[normalize-space(text())='"+ bookname +"']/../..//input[@value='Add to cart']");
            addbutton.Click();
            driver.SwitchTab(cartpage);
            var updatebutton = SetElement("//input[@name='updatecart']");
            updatebutton.Click();
            Check(bookname);
            driver.SwitchTab(bookpage);
            driver.Close();
            driver.SwitchTab(cartpage);
        }
    }
}
