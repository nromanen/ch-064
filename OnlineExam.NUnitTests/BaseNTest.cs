using System;
using System.Diagnostics;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace OnlineExam.Tests
{
    public abstract class BaseTest
    {
        protected ExtendedWebDriver driver;
        public ExtentHtmlReporter htmlReporter;
        public ExtentReports extentReports;
        public ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DatabaseHelper.BackupDatabase();
            htmlReporter = new ExtentHtmlReporter(Constants.REPORT_PATH);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extentReports.Flush();
            DatabaseHelper.RollbackDatabase();
        }

     

        //[SetUp]
        //public void SetUp()
        //{
            
        //}


        public void BeginTest()
        {
            driver = DriversFabric.InitChrome();
            driver.Maximize();
            driver.GoToUrl(Constants.HOME_URL);
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


        public void UITest(Action action)
        {
            try
            {
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType;
                var name = method.Name;
                //    fixture.test = fixture.extentReports.CreateTest($"{name}");

                action();

                //      fixture.test.Log(Status.Pass, $"{name} test successfully executed");
            }
            catch (Exception e)
            {
                var screenshotPathWithDate = driver.TakesScreenshotWithDate(Constants.SCREEN_SHOT_PATH,
                    Constants.SCREEN_SHOT, ScreenshotImageFormat.Png);
                //      var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPathWithDate).Build();
                //      fixture.test.AddScreenCaptureFromPath(screenshotPathWithDate);
                //       fixture.test.Fail($"Message: {e.Message} " + "\n<br>\n<br>" + $"StackTrace: {e.StackTrace}");
                throw;
            }
        }

        public void Wait(int time)
        {
            Thread.Sleep(time);
        }

        [TearDown]
        public virtual void TearDown()
        {
            driver?.Dispose();
        }
    }
}