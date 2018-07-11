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

        /// <summary>
        /// "Change" button will be clicked on
        /// </summary>
        public void ClickOnChangeButton()
        {
            ChangeButton.Click();
        }
        /// <summary>
        /// "Delete" button will be clicked on
        /// </summary>
        public void ClickOnDeleteButton()
        {
            DeleteButton.Click();
        }
        /// <summary>
        /// "Solution" button will be clicked on
        /// </summary>
        public void ClickOnSolutionButton()
        {
            SolutionButton.Click();
        }

        /// <summary>
        /// Task name will be clicked on
        /// </summary>
        public void ClickOntaskname()
        {
            TaskName.Click();
        }
        /// <summary>
        /// return name of our task
        /// </summary>
        /// <returns></returns>
    public string TEMP_GetName()
    {
        return TaskName.Text;
    }
        /// <summary>
        /// return creation date of our task
        /// </summary>
        /// <returns></returns>
        public string TEMP_GetCreationDate()
    {
        return CreationDate.Text;
    }
        /// <summary>
        /// return upgrade date of our task
        /// </summary>
        /// <returns></returns>
    public string TEMP_GetUpdateDate()
    {
        return UpdateDate.Text;
    }
        /// <summary>
        /// return course name of our task
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// "recover" button will be clicked on
        /// </summary>
        public void ClickOnRecoverButton()
        {
            RecoverButton.Click();
        }
        /// <summary>
        /// return course name of our deleted task
        /// </summary>
        /// <returns></returns>
        public string Get_DELETED_CourseName()
        {
            return DELETED_CourseName.Text;
        }
        /// <summary>
        /// return task name of our deleted task
        /// </summary>
        /// <returns></returns>
        public string Get_DELETED_TaskName()
        {
            return DELETED_TaskName.Text;
        }
        /// <summary>
        /// deleted task name will be clicked on
        /// </summary>
        public void ClickOnDELETEDTaskName()
        {
            DELETED_TaskName.Click();
        }


    }
}
