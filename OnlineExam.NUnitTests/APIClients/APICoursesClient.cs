using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APICoursesClient
    {
        RestClient client = new RestClient("http://localhost:55842");

        public void Get()
        {
            var request = new RestRequest($"/api/Course", Method.GET);
            var response = client.Execute(request);
        }

        public HttpStatusCode Post(Object obj)
        {
            var request = new RestRequest($"/api/Course", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(obj);
            var response = client.Execute(request);
            return response.StatusCode;
        }

        //public void Delete(int CourseId)
        //{
        //    var request = new RestRequest($"/api/Course/delete", Method.DELETE);
        //    client.Delete(request);
        //    client.Execute(request);
        //}
    }
}