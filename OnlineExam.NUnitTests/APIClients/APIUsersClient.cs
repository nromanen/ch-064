using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APIUsersClient
    {
        RestClient client = new RestClient(BaseSettings.Fields.Url);

       
        public RestResult PostChange(Object obj,string parameter)
        {
            var request = new RestRequest($"/api/users/change/{parameter}" ,Method.POST);
            request.AddHeader("content-type", "application/json");

           
            request.AddJsonBody(obj);
            IRestResponse response = client.Execute(request);
            var result = response.StatusCode;
            return new RestResult()
            {
                Code = response.StatusCode,
            };
        }
    }
}