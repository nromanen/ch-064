using System;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using Xunit;
using Xunit.Sdk;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public abstract class  BaseTest :IDisposable
        //, IClassFixture<BaseFixture>,ICollectionFixture<MyTestCollection>
    {
  
        protected IWebDriver driver;
        protected BaseFixture fixture;
        protected ExtendedWebDriver extendedDriver;

        public BaseTest()
        {
            //extendedDriver = DriversFabric.InitChrome();
            driver = new ChromeDriver();
        }

        public BaseTest(BaseFixture fixture)
        {
            driver = new ChromeDriver();
            this.fixture = fixture;
        }


        public void BeginTest()
        {
            driver.Navigate().GoToUrl(Constants.HOME_URL);
        }

        public T ConstructPage<T>()where T: BasePage, new()
        {
            var page = new T();
            page.SetDriver(driver);

            try
            {
                PageFactory.InitElements(driver, page);
                return page;
            } catch (Exception e)
            {
                return null;
            }
        }

        public virtual void Dispose()
        {

            // var status = TestContext.CurrentContext.Result.Outcome.Status;
            var status = fixture.test.GetCurrentStatus();

            //TestContext.CurrentContext.Result.StackTrace
            var stackTrace = "<pre>" + "..." + "</pre>"; //TODO


            //TestContext.CurrentContext.Result.Message;
            var errorMessage = fixture.test.GetTest().Description;

            if (status != LogStatus.Pass)
            {
                fixture.test.Log(status, stackTrace + errorMessage);
            }


            fixture.extent.EndTest(fixture.test);
            driver?.Dispose();
            extendedDriver?.Dispose();
        }
    }
}