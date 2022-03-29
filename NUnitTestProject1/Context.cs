using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;
using NUnitTestProject1;

namespace Shop.Test
{
    /// <summary>
    /// Класс, содержащий драйвер
    /// </summary>
    public class Context
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }
        [OneTimeSetUp]
        public void Initialization() // Инициализация браузера, страницы и элементов на странице
        {
            // Наверное, давайте оставим только хром. Не вижу смысла делать кросс браузерное тестирование, как минимум в автотестах
            string path = Directory.GetCurrentDirectory();
            Browser.BrowserType browser = Browser.GetBrowser();
            switch (browser)
            {
                case Browser.BrowserType.Chrome:
                    Driver = new ChromeDriver(path);
                    break;
                case Browser.BrowserType.IE:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.PageLoadStrategy = PageLoadStrategy.None;
                    Driver = new InternetExplorerDriver(path, options, TimeSpan.FromSeconds(5));
                    break;
                case Browser.BrowserType.Firefox:
                    FirefoxOptions optionsfox = new FirefoxOptions();
                    optionsfox.PageLoadStrategy = PageLoadStrategy.Normal;
                    Driver = new FirefoxDriver(path);
                    break;
                case Browser.BrowserType.Edge:
                    Driver = new EdgeDriver(path);
                    break;
                default:
                    throw new Exception("Указан неверный браузер в файле конфигурации");
            }
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); // Ожидание загрузки страницы 5 секунд
            SetURL();
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); // Создаю новое ожидание
            // TODO: Сделать разное ожидание через enum
        }

        private void SetURL() // TODO: Не надо, сделать нормальную реализацию через жсон. Потом удалить
        {
            Driver.Url = "http://demowebshop.tricentis.com/";
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Close();
        }

    }
}