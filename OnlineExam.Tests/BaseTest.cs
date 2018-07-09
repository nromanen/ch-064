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
    public abstract class BaseTest : DatabaseHelper, IDisposable
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
                action();
            }
            catch (Exception e)
            {
                var screenshotPathWithDate = driver.TakesScreenshotWithDate(Constants.ScreenShotPath,Constants.SCREEN_SHOT,ScreenshotImageFormat.Png);
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPathWithDate).Build();
                fixture.test.AddScreenCaptureFromPath(screenshotPathWithDate);
                fixture.test.Fail(e);
                throw;
            }
        }

        //[TearDown]
        public virtual void Dispose()
        {
            driver?.Dispose();
        }
    }
}