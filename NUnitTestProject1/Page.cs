using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProject1
{
    public class Page
    {
        IWebDriver driver;
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
        private void FillDictionary()
        {
            InitilizeDriver("http://demowebshop.tricentis.com/");
            Dictionary<string, Textbox> textbox = new Dictionary<string, Textbox>();
            Textbox name = new Textbox(driver);
            name.SetElement("//input[@name='FirstName']");
            textbox.Add("Name", name);
        }
    }
}
