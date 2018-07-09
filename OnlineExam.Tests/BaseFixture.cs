using System;
using System.Reflection;
using OnlineExam.Framework;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using Xunit;

namespace OnlineExam.Tests
{
    public class BaseFixture : IDisposable
    {
        public ExtentReports extent;
        public ExtentTest test;
     
        public string path;
        public string actualPath;
        public string projectPath;
        public string reportPath;

        //[OneTimeSetUp]
        public BaseFixture()
        {
            path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            actualPath = path.Substring(0, path.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            reportPath = projectPath + "Reports\\MyOwnReport.html";
            extent = new ExtentReports(reportPath, true);
            extent
                .AddSystemInfo("Host Name", "http://localhost:55842/")
                .AddSystemInfo("Environment", "QA");
            extent.LoadConfig(projectPath + "extent-config.xml");
        }

        //[OneTimeTearDown]
        public void Dispose()
        {
            extent.Flush();
            extent.Close();
        }
    }
}