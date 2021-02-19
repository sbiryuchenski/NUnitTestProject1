using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Yandex:Google
    {
        IWebElement button;
        [OneTimeSetUp]
        public override void SetURL()
        {
            driver.Url = "http://www.yandex.ru";
        }
        [SetUp]
        public override void FindOnPage()
        {
            search = driver.FindElement(By.XPath("//input[@name = 'text']"));
            button = driver.FindElement(By.XPath("//button[@type = 'submit']"));
        }
        public override bool Check()
        {
            return driver.FindElement(By.XPath("//*[@id=\"search-result-aside\"]")).Displayed; 
        }

    }
}
