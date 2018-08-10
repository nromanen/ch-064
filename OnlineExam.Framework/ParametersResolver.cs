using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework
{
    public class ParametersResolver
    {
        public static T Resolve <T> (string json)
        {
            var jsonPath = CurrentPath.TEST_PARAMS_PATH + json;
            var convertJson = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<T>(convertJson);
        }
    }
}
