using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineExam.DatabaseHelper;
using OnlineExam.NUnitTests.APIClients.Models;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APINewsClient
    {
        RestClient client = new RestClient("http://localhost:55842");

        public List<NewsAPIModel> Get()
        {
            var request = new RestRequest($"/api/news", Method.GET);
            var response = client.Execute(request);
            string jsonString = response.Content;
            List<NewsAPIModel> result = JsonConvert.DeserializeObject<List<NewsAPIModel>>(jsonString);
            return result;
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