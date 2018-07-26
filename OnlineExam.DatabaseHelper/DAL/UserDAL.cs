using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class UserDAL
    {
        public AspNetUsers GetUserById(string id)
        {
            using (var ctx = new DataModel())
            {
                //var result = ctx.AspNetUsers.Where(searchUser => searchUser.Id.Equals(id)).First();
                var result = ctx.AspNetUsers.Find(id);
                return result;
               
            }
        }
    }
}
