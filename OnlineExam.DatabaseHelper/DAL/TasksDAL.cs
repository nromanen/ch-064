using OnlineExam.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class TasksDAL
    {
        string ConnectionString = BaseSettings.Fields.ConnectionString;

        public bool IsTaskPresentedByName(string TaskName)
        {
            using (DataModel db = new DataModel(ConnectionString))
            {
                bool f = false;
                var tasks = db.Exercises;
                foreach (Exercises e in tasks)
                {
                    if (e.TaskName.Equals(TaskName))
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
