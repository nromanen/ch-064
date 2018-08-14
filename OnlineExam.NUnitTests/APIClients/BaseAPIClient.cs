using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class BaseAPIClient
    {
        public RestClient client = new RestClient(BaseSettings.Fields.Url);
    }
}