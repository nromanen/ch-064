using OnlineExam.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExam.Pages.POM
{
    public class ChangeCourseOwnerPage : BasePage
    {

        public ChangeCourseOwnerPage() { }

        [FindsBy(How = How.Id, Using = "ResultTeacherId")]
        private IWebElement TeacherSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        private IWebElement BtnOK { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container > p:nth-child(2)")]
        private IWebElement CurrentOwner { get; set; }

        public string GetOwnerName(ResourceManager rm)
        {
            return OwnerParser(CurrentOwner.Text, rm);
        }

        public void ChangeOwner(ResourceManager rm)
        {
            SelectElement value = new SelectElement(TeacherSelect);
            string teacher1 = "teacher@gmail.com";
            string teacher2 = "teacher2@gmail.com";
            string result = OwnerParser(CurrentOwner.Text, rm);
            if (result.Contains(teacher1))
            {
                value.SelectByText(teacher2);
            }
            else
            {
                value.SelectByText(teacher1);
            }
            BtnOK.Click();
        }

        public string OwnerParser(string text, ResourceManager rm)
        {
            if (text.Contains(rm.GetString("ownerStringToDel")))
            {
                var str = text.Replace(rm.GetString("ownerStringToDel"), "").Trim();
                return str;
            }
            return String.Empty;
        }

        public bool IsOwnerChanges(string pastOwner, ResourceManager rm)
        {
            var page = ConstructPage<ViewCoursesPage>();
            var block = page.GetBlocks();
            if (block != null)
            {
                var singleBlock = block.FirstOrDefault(x => x.GetCourseName().Equals("Owner", StringComparison.OrdinalIgnoreCase));
                if (singleBlock != null)
                {
                    singleBlock.ClickBtnChangeOwner();
                    var changeOwner = ConstructPage<ChangeCourseOwnerPage>();
                    var currenOwner = changeOwner.GetOwnerName(rm);
                    if (currenOwner.Equals(pastOwner))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
