using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;
using NUnitTestProject1;
using NUnit.Framework;
using NUnitTestProject1.Enums;

namespace Shop.Test
{
    /// <summary>
    /// Класс, содержащий драйвер
    /// </summary>
    public class Context
    {
        public Settings Settings { get; set; }
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }

        [OneTimeSetUp]
        public void Initialization() // Инициализация браузера, файла настроек
        {
            using (FileStream fstream = File.OpenRead("config.json"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string jsn = System.Text.Encoding.Default.GetString(array);
                Settings = JsonSerializer.Deserialize<Settings>(jsn);
            }


            // Наверное, давайте оставим только хром. 
            // Не вижу смысла делать кросс браузерное тестирование, как минимум в автотестах
            string path = Directory.GetCurrentDirectory();
            BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), Settings.Browser);
            switch (browser)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver(path);
                    ChromeOptions chrOptions = new ChromeOptions();
                    chrOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    break;
                case BrowserType.IE:
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.PageLoadStrategy = PageLoadStrategy.None;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    Driver = new InternetExplorerDriver(path, options);
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions optionsfox = new FirefoxOptions();
                    optionsfox.PageLoadStrategy = PageLoadStrategy.Normal;
                    Driver = new FirefoxDriver(path);
                    break;
                case BrowserType.Edge:
                    Driver = new EdgeDriver(path);
                    break;
                default:
                    throw new Exception("Указан неверный браузер в файле конфигурации");
            }
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); // Ожидание загрузки страницы 5 секунд
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);
            if (Settings.isMaximize) Driver.Manage().Window.FullScreen();
            Driver.Url = Settings.Url;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds((int)WaitTime.Normal)); // Создаю новое ожидание
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Driver.Close();
        }

    }
}