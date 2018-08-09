using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineExam.DatabaseHelper;
using OnlineExam.Framework;
using OnlineExam.NUnitTests.APIClients.Models;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APINewsClient
    {
        RestClient client = new RestClient(BaseSettings.Fields.Url);

        public RestResultTyped<List<NewsAPIModel>> Get()
        {
            var request = new RestRequest($"/api/news", Method.GET);
            var response = client.Execute(request);
            string jsonString = response.Content;
            List<NewsAPIModel> result = JsonConvert.DeserializeObject<List<NewsAPIModel>>(jsonString);
            return new RestResultTyped<List<NewsAPIModel>>()
            {
                Code = response.StatusCode,
                Data = result
            };
        }

        public HttpStatusCode Post(Object obj)
        {
            var request = new RestRequest($"/api/news", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(obj);
            var result = client.Execute(request);
            return result.StatusCode;
        }
    }
}