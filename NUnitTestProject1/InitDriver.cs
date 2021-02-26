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
    public class InitDriver
    {
        protected IWebDriver driver;
        public void InitilizeDriver(string webpath)
        {
            string path = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(path);
            SetURL(webpath);
        }
        private void SetURL(string path)
        {
            driver.Url = path;
        }
    }
}
