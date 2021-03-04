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
    public class RegistrerPageValidTest : BaseTest
    {
        public override void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/register";
        }
        Page regpage;
        public override void InitPage()
        {
            regpage = new Page(driver); 
        }
        protected string urlbefore;
        protected string urlafter;

        public override void FillDictionary()
        {
            regpage.SetElement("name", "//input[@Name='FirstName']");
            regpage.SetElement("lastname", "//input[@Name='LastName']");
            regpage.SetElement("email", "//input[@Name='Email']");
            regpage.SetElement("password", "//input[@Name='Password']");
            regpage.SetElement("confirmpassword", "//input[@Name='ConfirmPassword']");
            regpage.SetElement("regbutton", "//input[@Name='register-button']");
            regpage.SetElement("gender", "//input[@id='gender-female']");
        }

        private void Test(string deletename, string deletevalue, string buttonname, string error)
        {// deletename - имя элемента, из которого нужно удалить текст. deletevalue - значение удаляемого элемента
         // buttonname - имя кнопки, которую нужно нажать. error - текст ошибки если тест не выполнится
            urlbefore = driver.Url;
            regpage.webelement[deletename].Clear();
            regpage.webelement[buttonname].Click();
            Check(error);
            regpage.webelement[deletename].Input(deletevalue);
        }
        protected override void Check(string errmess)
        {
            urlafter = driver.Url;
            Assert.AreEqual(urlafter, urlbefore, errmess);
        }       
        private void FillAllTextBoxes()
        {
            regpage.webelement["name"].Input("name");
            regpage.webelement["lastname"].Input("lastname");
            regpage.webelement["email"].Input("email@email.email");
            regpage.webelement["password"].Input("PaSsWoRd123");
            regpage.webelement["confirmpassword"].Input("PaSsWoRd123");
        }
        [Test, Order(1), Description("Проверка пустых полей")]
        public void ClearCheck()
        {
            urlbefore = driver.Url;
            regpage.webelement["regbutton"].Click();
            Check("Пустые поля не прошли проверку");
            FillAllTextBoxes();
        }
        [Test, Order(2), Description("Проверка при отсутсвии имени")]
        public void NameCheck()
        {
            Test("name", "name", "regbutton", "Имя не прошло проверку");
        }
        [Test, Order(2), Description("Проверка при отсутствии фамилии")]
        public void LastNameCheck()
        {
            Test("lastname", "lastname", "regbutton", "Фамилия не прошла проверку");
        }
        [Test, Order(3), Description("Проверка  при отсутствии эл.почты")]
        public void EmailCheck()
        {
            Test("email", "email@email.com", "regbutton", "Эл.почта не прошла проверку");
        }
        [Test, Order(4), Description("Проверка при отсутствии пароля")]
        public void PasswordCheck()
        {
            Test("password", "PaSsWoRd123", "regbutton", "Пароль не прошёл проверку");
        }
        [Test, Order(5), Description("Проверка при отсутствии подтверждения пароля")]
        public void ConfirmPasswordCheck()
        {
            Test("password", "PaSsWoRd123", "regbutton", "Повтор пароля не прошёл проверку");
        }
    }
}
