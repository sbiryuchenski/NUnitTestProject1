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
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Shop.Test;

namespace NUnitTestProject1.Common
{
    /// <summary>
    /// Базовый класс тест кейса
    /// </summary>
    public abstract partial class BaseTest
    {
        public Context Context;

        Settings Settings;
        public BaseTest()
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            //Settings = configuration.GetSection(nameof(Settings)).Get<Settings>();

            using (FileStream fstream = File.OpenRead("config.json"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string jsn = System.Text.Encoding.Default.GetString(array);
                Settings = JsonSerializer.Deserialize<Settings>(jsn);
                Context = new Context(Settings.Browser);

            }
        }

        [OneTimeSetUp]
        public void StartTest()
        {
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Context.Driver.Close();
        }

        /// <summary>
        /// Попытаться выполнить действие
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected static void TryAction(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }
    }
}