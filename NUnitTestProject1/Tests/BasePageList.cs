using NUnitTestProject1.Pages;
using NUnitTestProject1;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.Pages
{
    public abstract partial class BaseTest
    {
        private readonly Lazy<NavigationPage> navigationPage = new(() => new NavigationPage(null));


        public NavigationPage NavigationPage => InitializePage(navigationPage);

        private T InitializePage<T>(Lazy<T> page) where T : BasePage
        {
            if(!page.IsValueCreated)
            {
                T value = page.Value;
                value.Initialize(Context);
                return value;

            }
            return page.Value;
        }
    }
}
