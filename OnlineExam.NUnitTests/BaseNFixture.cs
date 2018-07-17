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

        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{
        //    DatabaseHelper.Helper.BackupDatabase(PATH + @"\MainBackup.bak", "OnlineExamDB", @"DESKTOP-424095L\SQLEXPRESS");
        //    htmlReporter = new ExtentHtmlReporter(Constants.REPORT_PATH);
        //    extentReports = new ExtentReports();
        //    extentReports.AttachReporter(htmlReporter);

        //}

        //[OneTimeTearDown]
        //public void OneTimeTearDown()
        //{
        //    extentReports.Flush();
        //    DatabaseHelper.Helper.RestoreDatabase(PATH + @"\MainBackup.bak", "OnlineExamDB", @"DESKTOP-424095L\SQLEXPRESS");
        //    //DatabaseHelper.RollbackDatabase();
        //}
    }
}