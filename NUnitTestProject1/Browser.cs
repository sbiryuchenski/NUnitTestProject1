using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NUnitTestProject1
{
    static class Browser
    {
        public enum BrowserType
        {
            Chrome = 1, IE, Firefox, Edge
        }

        /// <summary>
        /// Get BrowserType
        /// </summary>
        /// <returns></returns>
        static public BrowserType GetBrowser()
        {
            string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            String browsername = ConfigurationManager.AppSettings.Get("browser");
            BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), browsername);
            return browser;
        }
    }
}
