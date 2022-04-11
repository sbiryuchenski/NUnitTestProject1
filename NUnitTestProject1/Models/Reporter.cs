using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NUnitTestProject1.Models
{
    public class Reporter
    {
        private static Lazy<Reporter> lazy = new Lazy<Reporter>(() => new Reporter());
        private ExtentHtmlReporter htmlReporter;
        public static Reporter Instance => lazy.Value;

        public Dictionary<string, ExtentTest> Tests { get; private set; }
        public ExtentReports Report { get; private set; }
        public ExtentTest Test { get; private set; }
        public ExtentTest CurrentNode { get; private set; }
        //public static string FileName { get; set; }
        //public static string TitleName { get; set; }
        public static Settings Settings { get; set; }

        private Reporter()
        {
            using (FileStream fstream = File.OpenRead("config.json"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string jsn = System.Text.Encoding.Default.GetString(array);
                Settings = JsonSerializer.Deserialize<Settings>(jsn);
            }

            Tests = new Dictionary<string, ExtentTest>();
            string reportDate = DateTime.Now.ToString("dd.MM.yyyy");
            var reportDir = Path.Combine(Settings.Reports, $"{reportDate}//");
            Directory.CreateDirectory(reportDir);
            htmlReporter = new ExtentHtmlReporter(reportDir);
            htmlReporter.Config.DocumentTitle = "TODO: Написать имя" + " " + Settings.Browser;
            htmlReporter.Config.ReportName = "TODO: Написать имя";
            //htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            Report = new ExtentReports();
            Report.AttachReporter(htmlReporter);
            Report.AnalysisStrategy = AnalysisStrategy.Test;
        }

        public void CreateTest(string title, string description)
        {
            Test = Report.CreateTest(title, description);
            Tests.Add(title, Test);
        }
        public void CreateNode(string title)
        {
            CurrentNode = Test.CreateNode(title);
        }
        public void RemoveNode(string title)
        {
            Report.RemoveTest(Tests["title"]);
            Tests.Remove(title);
        }
    }
}
