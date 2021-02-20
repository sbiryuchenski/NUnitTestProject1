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
    [TestFixture]
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
        [Test, Order(1)]
        public void CheckValidName()
        {
            FillAllBoxes();
            DeleteText("FirstName");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие имени не прошло проверку");
        }
        [Test, Order(2)]
        public void CheckValidLastName()
        {
            FillAllBoxes();
            DeleteText("LastName");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие фамилии не прошло проверку");
        }

        [Test, Order(3)]
        public void CheckValidEmail()
        {
            FillAllBoxes();
            DeleteText("Email");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие Электронной почты не прошло проверку");
        }
        [Test, Order(4)]
        public void CheckValidPassword()
        {
            FillAllBoxes();
            DeleteText("Password");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие пароля не прошло проверку");
        }
        [Test, Order(5)]
        public void CheckValidPasswordConfirm()
        {
            FillAllBoxes();
            DeleteText("ConfirmPassword");
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие подтверждения не прошло проверку");
        }
        [Test, Order(0)]
        public void CheckClear()
        {
            urlbefore = driver.Url;
            button.Click();
            Check("Отсутствие всех полей не прошло проверку");
        }
    }
}
