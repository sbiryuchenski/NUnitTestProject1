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
    class CheckLaptopOrder:BaseTest
    {
        SelectElement selectcountry;
        SelectElement selectstate;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/notebooks";
        }

        [Description("Ввод страны")]
        private void SetCountry(string countryname)
        {
            selectcountry = new SelectElement(driver.FindElement(By.XPath("//select[@class='country-input']")));
            selectcountry.SelectByText(countryname);
        }

        [Description("Ожидание для следующего действия")]
        private void Wait()
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loading-image']")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='bar-notification']")));
        }

        [Description("Ввод штата")]

        private void SetState(string statename)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//select[@class='state-input']//*[text()='Nunavut']")));
            selectstate = new SelectElement(driver.FindElement(By.XPath("//select[@class='state-input']")));
            selectstate.SelectByText(statename);
        }

        [Description("Ввод индекса")]
        private void SetZip(string zipcode)
        {
            driver.FindElement(By.XPath("//input[@class='zip-input']")).SendKeys("9898");
        }

        [Description("Ввод полей")]
        public void SetFields(string countryname, string statename, string zip)
        {
            SetCountry(countryname);
            SetState(statename);
            SetZip(zip);
        }

        [Description("Проверка отображения информации после ввода полей")]
        private void CheckInform()
        {
            bool textexist = driver.FindElements(By.XPath("//span[@class='option-description']")).Count > 0;
            Assert.IsTrue(textexist, "Информация не отображается");
        }

        [Description("Проверка наличия товара в корзине")]
        private void CheckCart()
        {
            bool laptopexist = driver.FindElements(By.XPath("//a[normalize-space(text())='14.1-inch Laptop']")).Count > 0;
            Assert.IsTrue(laptopexist, "Товара нет в корзине");
        }

        [Description("Добавление товара в корзину и переход в корзину")]
        private void AddToCart()
        {
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
            Wait();
            driver.FindElement(By.XPath("//li[@id='topcartlink']//a")).Click();
        }

        [Description("Проверка наличия товара в корзине, проверка ввода полей и наличия информации после ввода")]
        private void Check()
        {
            CheckCart();
            SetFields("Canada", "Nunavut", "9898");
            driver.FindElement(By.XPath("//input[@name='estimateshipping']")).Click();
            Wait();
            CheckInform();
        }

        [Test, Description("Проверка добавления товара в корзину и заполнения полей")]
        public void TestLaptop()
        {
            AddToCart();
            this.Check();
        }
    }
}
