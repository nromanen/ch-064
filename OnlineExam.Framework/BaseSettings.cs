using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;

namespace OnlineExam.Framework
{
    public enum Browsers
    {
        Chrome,
        Phantom,
        Edge
    }

    public class BasicSettingsFields
    {
        public Browsers Browser { get; set; }
        public string Url { get; set; }
        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
    }

    public static class BaseSettings
    {
        public static BasicSettingsFields fields;

        static BaseSettings()
        {
            using (StreamReader file = File.OpenText(CurrentPath.JSON_PATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                fields = (BasicSettingsFields)serializer.Deserialize(file, typeof(BasicSettingsFields));
            }
        }

       
    }
}