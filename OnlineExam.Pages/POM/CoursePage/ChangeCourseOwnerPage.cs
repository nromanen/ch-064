using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement btnOK { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container > p:nth-child(2)")]
        public IWebElement CurrentOwner { get; set; }

        public string GetOwner()
        {
            string result = OwnerParser(CurrentOwner.Text);
            MessageBox.Show(result);
            return result;
        }

        public void ChangeOwner(string newTeacher)
        {
            SelectElement selectedValue = new SelectElement(TeacherSelect);
            string wantedText = selectedValue.SelectedOption.Text;
            selectedValue.SelectByValue(newTeacher);
        }

        public void ChangeOwner()
        {
            SelectElement value = new SelectElement(TeacherSelect);
            string teacher1 = "teacher@gmail.com";
            string teacher2 = "teacher2@gmail.com";
            System.Windows.Forms.MessageBox.Show(CurrentOwner.Text);
            string result = OwnerParser(CurrentOwner.Text);
            if (result.Contains(teacher1))
            {
                value.SelectByText(teacher2);
            }
            else
            {
                value.SelectByText(teacher1);
            }
            btnOK.Click();
        }

        public string OwnerParser(string text)
        {
            string replaceENG = "Current owner:";
            string replaceUA = "Поточний власник:";
            if (text.Contains(replaceENG))
            {
                var str = text.Replace(replaceENG, "").Trim();
                return str;
            }
            if (text.Contains(replaceUA))
            {
                var str = text.Replace(replaceUA, "").Trim();
                return str;
            }
           
            return String.Empty;
        }
    }
}
