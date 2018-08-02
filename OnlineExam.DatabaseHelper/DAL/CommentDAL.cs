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
                                            //"Server=(localdb)\\mssqllocaldb;Database=Main;Trusted_Connection=True;MultipleActiveResultSets=true";
        public Comments GetCommentById(int id)
        {
            using (var ctx = new DataModel(conection))
            {
                var result = ctx.Comments.Find(id);
                return result;
            }
        }

        public Comments GetCommentByCommentText(string commentText)
        {
            using (var ctx = new DataModel(conection))
            {
                var result = ctx.Comments.Find(commentText);
                return result;
            }
        }
    }
}
