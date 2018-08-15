using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineExam.Framework
{
    public class ParametersResolver
    {
        public static T Resolve<T>(string jsonFile)
        {
            var path = CurrentPath.TEST_PARAMS_PATH + jsonFile;
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}