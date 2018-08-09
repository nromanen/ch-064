using System.IO;
using Newtonsoft.Json;


namespace OnlineExam.Framework
{
    public enum Browsers
    {
        Chrome,
        Phantom,
        Edge,
        IE
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
        public static BasicSettingsFields Fields;

        static BaseSettings()
        {
            using (StreamReader file = File.OpenText(CurrentPath.JSON_PATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                Fields = (BasicSettingsFields)serializer.Deserialize(file, typeof(BasicSettingsFields));
            }
        }
    }
}