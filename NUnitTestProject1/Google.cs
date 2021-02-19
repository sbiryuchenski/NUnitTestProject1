using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;


namespace NUnitTestProject1
{
    [TestFixture]
    public class Google:BaseTest
    {
        [Test, Order(1)]
        public void CheckEnter()
        {
            search.SendKeys("Первая попытка");
            Actions enter = new Actions(driver);
            enter.SendKeys(Keys.Enter);
            Assert.IsTrue(Check(), "Ожидалось, что поиск даст результаты");
        }

        [Test, Order(2)]
        public void CheckClear()
        {
            search.Clear();
            search.SendKeys("Вторая попытка");
            FindButton();
            button.Click();
            Assert.IsTrue(Check(), "Ожидалось, что поиск даст результаты");
        }
    }
}
