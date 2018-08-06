using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APICoursesClient
    {
        RestClient client = new RestClient(BaseSettings.fields.Url);

        public void Get()
        {
            var request = new RestRequest($"/api/Course", Method.GET);
            var response = client.Execute(request);
        }

        public void Post(Object obj)
        {
            var request = new RestRequest($"/api/Course", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(obj);
            client.Execute(request);
        }

        public void Delete(int CourseId)
        {
            var request = new RestRequest($"/api/Course/delete", Method.DELETE);
           // var respons = client.Delete(request);
            client.Delete(request);
        }
    }
}