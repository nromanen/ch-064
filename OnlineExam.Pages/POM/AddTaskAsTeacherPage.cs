using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    class AddTaskAsTeacherPage : BasePage
    {
        public AddTaskAsTeacherPage(IWebDriver driver) : base(driver)
        {
        }

  
        [FindsBy(How = How.Id, Using = "CourseId")]
        public IWebElement ListofCoursesInAddTaskAsTeacherPage { get; set; }


        public void ChooseCourseAddTaskAsTeacherPage(string CourseName)
        {
            ListofCoursesInAddTaskAsTeacherPage.Click();
            var selectElement = new SelectElement(CourseId);
            selectElement.SelectByText(CourseName);

            //// select the drop down list
            //var education = driver.FindElement(By.Name("education"));
            ////create select element object 
            //var selectElement = new SelectElement(education);

            ////select by value
            //selectElement.SelectByValue("Jr.High");
            //// select by text
            //selectElement.SelectByText("HighSchool");


        }
    }
}
