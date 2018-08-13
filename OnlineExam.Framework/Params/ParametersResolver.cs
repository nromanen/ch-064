using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework.Params
{
    public class ParametersResolver
    {
        public static T Resolve<T>(string fileName)
        {
            string path = CurrentPath.TEST_PARAMS_PATH + fileName;
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                T value = (T)serializer.Deserialize(file, typeof(T));
                return value;
            }
        }
    }
}
