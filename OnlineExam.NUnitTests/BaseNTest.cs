using System;
using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class BaseNTest
    {
        protected ExtendedWebDriver driver;

        [OneTimeSetUp]
        public void test1()
        {
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void test2()
        {
            ExtentManager.Instance.Flush();
        }


        [SetUp]
        public virtual void SetUp()
        {
            driver = DriversFabric.InitChrome();
            driver.Maximize();
            driver.GoToUrl(Constants.HOME_URL);
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        public void NavigateTo(string url)
        {
            driver.GoToUrl(url);
        }

        public T ConstructPage<T>() where T : BasePage, new()
        {
            var page = new T();
            page.SetDriver(driver);

            try
            {
                PageFactory.InitElements(driver.SeleniumContext, page);
                return page;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public T ConstructPageElement<T>(IWebElement pageElement) where T : BasePageElement, new()
        {
            var element = new T();
            element.SetDriver(driver);
            try
            {
                PageFactory.InitElements(pageElement, element);
                return element;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public void Wait(int time)
        {
            Thread.Sleep(time);
        }

        [TearDown]
        public virtual void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var screenshotPathWithDate = driver.TakesScreenshotWithDate(Constants.SCREEN_SHOT_PATH,
                        Constants.SCREEN_SHOT, ScreenshotImageFormat.Png);
                    var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPathWithDate).Build();
                    ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenshotPathWithDate);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            ExtentTestManager.GetTest().Log(logstatus,
                "Test ended with " + logstatus + "\n<br>\n<br>  " + stacktrace + "\n<br>\n<br> " + errorMessage);


            driver?.Dispose();
        }
    }
}