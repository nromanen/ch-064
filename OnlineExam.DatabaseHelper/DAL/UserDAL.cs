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
    }
}