using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OnlineExam.Framework;
using OpenQA.Selenium;

namespace OnlineExam.NUnitTests.APITests
{
    public abstract class BaseAPITest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
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
            TestContext.Out.WriteLine("\n<br> " + "Test started " + TestContext.CurrentContext.Test.Name);
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
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

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
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

            TestContext.Out.WriteLine("\n<br> " + "Test ended " + TestContext.CurrentContext.Test.Name);

            var isStackTraceNullOrEmpty = string.IsNullOrEmpty(stacktrace);
            var isErrorMessageNullOrEmpty = string.IsNullOrEmpty(errorMessage);

            ExtentTestManager.GetTest().Log(logstatus,
                "Test ended with " + logstatus +
                (!isStackTraceNullOrEmpty ? "\n<br>\n<br>" + stacktrace + "\n<br>\n<br>" : string.Empty)
                + (!isErrorMessageNullOrEmpty ? errorMessage + "\n<br>\n<br>" : string.Empty)
                + output);
        }
    }
}