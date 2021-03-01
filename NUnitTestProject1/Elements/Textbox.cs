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
    class Textbox:BaseElement
    {
        public Textbox(IWebDriver setdriver) { driver = setdriver; }
        public void Input(string text)
        {
            element.SendKeys(text);   
        }
        public void Clear()
        {
            element.Clear();
        }
    }
}
