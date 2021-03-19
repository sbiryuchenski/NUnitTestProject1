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
    [TestFixture, Description("Check color of price")]
    class CheckColor:BaseTest
    {
        IWebElement price;
        string red = "rgba(184, 7, 9, 1)";
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/build-your-cheap-own-computer";
        }
        public override void FillDictionary()
        {
            price = driver.FindElement(By.XPath("//span[@itemprop='price']"));
        }
        [Test]
        public void PriceColorTest()
        {
            var color = price.GetCssValue("color");
            Assert.AreEqual(color, red, "Цвет цены не красный");
        }
    }
}
