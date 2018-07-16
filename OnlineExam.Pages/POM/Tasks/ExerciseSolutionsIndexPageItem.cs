using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.Tasks
{
    public class ExerciseSolutionsIndexPageItem : BasePageElement
    {

        public ExerciseSolutionsIndexPageItem()
        {        }

        public ExerciseSolutionsIndexPageItem(IWebElement searchContext) : base(searchContext)
        {        }

        [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement UserEmail { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement SolutionStatus { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(3) > form > button")]
        public IWebElement ReviewButton { get; set; }

        /// <summary>
        /// "review" button will be clicked on
        /// </summary>
        public void ClickOnReviewButton()
        {
            ReviewButton.Click();
        }
        /// <summary>
        /// return user's email
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            return UserEmail.Text;
        }
        /// <summary>
        /// return status of solution
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            return SolutionStatus.Text;
        }
    }
}
