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
        public News GetNewsById(int id)
        {
            using (var ctx = new DataModel(conection))
            {
                var result = ctx.News.Find(id);
                return result;
            }
        }

        public News GetNewsByTitle(string title)
        {
            using (var ctx = new DataModel(conection))
            {
                var result = ctx.News.First(c => c.Title == title);
                return result;
            }
        }
    }
}
