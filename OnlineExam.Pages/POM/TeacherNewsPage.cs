using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineExam.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class TeacherNewsPage : NewsPage
    {

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


        public TeacherNewsPage CreateArticle(string title, string name, string article)
        {
            WaitWhileNotClickableWebElement(CreateArticleReference);
            CreateArticleReference.Click();
            ChooseFileInput.Click();
            SendKeys.SendWait(CurrentPath.IMAGE_PATH);
            SendKeys.SendWait("{Enter}");
            CourseNameInput.SendKeys(name);
            TitleTextArea.SendKeys(title);
            ArticleTextArea.SendKeys(article);
            WaitWhileNotClickableWebElement(PublishInput);
            PublishInput.Click();
            return ConstructPage<TeacherNewsPage>();
        }
    }
}
