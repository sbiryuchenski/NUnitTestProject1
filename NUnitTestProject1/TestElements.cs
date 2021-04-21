using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace NUnitTestProject1
{
    [TestFixture]
    class TestElements:BaseTest
    {
        public override void SetURL()
        {
            driver.Url = "https://www.w3schools.com/howto/howto_js_draggable.asp";
        }
        [Test]
        public void Test1()
        {
            IWebElement dragelement = driver.FindByXpath("//div[@id='mydivheader']");
            IWebElement point1 = driver.FindByXpath("//a[@class='w3-left w3-btn']");
            IWebElement point2 = driver.FindByXpath("//a[@class='w3-right w3-btn']");
            IWebElement point3 = driver.FindByXpath("//a[@class='w3schools-logo notranslate']");
            // Actions move = new Actions(driver);
            // Первый вариант
            /* move.ClickAndHold(dragelement).Perform();
             move.MoveToElement(point1).Perform(); 
             move.Release(dragelement).Perform();
             Thread.Sleep(100);
             move.ClickAndHold(dragelement).Perform();
             move.MoveToElement(point2).Perform();
             move.Release(dragelement).Perform();
             Thread.Sleep(100);
             move.ClickAndHold(dragelement).Perform();
             move.MoveToElement(point3).Perform();
             move.Release(dragelement).Perform();
             Thread.Sleep(100);

             // Второй вариант
             move.DragAndDrop(dragelement, point1).Build().Perform();
             Thread.Sleep(100);
             move.DragAndDrop(dragelement, point2).Build().Perform();
             Thread.Sleep(100);
             move.DragAndDrop(dragelement, point3).Build().Perform();
             Thread.Sleep(100);
             #region
             // Тут ничего нет
             #endregion
            */
            driver.JSDragDrop("//div[@id='mydivheader']", "//a[@class='w3-left w3-btn']");
            Thread.Sleep(100);
        }
           

    }
}
