using Shop.Test;
using System.Collections.Generic;
using NUnitTestProject1.Common;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnitTestProject1.Models;
using NUnitTestProject1.Enums;

namespace NUnitTestProject1.Pages
{
    /// <summary>
    /// Страница регистрации
    /// </summary>
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(Context context) : base(context) { }

        public override List<UIMapper> Elements()
        {
            List<UIMapper> elements = new List<UIMapper>
            {
                new UIMapper{ Name = Buttons.Register, Locator = By.Name("register-button") },
                new UIMapper{ Name = Fields.Male, Locator = By.Id("gender-male") },
                new UIMapper{ Name = Fields.Female, Locator = By.Id("gender-female") },
                new UIMapper{ Name = Fields.FirstName, Locator = By.Name("FirstName") },
                new UIMapper{ Name = Fields.LastName, Locator = By.Name("LastName") },
                new UIMapper{ Name = Fields.Email, Locator = By.Name("Email") },
                new UIMapper{ Name = Fields.Password, Locator = By.Name("Password") },
                new UIMapper{ Name = Fields.Confirm, Locator = By.Name("ConfirmPassword") },

            };
            return elements;
        }

        By lRegCompleteMsg = By.CssSelector("div.result");

        public override BasePage ElementClick(string element)
        {
            base.ElementClick(element);
            return this;
        }
        public override BasePage ElementFill(string element, string value, bool isClear = true)
        {
            base.ElementFill(element, value, isClear);
            return this;
        }

        /// <summary>
        /// Проверить, что регистрация завершена успешно
        /// </summary>
        /// <returns></returns>
        public RegistrationPage CheckRegisterComplete()
        {
            var regCompleteText = "Your registration completed";
            var element = Waiting.WaitElementExist(Context, lRegCompleteMsg);
            Assert.AreEqual(element.Text, regCompleteText, "Регистрация не завершена");
            return this;
        }

        /// <summary>
        /// Заполнить все поля
        /// </summary>
        /// <returns></returns>
        public RegistrationPage FillAllFields(User user)
        {
            ElementClick(user.Gender == Gender.Male ? Fields.Male : Fields.Female);
            ElementFill(Fields.FirstName, user.FirstName);
            ElementFill(Fields.LastName, user.LastName);
            ElementFill(Fields.Email, user.Email);
            ElementFill(Fields.Password, user.Password);
            ElementFill(Fields.Confirm, user.ConfirmPassword);
            return this;
        }
    }
}
