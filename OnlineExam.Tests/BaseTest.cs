﻿using System;
using System.Diagnostics;
using System.Threading;
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
    public abstract class BaseTest : IDisposable
    {
        protected ITestOutput output;

        protected ExtendedWebDriver driver;
        protected BaseFixture fixture;

        public BaseTest()
        {
            driver = DriversFabric.InitChrome();
        }

        //[SetUp]
        public BaseTest(BaseFixture fixture)
        {
            driver = DriversFabric.InitChrome();
            driver.Maximize();
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
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType;
                var name = method.Name;
                fixture.test = fixture.extentReports.CreateTest($"{name}");

                action();

                fixture.test.Log(Status.Pass, $"{name} test successfully executed");
            }
            catch (Exception e)
            {
                var screenshotPathWithDate = driver.TakesScreenshotWithDate(Constants.SCREEN_SHOT_PATH,
                    Constants.SCREEN_SHOT, ScreenshotImageFormat.Png);
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPathWithDate).Build();
                fixture.test.AddScreenCaptureFromPath(screenshotPathWithDate);
                fixture.test.Fail($"Message: {e.Message} " + "\n<br>\n<br>" + $"StackTrace: {e.StackTrace}");
                throw;
            }
        }

		public void Wait(int time)
		{
			Thread.Sleep(time);
		}

		//[TearDown]
		public virtual void Dispose()
        {
            driver?.Dispose();
        }
    }
}