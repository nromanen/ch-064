using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APIUsersClient
    {
        RestClient client = new RestClient("http://localhost:55842/swagger/v1");

       
        public string PostChange(string json,string parameter)
        {
            var request = new RestRequest("/api/users/change/name", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("text/json", json, ParameterType.RequestBody);

            
            IRestResponse response = client.Execute(request);
            var result = response.StatusDescription;
            return result;
        }
    }
}