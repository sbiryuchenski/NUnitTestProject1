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
    [TestFixture, Description("Добавляю ноутбук в корзину и проверяю что он там есть")]
    class CheckLaptopOrder :BaseTest
    {
        SelectElement selectcountry;
        SelectElement selectstate;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/notebooks";
        }
        public void SetFields()
        {
            selectcountry = new SelectElement(driver.FindElement(By.XPath("//select[@class='country-input']")));
            selectcountry.SelectByText("Canada");
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//select[@class='state-input']//*[text()='Nunavut']")));
            selectstate = new SelectElement(driver.FindElement(By.XPath("//select[@class='state-input']")));
            selectstate.SelectByText("Nunavut");
            driver.FindElement(By.XPath("//input[@class='zip-input']")).SendKeys("9898");
        }
        private void AddToCart()
        {
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loading-image']")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='bar-notification']")));
            driver.FindElement(By.XPath("//li[@id='topcartlink']//a")).Click();
        }
        private void Check()
        {
            bool laptopexist = driver.FindElements(By.XPath("//a[normalize-space(text())='14.1-inch Laptop']")).Count > 0;
            Assert.IsTrue(laptopexist, "Товара нет в корзине");
            SetFields();
            driver.FindElement(By.XPath("//input[@name='estimateshipping']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='option-description']")));
            bool textexist = driver.FindElements(By.XPath("//span[@class='option-description']")).Count > 0;
            Assert.IsTrue(textexist, "Информация не отображается");
        }
        [Test]
        public void TestLaptop()
        {
            AddToCart();
            this.Check();
        }
    }
}
