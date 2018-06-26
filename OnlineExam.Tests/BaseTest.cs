using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExam.Tests
{
    public abstract class BaseTest
    {
        protected const string HOME_URL = "http://localhost:55842";
        protected const string ADMIN_EMAIL = "admin@gmail.com";
        protected const string ADMIN_PASSWORD = "Admin_123";
        protected const string TEACHER_EMAIL = "teacher@gmail.com";
        protected const string TEACHER_PASSWORD = "Teacher_123";
        protected const string STUDENT_EMAIL = "student@gmail.com";
        protected const string STUDENT_PASSWORD = "Student_123";// property config 



        protected IWebDriver driver;

        protected BaseTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(HOME_URL);
        }
    }
}