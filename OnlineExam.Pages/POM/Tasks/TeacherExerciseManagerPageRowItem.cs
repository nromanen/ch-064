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
    

    public TeacherExerciseManagerPageRowItem(IWebElement searchContext) : base(searchContext)
    {
    }

    [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
    public IWebElement TaskName { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
    public IWebElement CreationDate { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(3)")]
    public IWebElement UpdateDate { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(4)")]
    public IWebElement CourseName { get; set; }
    [FindsBy(How = How.CssSelector, Using = ":nth-child(5)")]
    public IWebElement AllButtons { get; set; }

      
        [FindsBy(How = How.CssSelector, Using = ":nth-child(3)")]
        public IWebElement RecoverButton { get; set; }




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



    }
}
