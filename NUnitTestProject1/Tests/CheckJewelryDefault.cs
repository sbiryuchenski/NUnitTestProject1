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
    [TestFixture("None"), Description("Проверка дефолтных параметров заказа jewelry")]
    class CheckJewelryDefault:BaseTest
    {
        #region Utils
        SelectElement material;
        string expectedpendant;
        string expectedmaterial = "Gold (0,5 mm)";
        public CheckJewelryDefault(string expectedpendant)
        {
            this.expectedpendant = expectedpendant;
        }
        Page jewelrypage;
        public override void InitPage()
        {
            jewelrypage = new Page(driver);
        }
        public override void SetURL()
        {
            driver.SetUrl("http://demowebshop.tricentis.com/create-it-yourself-jewelry");
        }
        public override void FillDictionary()
        {
            jewelrypage.SetElement("material", "//dd/select");
            jewelrypage.SetElement("lenght", "//dd/input[@class='textbox']");
            jewelrypage.SetElement("pendant", "//dd/ul[@class='option-list']/li/input[@checked='checked']/../label");
            material = new SelectElement(jewelrypage.webelement["material"].Get());
        }
        private void MaterialCheck(string expectedmaterial)// Проверка material
        {
            string selected = material.SelectedOption.Text;
            bool check = selected.Contains(expectedmaterial);
            Assert.IsTrue(check, "Параметр Material должен быть " + expectedmaterial + " вместо " + selected);
        }
        private void LengthCheck()// Проверка Lenght
        {
            string text = jewelrypage.webelement["lenght"].GetText();
            bool check = (text == "");
            Assert.IsTrue(check, "В поле Lenght записано значение " + text + " вместо пустого поля");
        }
        private void PendantCheck()// Проверка Pendant
        {
            string text = jewelrypage.webelement["pendant"].GetText();
            bool check = text.Contains(expectedpendant);
            Assert.IsTrue(check, "Параметр Pendant должен быть " + expectedpendant + " вместо " + text);
        }
        #endregion
        
        [Test, Description("Сам тесткейс")]
        public void CheckDefault()
        {
            MaterialCheck(expectedmaterial);
            LengthCheck();
            PendantCheck();
        }
    }
}
