using System;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OnlineExam.Framework;
using Xunit;

namespace OnlineExam.Tests
{
    public class BaseFixture : IDisposable
    {
        public ExtentHtmlReporter htmlReporter;
        public ExtentReports extentReports;
        public ExtentTest test;


        //[OneTimeSetUp]
        public BaseFixture()
        {
            DatabaseHelper.BackupDatabase();
            htmlReporter = new ExtentHtmlReporter(Constants.REPORT_PATH);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        //[OneTimeTearDown]
        public void Dispose()
        {
            extentReports.Flush();
            DatabaseHelper.RollbackDatabase();
        }
    }
}