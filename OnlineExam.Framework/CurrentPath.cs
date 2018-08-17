using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework
{
    public static class CurrentPath
    {
        public static string PATH = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string ACTUAL_PATH = PATH.Substring(0, PATH.LastIndexOf("bin"));
        public static string PROJECT_PATH = new Uri(ACTUAL_PATH).LocalPath;
        public static string REPORT_PATH = PROJECT_PATH + "Reports\\MyOwnReport.html";
        public static string SCREEN_SHOT_PATH = PROJECT_PATH + "\\Screenshots\\";
        public static string BACKUP_PATH = PROJECT_PATH + @"Backup\OnlineExamDB.bak";
        public static string JSON_PATH = new Uri(ACTUAL_PATH).LocalPath + "..\\ConfigFile.json";
        public static string TEST_PARAMS_PATH = PROJECT_PATH + "..\\TestParams\\";
        public static string IMAGE_PATH = PROJECT_PATH + @"..\\OnlineExam.Pages\Sources\Example.jpg";
    }
}