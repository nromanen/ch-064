using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
    class ShowExercisePage : BasePage
    {
        public ShowExercisePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.TagName, Using = "tr")]
        public IList<IWebElement> RowOfTdsTaskNamesListElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".rating")]
        public IList<IWebElement> CountOfStars { get; set; }



        List<int> numbers = new List<int>();


      

        public void ClickOnTasksButton(string TaskName)
        {
            foreach (var tr in RowOfTdsTaskNamesListElements)
            {
                var text = tr.FindElement(By.TagName("td")).Text;
                if (text.Equals(TaskName))
                {
                    tr.FindElement(By.CssSelector(".btn btn-sm btn-default")).Click();
                    break;
                }
            }
        }

        public bool IsTaskNameIsPresentedInTaskList(string TaskName)
        {
            foreach (var row in RowOfTdsTaskNamesListElements)
            {
                var text = row.FindElement(By.TagName("td")).Text;
                if (text.Equals(TaskName))
                {
                    return true;
                }
            }

            return false;
        }

        public void RatingOfTasks(int CountOfActiveStars)
        {
            foreach (var count in CountOfStars)
            {
                IList<IWebElement> activestars = count.FindElements(By.CssSelector(".star active"));

                if (activestars.Equals(CountOfActiveStars))
                {
                    
                }
            }
        }

    }
}
