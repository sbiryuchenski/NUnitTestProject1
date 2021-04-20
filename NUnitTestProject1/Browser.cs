using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace NUnitTestProject1
{
    class Browser
    {
        public enum BrowserType
        {
            Chrome = 1, IE, Firefox, Edge
        }

        public BrowserType GetBrowser()
        {
            StreamReader reader = File.OpenText("config.json");
            JObject j = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            string browsername = (string)j["browser"].ToString();
            string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            string s = "";
            BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), browsername);
            return browser;
        }
    }
}
