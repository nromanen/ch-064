using OnlineExam.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DatabaseHelper.DAL
{
    public class NewsDAL
    {
        private static string conection = "data source = CH784\\SQLEXPRESS; initial catalog = OnlineExamDB; integrated security = True; MultipleActiveResultSets = True;";
        //"Server=(localdb)\\mssqllocaldb;Database=Main;Trusted_Connection=True;MultipleActiveResultSets=true";
      

        public List<News> GetNews()
        {
            using (var ctx = new DataModel(conection))
            {
                var result = ctx.News.ToList();
                return result;
            }

        }

        public News GetNewsByTitle(string title)
        {
            using (var ctx = new DataModel(BaseSettings.Fields.ConnectionString))
            {
                var result = ctx.News.Include("Courses").FirstOrDefault(c => c.Title == title);
                return result;
            }
        }
        

    }
}
