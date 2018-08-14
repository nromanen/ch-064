using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OnlineExam.Framework;

namespace OnlineExam.NUnitTests
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance
        {
            get { return _lazy.Value; }
        }

        static ExtentManager()
        {
            var htmlReporter = new ExtentHtmlReporter(CurrentPath.REPORT_PATH);
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "Extent/NUnit Samples";
            htmlReporter.Configuration().ReportName = "Extent/NUnit Samples";
            htmlReporter.Configuration().Theme = Theme.Standard;
            htmlReporter.config().setAutoCreateRelativePathMedia(true);
            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}