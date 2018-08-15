using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = ctx.AspNetUsers.FirstOrDefault(c => c.Email == email);
                return result;
            }
        }

        public string GetRoleOfUserByEmail(string email)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var user = GetUserByEmail(email);
                var id = user.Id;
            //    var role = ctx.AspNetRoles.FirstOrDefault(c => c.Name)
                return "";
            }
        }
    }
}