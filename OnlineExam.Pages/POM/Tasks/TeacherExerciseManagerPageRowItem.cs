using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM.Tasks
{
    public class TeacherExerciseManagerPageRowItem :BasePageElement
    {

        public TeacherExerciseManagerPageRowItem() { }

    public TeacherExerciseManagerPageRowItem(IWebElement searchContext) : base(searchContext)
    {
    }

        /////////////AVAILABLE

    [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
    public IWebElement TaskName { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
    public IWebElement CreationDate { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(3)")]
    public IWebElement UpdateDate { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(4)")]
    public IWebElement CourseName { get; set; }


        [FindsBy(How = How.CssSelector, Using = ":nth-child(5) > form > a")]
        public IWebElement ChangeButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = ":nth-child(5) > form > button")]
        public IWebElement DeleteButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = ":nth-child(5) > button")]
        public IWebElement SolutionButton { get; set; }


        public void ClickOnChangeButton()
        {
            ChangeButton.Click();
        }

        public void ClickOnDeleteButton()
        {
            DeleteButton.Click();
        }

        public void ClickOnSolutionButton()
        {
            SolutionButton.Click();
        }


        public void ClickOntaskname()
        {
            TaskName.Click();
        }

    public string TEMP_GetName()
    {
        return TaskName.Text;
    }

    public string TEMP_GetCreationDate()
    {
        return CreationDate.Text;
    }

    public string TEMP_GetUpdateDate()
    {
        return UpdateDate.Text;
    }

    public string TEMP_GetCourseName()
    {
        return CourseName.Text;
    }

        ///////////////////////DELETED

        [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement DELETED_CourseName { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement DELETED_TaskName { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(3) > form > button")]
        public IWebElement RecoverButton { get; set; }

        public void ClickOnRecoverButton()
        {
            RecoverButton.Click();
        }

        public string Get_DELETED_CourseName()
        {
            return DELETED_CourseName.Text;
        }

        public string Get_DELETED_TaskName()
        {
            return DELETED_TaskName.Text;
        }

        public void ClickOnDELETEDTaskName()
        {
            DELETED_TaskName.Click();
        }


    }
}
