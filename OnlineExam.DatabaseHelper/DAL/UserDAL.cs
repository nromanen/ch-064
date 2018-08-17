using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class UserDAL
    {
        public AspNetUsers GetUserById(string id)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var result = ctx.AspNetUsers.Find(id);
                return result;
            }
        }

        public AspNetUsers GetUserByEmail(string email)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var result = ctx.AspNetUsers.Include("AspNetRoles").FirstOrDefault(c => c.Email == email);
                return result;
            }
        }

        public IEnumerable<string> GetRoleOfUserByEmail(string email)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var user = GetUserByEmail(email);
                var id = user.Id;
                var result = ctx.AspNetUsers.FirstOrDefault(c => c.Email == email).AspNetRoles.Select(x=>x.Name);
                return result;
            }
        }
    }
}