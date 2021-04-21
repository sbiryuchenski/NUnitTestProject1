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
        string pagetitle = "//div[@class='page-title']";
        Settings parameters;

        [OneTimeSetUp, Order(0)]//
        public void Initialization() // Инициализация браузера, страницы и элементов на странице
        {
            using (FileStream fstream = File.OpenRead("config.json"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string jsn = System.Text.Encoding.Default.GetString(array);
                parameters = JsonSerializer.Deserialize<Settings>(jsn);
            }


            string path = Directory.GetCurrentDirectory();
            BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), parameters.Browser);
            switch (browser)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver(path);
                    break;
                case BrowserType.IE:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.PageLoadStrategy = PageLoadStrategy.None;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new InternetExplorerDriver(path, options);
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions optionsfox = new FirefoxOptions();
                    optionsfox.PageLoadStrategy = PageLoadStrategy.Normal;
                    // optionsfox.BrowserExecutableLocation = "C:/Pr0ogram Files/Mozilla Firefox";
                    driver = new FirefoxDriver(path);
                    break;
                case BrowserType.Edge:
                    driver = new EdgeDriver(path);
                    break;
                default:
                    throw new Exception("Указан неверный браузер в файле конфигурации");
            }
            if (parameters.isMaximize)
            {
                driver.Manage().Window.Maximize();
            }
            else
            {
                driver.Manage().Window.Size = new System.Drawing.Size(parameters.Width, parameters.Height);
            }
            SetURL();
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            InitPage();
            FillDictionary();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));// Создаю новое ожидание
        }
        /// <summary>
        /// Инициализация элементов на странице. Выполняется один раз при запуске тест класса
        /// </summary>
        public virtual void InitPage()
        {
        }
        /// <summary>
        ///  Находит элемент на странице по Xpath и возвращает объект типа IWebElement
        /// </summary>
        /// <param name="xpath">Xpath селектор</param>
        /// <returns>Переменная IWebElement</returns>
        public virtual IWebElement SetElement(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        /// <summary>
        /// Set Url to driver
        /// </summary>
        public virtual void SetURL()
        {
            driver.Url = "http://demowebshop.tricentis.com/";
        }

        /// <summary>
        /// Fill dictionary that contains WebElements of the page
        /// </summary>
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
        /// <summary>
        /// Навести курсор на элемент 
        /// </summary>
        
        protected virtual void MoveOnTab(string i)
        {
            movetab = driver.FindByXpath("//a[normalize-space(text())='" + i + "']");
            Actions move = new Actions(driver);
            move.MoveToElement(movetab).Build().Perform();
        }

        /// <summary>
        /// Сравнение ОР и ФР и генерирование исключения
        /// </summary>
        /// <param name="check"></param>
        protected virtual void Check(string check)// Проверка соответствия URL
        {
            Waiting.WaitForAnimation(driver, pagetitle);// Жду пока отобразится заголовок страницы
            string url = driver.GetUrl();
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