using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;


namespace NUnitTestProject1
{
    [TestFixture, Description("Проверка валидности пустых обязательных полей на странице регистрации")]
    class ValidRegister:BaseTest
    {
        string urlbefore;
        string urlafter;
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/register";
            SetButton();
        }
        protected override void Check(string errmess)
        {
            urlafter = driver.Url;
            Assert.AreEqual(urlafter, urlbefore, errmess);
        }
        private void FillAllBoxes()
        {
            InputText("FirstName", "Name");
            InputText("LastName", "Lastname");
            InputText("Email", "Email@email.email");
            InputText("Password", "PaSsWoRd123");
            InputText("ConfirmPassword", "PaSsWoRd123");
        }

        [Test, Order(0), Description("0. Все поля пустые")]
        public void CheckClear()
        {
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие всех полей не прошло проверку");
        }
        [Test, Order(1), Description("1. Пустое поле Name")]
        public void CheckValidName()
        {
            FillAllBoxes();
            DeleteText("FirstName");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие имени не прошло проверку");
            InputText("FirstName", "Name");
        }
        [Test, Order(2), Description("4. Пустое поле Last Name")]
        public void CheckValidLastName()
        {
            DeleteText("LastName");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие фамилии не прошло проверку");
            InputText("LastName", "Lastname");
        }
        [Test, Order(3), Description("3. Пустое поле Email")]
        public void CheckValidEmail()
        {
            DeleteText("Email");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие Электронной почты не прошло проверку");
            InputText("Email", "Email@email.email");
        }
        [Test, Order(4), Description("4. Пустое поле Password")]
        public void CheckValidPassword()
        {
            DeleteText("Password");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие пароля не прошло проверку");
            InputText("Password", "PaSsWoRd123");
        }
        [Test, Order(5), Description("5. Пустое поле Confirm Password")]
        public void CheckValidPasswordConfirm()
        {
            FillAllBoxes();
            DeleteText("ConfirmPassword");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие подтверждения не прошло проверку");
            InputText("ConfirmPassword", "PaSsWoRd123");
        }
    }
}
