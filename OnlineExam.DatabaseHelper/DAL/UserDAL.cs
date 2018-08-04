using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class UserDAL
    {
        private static string conection = "data source = DESKTOP-424095L\\SQLEXPRESS; initial catalog = OnlineExamDB; integrated security = True; MultipleActiveResultSets = True;";


        public AspNetUsers GetUserById(string id)
        {
            using (var ctx = new DataModel(conection))
            {
                //var result = ctx.AspNetUsers.Where(searchUser => searchUser.Id.Equals(id)).First();
                var result = ctx.AspNetUsers.Find(id);
                return result;
               
            }
        }
    }
}
