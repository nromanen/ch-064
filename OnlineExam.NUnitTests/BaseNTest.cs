using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;

namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class BaseNTest
    {
        protected ExtendedWebDriver driver;
        protected ResourceManager resxManager;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var browser = TestContext.Parameters.Get("Browser");
            if (!string.IsNullOrEmpty(browser))
            {
                BaseSettings.Fields.Browser = (Browsers) Enum.Parse(typeof(Browsers), browser);
            }

            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentManager.Instance.Flush();
        }


        [SetUp]
        public virtual void SetUp()
        {
            driver = DriversFabric.Init();
            driver.Maximize();
            driver.GoToUrl(BaseSettings.Fields.Url);
            var header = ConstructPage<Header>();
            resxManager = header.GetCurrentLanguage();
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            LogProgress("Test started " + TestContext.CurrentContext.Test.Name);
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
            var output = TestExecutionContext.CurrentContext.CurrentResult.Output;
            Status logstatus;
            MediaEntityModelProvider mediaModel = null;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var screenshotPathWithDate = driver.TakesScreenshotWithDate(CurrentPath.SCREEN_SHOT_PATH,
                        Constants.SCREEN_SHOT, ScreenshotImageFormat.Png);
                    //mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPathWithDate).Build();
                    using (Image image = Image.FromFile(screenshotPathWithDate))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();

                            // Convert byte[] to Base64 String
                            string base64String = Convert.ToBase64String(imageBytes);
                            mediaModel = MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64String).Build();
                        }
                    }
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


            LogProgress("Test ended " + TestContext.CurrentContext.Test.Name);

            var isStackTraceNullOrEmpty = string.IsNullOrEmpty(stacktrace);
            var isErrorMessageNullOrEmpty = string.IsNullOrEmpty(errorMessage);

            ExtentTestManager.GetTest().Log(logstatus,
                "Test ended with " + logstatus +
                (!isStackTraceNullOrEmpty ? "\n<br>\n<br>" + stacktrace + "\n<br>\n<br>" : "\n<br>\n<br>")
                + (!isErrorMessageNullOrEmpty ? errorMessage + "\n<br>\n<br>" : string.Empty)
                + output, mediaModel);

            driver?.Dispose();
        }

        public void LogProgress(string message)
        {
            TestContext.Out.WriteLine("\n<br> " + message);
        }
    }
}