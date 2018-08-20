using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineExam.Framework.Params;
using OpenQA.Selenium;

namespace OnlineExam.Framework
{
    public static class ParametersResolver
    {
        public static Dictionary<Type, string> DataFilesMap;

        static ParametersResolver()
        {
            DataFilesMap = new Dictionary<Type, string>();
            InitConfig();
        }

        public static void Configure<T>(string path)
        {
            DataFilesMap.Add(typeof(T), path);
        }

        public static void InitConfig()
        {
            Configure<NewsParams>("NewsParams.json");
            Configure<LoginParams>("LoginParams.json");
            Configure<AdminTestParams>("AdminTestParams.json");
            Configure<CreateCourseParams>("CreateCourseParams.json");
            Configure<DeleteCourseParams>("DeleteCourseParams.json");
            Configure<EditCourseParams>("EditCourseParams.json");
            Configure<HeaderTestParams>("HeaderTestParams.json");
            Configure<RegisterParams>("RegisterParams.json");
            Configure<SideBarTestParams>("SideBarTestParams.json");

        }

        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (DataFilesMap.ContainsKey(type))
            {
                return Resolve<T>(DataFilesMap[type]);
            }
            else
            {
                throw new NotFoundException($"No data file configured for type: {type.FullName}");
            }
        }

        public static T Resolve<T>(string jsonFile)
        {
            var path = CurrentPath.TEST_PARAMS_PATH + jsonFile;
            var json = File.ReadAllText(path);
            if(json.Contains("%GUID"))
            {
                json = json.Replace("%GUID", $"{Guid.NewGuid().ToString()}");
                return JsonConvert.DeserializeObject<T>(json);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}