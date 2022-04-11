using System.IO;
using System;
using System.Text.Json;
using NUnit.Framework;
using Shop.Test;
using System.Diagnostics;
using Status = AventStack.ExtentReports.Status;
using NUnit.Framework.Interfaces;
using NUnitTestProject1.Models;
using System.Linq;

namespace NUnitTestProject1.Common
{
    /// <summary>
    /// Базовый класс тест кейса
    /// </summary>
    public abstract partial class BaseTest
    {
        public Context Context;

        Settings Settings;

        /// <summary>
        /// Продолжительность выполнения автотеста
        /// </summary>
        Stopwatch Duration;

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

            if (Settings.CreateReport)
            {
                string reportTitle = string.Empty; string description = string.Empty;
                //формирование отчёта
                if (TestContext.CurrentContext.Test.Properties.ContainsKey("Description") &&
                    TestContext.CurrentContext.Test.Properties["Description"].Count() != 0)
                    description = TestContext.CurrentContext.Test.Properties["Description"].ToList()[0].ToString();
                //добавление дефектов к названию
                //string bugs = string.Join(',', (Attribute.GetCustomAttributes(GetType(), typeof(BugAttribute)) as BugAttribute[]).Select(item => item.BugId));
                reportTitle = TestContext.CurrentContext.Test.Name;
                //if (!string.IsNullOrEmpty(bugs))
                //    reportTitle = $"{reportTitle} (блокировано дефектами: {bugs})";
                Reporter.Instance.CreateTest(reportTitle, description);
            }
        }

        [OneTimeSetUp]
        public void StartTest()
        {
            Duration = new Stopwatch();
            Duration.Start();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Duration?.Stop();
            if(Settings.CreateReport)
                WriteStepResultToHTML();
            Context.Driver.Quit();
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
        /// <summary>
        /// Записать результат в отчет HTML
        /// </summary>
        /// <param name="nodeName">Название узла</param>
        /// <param name="isMakeScreen">Сохранять ли скрин</param>
        private void WriteStepResultToHTML(string nodeName = "", bool isMakeScreen = true)
        {
            var test = TestContext.CurrentContext.Test;
            var result = TestContext.CurrentContext.Result;
            var status = result.Outcome.Status;
            var logstatus = status switch
            {
                TestStatus.Failed => Status.Fail,
                TestStatus.Passed => Status.Pass,
                TestStatus.Inconclusive => Status.Warning,
                TestStatus.Skipped => Status.Skip,
                _ => throw new Exception($"Поведение при статусе {status} не определено")
            };
            Reporter.Instance.CreateNode(string.IsNullOrEmpty(nodeName) ? (test.Properties.Get("Description")?.ToString() ?? test.MethodName) : nodeName);
            Reporter.Instance.CurrentNode.Log(logstatus, $"Тест завершен со статусом \"{logstatus}\"");
            //если есть ошибка
            if (!string.IsNullOrEmpty(result.Message))
            {
                string errorMessage = $"{result.Message}{result.StackTrace}";
                //string image = isMakeScreen ? Context.Driver.GetScreenShot() : "";
                //string screenHTML = string.IsNullOrEmpty(image) ? "" : $"<img src='data:image/gif;base64,{image}' width='100%' />";
                Reporter.Instance.CurrentNode.Info($"<textarea style=\"height: 100%\" rows=\"15\" readonly >{errorMessage}</textarea>");
            }
            Reporter.Instance.Report.Flush();
        }
    }
}