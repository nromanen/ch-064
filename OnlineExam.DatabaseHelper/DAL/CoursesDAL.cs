using OnlineExam.Framework;
using System.Linq;


namespace OnlineExam.DatabaseHelper.DAL
{
    public class CoursesDAL
    {
        public Courses GetCourse()
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.Find();
                return result;
            }
        }

        public Courses GetCourseByCourseName(string Coursename)
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                //var result = ctx.Courses.Find(Coursename);
                var result = ctx.Courses.FirstOrDefault(c => c.Name == Coursename);
                return result;
            }
        }


        public Courses GetCourseById(int id)
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.First(c => c.Id == id);
                return result;
            }
        }

    }
}
