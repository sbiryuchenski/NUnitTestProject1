using System;
using NUnitTestProject1.Pages;

namespace NUnitTestProject1.Common
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
