using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework
{ 
    public static class Constants
    {
        public const string HOME_URL = "http://localhost:55842";
        public const string ADMIN_EMAIL = "admin@gmail.com";
        public const string ADMIN_PASSWORD = "Admin_123";
        public const string TEACHER_EMAIL = "teacher@gmail.com";
        public const string TEACHER_PASSWORD = "Teacher_123";
        public const string STUDENT_EMAIL = "student@gmail.com";
        public const string STUDENT_PASSWORD = "Student_123";
        public const string STUDENT2_EMAIL = "student2@gmail.com";
        public const string VIKTOR_EMAIL = "viktor@gmail.com";
        public const string TEACHER = "Teacher";
        public const string STUDENT = "Student";
        public const string REGISTRATION_EMAIL = "example@gmail.com";
        public const string REGISTRATION_PASSWORD = "Example_123";
        public const string ENGLISH = "en";
        public const string UKRAINE = "uk";
        public const string SIGN_IN_ENGLISH = "SIGN IN";
        public const string SIGN_IN_UKRAINE = "ВХІД";
        public const string LOGIN_URL_CONTAINS = "Login";
        public const string REGISTRATION_URL_CONTAINS = "Register";
        public const string RATING_URL_CONTAINS = "UserRating";
        public const string COURSEMANAGEMENT_URL_CONTAINS = "CourseManagement";
        public const string CONTACTUS_URL_CONTAINS = "EmailMessages";
        public const string EXAMPLE_EMAIL = "example@gmail.com";
        public const string EXAMPLE_PASSWORD = "Example_123";
        public const string FAKE_EMAIL = "fake@gmail.com";
        public const string FAKE_PASSWORD = "Fake_123";
        public static string PATH = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string ACTUAL_PATH = PATH.Substring(0, PATH.LastIndexOf("bin"));
        public static string PROJECT_PATH = new Uri(ACTUAL_PATH).LocalPath;
        public static string REPORT_PATH = PROJECT_PATH + "Reports\\MyOwnReport.html";
        public static string SCREEN_SHOT_PATH = PROJECT_PATH + "\\Reports\\";
        public const string SCREEN_SHOT = "ScreenShot";
        public const string USER_FOR_DELETE_EMAIL = "UserForDelete@gmail.com";
        public const string USER_FOR_CHANGE_ROLE_EMAIL = "UserForChangeRole@gmail.com";
        public const string USER_PASSWORD = "User_123";
        public const string USER_FOR_CHANGE_EMAIL = "UserForChangeEmail@gmail.com";
        public const string USER_FOR_CHANGE_NAME = "UserForChangeName@gmail.com";
        public const string USER_FOR_CHANGE_PASSWORD = "UserForChangePassword@gmail.com";
    }
}