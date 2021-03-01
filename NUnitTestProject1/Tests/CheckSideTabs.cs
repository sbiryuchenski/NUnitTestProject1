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
    [TestFixture, Description("Проверка боковых вкладок")]
    public class CheckSideTabs:Tabs
    {
        protected override string SetPath()
        {
            string path = "//ul[@class = 'list']//a[normalize-space(text())='";
            return path;
        }

        protected override void MoveOnTab(string i)
        {
            var path = SetPath();
            tab = driver.FindElement(By.XPath(path + i + "']"));
            tab.Click();
        }
    }
}
