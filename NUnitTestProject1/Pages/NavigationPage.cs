using Shop.Test;
using System;
using System.Collections.Generic;
using System.Text;
using NUnitTestProject1.Common;
using OpenQA.Selenium;

namespace NUnitTestProject1.Pages
{
    /// <summary>
    /// Навигация по сайту
    /// </summary>
    public class NavigationPage : BasePage
    {
        public NavigationPage(Context context) : base(context) { }
        public override List<UIMapper> Elements()
        {
            List<UIMapper> elements = new List<UIMapper>
            {
                new UIMapper{ Name = Buttons.Login, Locator = By.XPath("//a[@href='/login']") },
                new UIMapper{ Name = Buttons.Register, Locator = By.XPath("//a[@href='/register']") },
                new UIMapper{ Name = Buttons.Main, Locator = By.XPath("//a[@href='/']]")}
            };
            return elements;
        }

        /// <summary>
        /// Переход на главную страницу
        /// </summary>
        /// <returns></returns>
        public NavigationPage GoToMainPage()
        {
            ElementClick(Buttons.Main);
            return this;
        }
        /// <summary>
        /// Переход на страницу регистрации
        /// </summary>
        /// <returns></returns>
        public RegistrationPage Register()
        {
            ElementClick(Buttons.Register);
            return new RegistrationPage(Context);
        }
        /// <summary>
        /// Переход на страницу авторизации
        /// </summary>
        /// <returns></returns>
        public LoginPage Login()
        {
            ElementClick(Buttons.Login);
            return new LoginPage(Context);
        }
    }
}
