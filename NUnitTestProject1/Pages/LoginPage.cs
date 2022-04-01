using Shop.Test;
using System;
using System.Collections.Generic;
using System.Text;
using NUnitTestProject1.Common;
using OpenQA.Selenium;
using NUnit.Framework;

namespace NUnitTestProject1.Pages
{
    /// <summary>
    /// Страница авторизации
    /// </summary>
    public class LoginPage : BasePage
    {
        public LoginPage(Context context) : base(context) { }

        public override List<UIMapper> Elements()
        {
            List<UIMapper> elements = new List<UIMapper>
            {
                new UIMapper{ Name = Buttons.Login, Locator = By.XPath("//a[@href='/login']") },
                new UIMapper{ Name = Fields.Email, Locator = By.Name("Email") },
                new UIMapper{ Name = Fields.Password, Locator = By.Name("Password") },
                new UIMapper{ Name = Buttons.LoginBnt, Locator = By.CssSelector("input[class*='login-button']") },
                new UIMapper{ Name = Fields.Account, Locator = By.CssSelector("a[href='/customer/info']") },
            };
            return elements;
        }

        /// <summary>
        /// Авторизоваться в приложении
        /// </summary>
        /// <returns></returns>
        public LoginPage Login()
        {
            ElementFill(Fields.Email, Context.Settings.Email);
            ElementFill(Fields.Password, Context.Settings.Password);
            ElementClick(Buttons.LoginBnt);
            CheckAccountLogin(Context.Settings.Email);
            return this;
        }

        /// <summary>
        /// Проверить вход в аккаунт
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public LoginPage CheckAccountLogin(string email)
        {
            var actual = GetWebElement(Fields.Account).Text;
            var expexted = email;
            string error = $"Ожидалось, что будет отображаться имя пользователя - {expexted}, встречено - {actual}";
            Assert.AreEqual(expexted, actual, error);
            return this;
        }
    }
}
