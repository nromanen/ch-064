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

        public string GetToken(string email,string password)
        {
            var loginRequest = new RestRequest("/token", Method.POST);
            loginRequest.AddParameter("grant_type", "password");
            loginRequest.AddParameter("username", email);
            loginRequest.AddParameter("password", password);
            var res = client.Execute<AuthResult>(loginRequest);
            return res.Data.access_token;
        }

        public class AuthResult
        {
            public string access_token { get; set; }
        }
    }
}