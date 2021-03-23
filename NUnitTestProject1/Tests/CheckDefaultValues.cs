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

namespace NUnitTestProject1.Tests
{
    [TestFixture("Medium", "2 GB", "320 GB"), Description("Check default values and price color")]
    class CheckDefaultValues:BaseTest
    {
        string param = "default ";
        List<string> defaultvalue = new List<string>();
        Page computerpage;
        string red = "rgba(184, 7, 9, 1)";
        public CheckDefaultValues(string name1, string name2, string name3)// Дефолтные значения параметров нужно записать в TestFixture
        {
            defaultvalue.Add(name3);
            defaultvalue.Add(name2);
            defaultvalue.Add(name1);
        }
        public override void InitPage()
        {
            computerpage = new Page(driver);
        }
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/build-your-cheap-own-computer";
        }
        public override void FillDictionary()
        {
            computerpage.SetElement("price", "//span[@itemprop='price']");
            foreach(string name in defaultvalue)
            {
                computerpage.SetElement(name, "//label[contains(text(),'" + name + "')]/../input");
                computerpage.SetElement(param+name, "//label[contains(text(),'" + name + "')]/../input");
            }

        }
        private void CheckDefault(string name)// Логика проверки значений по умолчанию
        {
            string checkvalue = computerpage.webelement[name].Get().GetAttribute("Checked");
            string actualvalue = computerpage.webelement[param + name].Get().Text;
            bool check = (checkvalue == "true");
            Assert.IsTrue(check, "Выбрано значение " + actualvalue + " по умолчанию вместо " + name);
        }
        [Test, Description("Проверяет, что цвет цены красный")]
        public void PriceColorTest()
        {
            string color = computerpage.webelement["price"].Get().GetCssValue("color");
            Assert.AreEqual(red, color, "Цвет цены не красный");
        }
        [Test, Description("Проверяет дефолтные значения")]
        public void TestDefault()// Здесь defaultvalue это список со значениями, которые должны быть по дефолту
        {
            foreach(string name in defaultvalue)
            {
                CheckDefault(name);
            }
        }
    }
}
