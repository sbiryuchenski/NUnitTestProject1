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

namespace NUnitTestProject1
{
    
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected IWebElement tab;
        protected IWebElement movetab;
        protected IWebElement textbox;
        protected IWebElement button;
        protected WebDriverWait wait;

        [OneTimeSetUp, Order(0)]
        public void Initialization() // Инициализация браузера, страницы и элементов на странице
        {
            Browser browsertype = new Browser();
            string path = Directory.GetCurrentDirectory();
            Browser.BrowserType browser = browsertype.GetBrowser();
            switch (browser)
            {
                case Browser.BrowserType.Chrome:
                    driver = new ChromeDriver(path);
                    break;
                case Browser.BrowserType.IE:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.PageLoadStrategy = PageLoadStrategy.None;
                    driver = new InternetExplorerDriver(path, options, TimeSpan.FromSeconds(5));
                    break;
                default:
                    throw new Exception("Указан неверный браузер в файле конфигурации");

            }
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);// Ожидание загрузки страницы 5 секунд
            SetURL();
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            InitPage();
            FillDictionary();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));// Создаю новое ожидание
        }

        public virtual void InitPage()
        {
        }
        public virtual void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/";
        }
        public virtual void FillDictionary()
        {
        }
        protected virtual string SetPath()// Установка пути к элементу на странице
        {
            string path = "//a[normalize-space(text())='";
            return path;
        }
        protected virtual void SetTab(string i)
        {
            var path = SetPath();
            tab = driver.FindElement(By.XPath(path + i + "']"));
            tab.Click();
        }
        protected virtual void MoveOnTab(string i)
        {
            movetab = driver.FindElement(By.XPath("//a[normalize-space(text())='" + i + "']"));
            Actions move = new Actions(driver);
            move.MoveToElement(movetab).Build().Perform();
        }

        protected virtual void Check(string check)// Проверка соответствия URL
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='page-title']")));// Ждупока отобразится заголовок страницы
            string url = driver.Url;
            Assert.IsTrue(url.Contains(check), "URL не совпадает с ожидаемым");
        }
        protected void InputText(string box, string input)
        {
            textbox = driver.FindElement(By.XPath("//input[@name='"+ box +"']"));
            textbox.SendKeys(input);
        }
        protected void DeleteText(string box)
        {
            textbox = driver.FindElement(By.XPath("//input[@name='" + box + "']"));
            textbox.Clear();
        }
        public virtual void SetButton()
        {
            button = driver.FindElement(By.XPath("//input[@name='register-button']"));
        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}