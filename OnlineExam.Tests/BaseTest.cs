using System;
using AventStack.ExtentReports;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public abstract class  BaseTest :DatabaseHelper, IDisposable
    //, IClassFixture<BaseFixture>,ICollectionFixture<MyTestCollection>
    {
        protected ITestOutput output;
        //protected IWebDriver driver;
        protected ExtendedWebDriver driver;
        protected BaseFixture fixture;

        public BaseTest()
        {
            //extendedDriver = DriversFabric.InitChrome();
            driver = DriversFabric.InitChrome();
        }
        //[SetUp]
        public BaseTest(BaseFixture fixture)
        {
         //   BackupDatabase(); // <- Uncoment to create db backup
            driver = DriversFabric.InitChrome();
            this.fixture = fixture;
        }


        public void BeginTest()
        {
            driver.GoToUrl(Constants.HOME_URL);
        }

        public void NavigateTo(string url)
        {
            driver.GoToUrl(url);
        }

        public T ConstructPage<T>()where T: BasePage, new()
        {
            var page = new T();
            page.SetDriver(driver);

            try
            {
                PageFactory.InitElements(driver.SeleniumContext, page);
                return page;
            } catch (Exception e)
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
                action();
            } catch (Exception e)
            {
                //driver.TakeScreenshot("");
                throw;
            }
        }
        //[TearDown]
        public virtual void Dispose()
        {

            // var status = TestContext.CurrentContext.Result.Outcome.Status;
             var status = fixture.test.Status;
            //TestContext.CurrentContext.Result.StackTrace
            //   var stackTrace = "<pre>" + fixture.test.GetModel().ExceptionInfo.StackTrace.ToString() + "</pre>"; //TODO


            //TestContext.CurrentContext.Result.Message;
            // var errorMessage = fixture.test.GetModel().ExceptionInfo.Exception.ToString();

            //     if (status != Status.Pass)
            //    {
            //  fixture.test.Log(status, "<><><><><><><><>");// stackTrace + errorMessage);
            //   }


            // fixture.extentReports.RemoveTest(fixture.test);

            //var status = fixture.test.Status;
            //var stacktrace = string.IsNullOrEmpty(fixture.test.GetModel().ExceptionInfo.StackTrace)
            //    ? ""
            //    : string.Format("{0}", fixture.test.GetModel().ExceptionInfo.StackTrace);
            //Status logstatus = Status.Fail;
            //if (status != Status.Pass)
            //{
            //    fixture.test.Log(logstatus, "Test ended with "); //+ logstatus + stacktrace);
            //}

            //switch (status)
            //{
            //    case TestStatus.Failed:
            //        logstatus = Status.Fail;
            //        break;
            //    case TestStatus.Inconclusive:
            //        logstatus = Status.Warning;
            //        break;
            //    case TestStatus.Skipped:
            //        logstatus = Status.Skip;
            //        break;
            //    default:
            //        logstatus = Status.Pass;
            //        break;
            //}

            //_test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //_extent.Flush();

         //   RollbackDatabase(); //<- uncoment to load db backup
            driver?.Dispose();
        }
    }
}