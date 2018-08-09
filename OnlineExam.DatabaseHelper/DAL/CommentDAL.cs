using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class CommentDAL
    {
    
        public Comments GetCommentById(int id)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var result = ctx.Comments.Find(id);
                return result;
            }
        }

        public Comments GetCommentByCommentText(string commentText)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var result = ctx.Comments.FirstOrDefault(c => c.CommentText == commentText);
                return result;
            }
        }
    }
}
