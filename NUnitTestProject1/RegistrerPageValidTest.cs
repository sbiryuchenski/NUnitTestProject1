using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProject1
{
    [TestFixture, Description("Проверка валидности пустого ввода полей на странице регистрации с помощью паттерна")]
    class RegistrerPageValidTest:BaseTest
    {
        private string urlbefore;
        private string urlafter;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/register";
        }
        Button regbutton;
        Dictionary<string, Textbox> textboxes = new Dictionary<string, Textbox>();

        protected override void Check(string errmess)
        {
            urlafter = driver.Url;
            Assert.AreEqual(urlafter, urlbefore, errmess);
        }
        private void Test(string deletename, string deletevalue, string error)
        {
            urlbefore = driver.Url;
            textboxes[deletename].Clear();
            regbutton.Click();
            Check(error);
            textboxes[deletename].Input(deletevalue);
        }
        public override void FillDictionary()
        {
            regbutton = new Button(driver);
            regbutton.SetElement("//input[@name='register-button']");
            textboxes.Add("name", new Textbox(driver));
            textboxes.Add("lastname", new Textbox(driver));
            textboxes.Add("email", new Textbox(driver));
            textboxes.Add("password", new Textbox(driver));
            textboxes.Add("confirmpassword", new Textbox(driver));
            textboxes["name"].SetElement("//input[@name='FirstName']");
            textboxes["lastname"].SetElement("//input[@name='LastName']");
            textboxes["email"].SetElement("//input[@name='Email']");
            textboxes["password"].SetElement("//input[@name='Password']");
            textboxes["confirmpassword"].SetElement("//input[@name='ConfirmPassword']");
        }
        private void FillAllTextBoxes()
        {
            foreach (KeyValuePair<string, Textbox> box in textboxes)
            {
                box.Value.Input(box.Key);
            }
            textboxes["email"].Input("RegisterCheck@gmeel.com");
            textboxes["confirmpassword"].Input("password");
        }
        [Test, Order(1)]
        public void ClearCheck()
        {
            urlbefore = driver.Url;
            regbutton.Click();
            Check("Пустые поля не прошли проверку");
            FillAllTextBoxes();
        }
        [Test, Order(2)]
        public void NameCheck()
        {
            Test("name", "name", "Имя не прошло проверку");
        }
        [Test, Order(2)]
        public void LastNameCheck()
        {
            Test("lastname", "lastname", "Фамилия не прошла проверку");
        }
        [Test, Order(3)]
        public void EmailCheck()
        {
            Test("email", "email@email.com", "Эл.почта не прошла проверку");
        }
        [Test, Order(4)]
        public void PasswordCheck()
        {
            Test("password", "PaSsWoRd123", "Пароль не прошёл проверку");
        }
        [Test, Order(5)]
        public void ConfirmPasswordCheck()
        {
            Test("password", "PaSsWoRd123", "Повтор пароля не прошёл проверку");
        }
    }
}
