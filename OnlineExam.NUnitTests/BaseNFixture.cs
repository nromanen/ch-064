using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using OnlineExam.Framework;

namespace OnlineExam.NUnitTests
{
    [SetUpFixture]
    public class BaseNFixture
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extentReports;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //DatabaseHelper.Helper.BackupDatabase();
            htmlReporter = new ExtentHtmlReporter(Constants.REPORT_PATH);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //DatabaseHelper.Helper.RestoreDatabase();
            extentReports.Flush();
        }
    }
}