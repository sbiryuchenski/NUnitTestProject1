using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    class check:BaseTest
    {
        Button button;
        Textbox search;
        public override void SetURL()
        {
             driver.Url = "https://www.google.com/";
        }
        public void Initall()
        {
            button = new Button(driver);
            button.SetElement("/html/body/div[1]/div[3]/form/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]");
            search = new Textbox(driver);
            search.SetElement("/html/body/div[1]/div[3]/form/div[2]/div[1]/div[1]/div/div[2]/input");
        }
        [Test]
        public void test()
        {
            Initall();
            search.Input("123");
            search.Input(Keys.Enter);
        }
    }
}
