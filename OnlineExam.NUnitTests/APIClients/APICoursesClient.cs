using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineExam.Framework;
using OnlineExam.NUnitTests.APIClients.Models;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APICoursesClient
    {
        RestClient client = new RestClient(BaseSettings.Fields.Url);

        public RestResultTyped<List<CoursesAPIModel>> Get()
        {
            var request = new RestRequest($"/api/Course", Method.GET);
            var response = client.Execute(request);
            string jsonString = response.Content;
            List<CoursesAPIModel> result = JsonConvert.DeserializeObject<List<CoursesAPIModel>>(jsonString);
            return new RestResultTyped<List<CoursesAPIModel>>()
            {
                Code = response.StatusCode,
                Data = result
            };
        }
    

        public HttpStatusCode Post(Object obj)
        {
            var request = new RestRequest($"/api/Course", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(obj);
            var response = client.Execute(request);
            return response.StatusCode;
        }
    }
}