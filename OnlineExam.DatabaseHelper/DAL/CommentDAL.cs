using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class CommentDAL
    {
        private static string conection = "data source = DESKTOP-7VG2H7M\\SQLEXPRESS; initial catalog = OnlineExamDB; integrated security = True; MultipleActiveResultSets = True;";

        public Comments GetCommentById(string id)
        {
            using (var ctx = new DataModel(conection))
            {
                //var result = ctx.AspNetUsers.Where(searchUser => searchUser.Id.Equals(id)).First();
                var result = ctx.Comments.Find(id);
                return result;

            }
        }
    }
}
