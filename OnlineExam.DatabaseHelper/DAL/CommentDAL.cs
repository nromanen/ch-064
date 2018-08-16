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

        string ConnectionString = BaseSettings.Fields.ConnectionString;

        public bool IsTaskPresentedByEmail(string Email)
        {
            using (DataModel db = new DataModel(ConnectionString))
            {
                bool f = false;
                var comments = db.Comments;
                foreach (Comments c in comments)
                {
                    if (c.UserName.Equals(Email))
                    {
                        f = true;
                        return f;
                    }
                }
                return f;
            }
        }

        public bool IsTaskPresentedByCommentText(string text)
        {
            using (DataModel db = new DataModel(ConnectionString))
            {
                bool f = false;
                var comments = db.Comments;
                foreach (Comments c in comments)
                {
                    if (c.CommentText.Equals(text))
                    {
                        f = true;
                        return f;
                    }
                }
                return f;
            }
        }


        public bool IsTaskPresentedByCreatingDate(string date)
        {
            using (DataModel db = new DataModel(ConnectionString))
            {
                bool f = false;
                var comments = db.Comments;
                foreach (Comments c in comments)
                {
                    if (c.CreationDateTime.Equals(date))
                    {
                        f = true;
                        return f;
                    }
                }
                return f;
            }
        }


    }
}
