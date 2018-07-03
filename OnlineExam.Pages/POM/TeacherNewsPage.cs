using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class TeacherNewsPage : NewsPage
    {
        public TeacherNewsPage(IWebDriver driver) : base(driver)
        {
        }

        public TeacherNewsPage()
        {

        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a.btn.btn-default")]
        public IWebElement CreateArticleReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#openModal > div > form > div:nth-child(1) > input[type=\"file\"]")]
        public IWebElement ChooseFileInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#openModal > div > form > div:nth-child(2) > input[type=\"text\"]")]
        public IWebElement CourseNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement TitleTextArea { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "#openModal > div > form > div:nth-child(2) > textarea.form-control.text-area-article")]
        public IWebElement ArticleTextArea { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#openModal > div > form > input[type=\"submit\"]:nth-child(3)")]
        public IWebElement PublishInput { get; set; }
        
        public TeacherNewsPage CreateArticle()
        {
            CreateArticleReference.Click();
            Thread.Sleep(1000);
            ChooseFileInput.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait(@"D:\ch-064\OnlineExam.Pages\POM\Example.jpg");
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(10000);
            CourseNameInput.SendKeys("New name");
            TitleTextArea.SendKeys("New title");
            ArticleTextArea.SendKeys("New article");
            PublishInput.Click();
            return ConstructPage<TeacherNewsPage>();
        }
    }
}
