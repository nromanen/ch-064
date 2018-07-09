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
    public abstract class  BaseTest :DatabaseHelper, IDisposable
    //, IClassFixture<BaseFixture>,ICollectionFixture<MyTestCollection>
    {
        //protected IWebDriver driver;
        protected ExtendedWebDriver driver;
        protected BaseFixture fixture;

        public BaseTest()
        {
            //extendedDriver = DriversFabric.InitChrome();
            driver = DriversFabric.InitChrome();
        }

        public BaseTest(BaseFixture fixture)
        {
            //BackupDatabase(); // <- Uncoment to create db backup
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

            //RollbackDatabase(); //<- uncoment to load db backup
            fixture.extent.EndTest(fixture.test);
            driver?.Dispose();
        }
    }
}