using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Support.Extensions;

namespace NUnitTestProject1
{
    static class DriverExtention
    {
        static public void SetUrl(this IWebDriver driver, string url)
        {
            driver.Url = url;
        }
        static public string GetUrl(this IWebDriver driver)
        {
            return driver.Url;
        }
        static public IWebElement FindByXpath(this IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        static public IWebElement FindByCss(this IWebDriver driver, string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }
        static public string OpenNewTab(this IWebDriver driver, string url)
        {
            string currentwindow = driver.CurrentWindowHandle;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open()");
            string newwindow = driver.WindowHandles.Where(s => s != currentwindow).Single();
            SwitchTab(driver, newwindow);
            driver.Url = url;
            return newwindow;
        }
        static public void SwitchTab(this IWebDriver driver, string tab)// Переключить браузер на нужную вкладку
        {
            driver.SwitchTo().Window(tab);
        }
        static public int CountElements(this IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath)).Count();
        }

        static public void Rewrite(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
       /// <summary>
       /// Клик по элементу в IE
       /// </summary>
       /// <param name="driver"></param>
       /// <param name="csslocator"></param>
       /// <param name="clickevent"></param>
        static public void ExplorerMouseClick(this IWebDriver driver, string csslocator, bool clickevent = true)
        {
            driver.ExecuteJavaScript("function triggerEvents(n, e){" +
                "var ev = document.createEvent('MouseEvents');" +
                "ev.initEvent(e, true, true);" +
                "n.dispatchEvent(ev);+" +
                "}" +
                $"var element = document.querySelector(\"{csslocator}\");+" +
                "triggerEvents(element, 'mouseover');" +
                "triggerEvents(element, 'mousedown');" +
                $"{(clickevent ? "triggerEvents(element, 'click');" : "")}" +
                "triggerEvents(element, 'mouseup');");
        }
        /// <summary>
        /// Drag'n'Drop с помощью JS
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xpathFrom">Селектор элемента, который нужно перетащить</param>
        /// <param name="xpathTo">Селектор элемента, на который нужно перетащить</param>
        static public void JSDragDrop(this IWebDriver driver, string xpathFrom, string xpathTo)
        {
            IWebElement LocatorFrom = driver.FindElement(By.XPath(xpathFrom));
            IWebElement LocatorTo = driver.FindElement(By.XPath(xpathTo));
            String xto = Convert.ToString(LocatorTo.Location.X);
            String yto = Convert.ToString(LocatorTo.Location.Y);
            driver.ExecuteJavaScript("function simulate(f,c,d,e){var b,a=null;for(b in eventMatchers)if(eventMatchers[b].test(c)){a=b;break}if(!a)return!1;document.createEvent?(b=document.createEvent(a),a==\"HTMLEvents\"?b.initEvent(c,!0,!0):b.initMouseEvent(c,!0,!0,document.defaultView,0,d,e,d,e,!1,!1,!1,!1,0,null),f.dispatchEvent(b)):(a=document.createEventObject(),a.detail=0,a.screenX=d,a.screenY=e,a.clientX=d,a.clientY=e,a.ctrlKey=!1,a.altKey=!1,a.shiftKey=!1,a.metaKey=!1,a.button=1,f.fireEvent(\"on\"+c,a));return!0} var eventMatchers={HTMLEvents:/^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,MouseEvents:/^(?:click|dblclick|mouse(?:down|up|over|move|out))$/}; " +
            "simulate(arguments[0],\"mousedown\",0,0); simulate(arguments[0],\"mousemove\",arguments[1],arguments[2]); simulate(arguments[0],\"mouseup\",arguments[1],arguments[2]); ",
            LocatorFrom, xto, yto);
        }



    }
}
