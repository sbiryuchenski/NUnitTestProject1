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
                new UIMapper{ Name = Buttons.Register, Locator = By.XPath("//a[@href='/register']") },
            };
            return elements;
        }
    }
}
