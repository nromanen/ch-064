using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class ChangeCourseOwnerPage : BasePage
    {
        /// <summary>
        /// http://localhost:55842/CourseManagement/ChangeOwner/1
        /// </summary>

        public ChangeCourseOwnerPage(IWebDriver driver) : base(driver){}

        [FindsBy(How = How.Id, Using = "ResultTeacherId")]
        public IWebElement TeacherSelect { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-default")]
        public IWebElement btnOK { get; set; }
    }
}
