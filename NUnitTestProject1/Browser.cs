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
        JObject j;
        private void ReadFromJson()
        {
            StreamReader reader = File.OpenText("config.json");
            j = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
        }

        public BrowserType GetBrowser()
        {
            ReadFromJson();
            string browsername = (string)j["Browser"].ToString();
            string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), browsername);
            return browser;
        }
        public bool WindowParams()
        {
            string ismax = (string)j["isMaximize"].ToString();
            return bool.Parse(ismax);
        }
        public int WindowWidth()
        {
            string width = (string)j["Width"].ToString();
            return int.Parse(width);
        }
        public int WindowHeigt()
        {
            string heigt = (string)j["Height"].ToString();
            return int.Parse(heigt);
        }
    }
}
