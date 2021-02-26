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
    public class PageRegistry:InitDriver
    {
        private void FillDictionary()
        {
            InitilizeDriver("http://demowebshop.tricentis.com/");
            Dictionary<string, Textbox> textbox = new Dictionary<string, Textbox>();
            textbox.Add("Name", new Textbox {});

        }
    }
}
