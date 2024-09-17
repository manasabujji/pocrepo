using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Sujitha_POC.Config;

namespace Sujitha_POC.Utility
{
    public class Reports
    {
        private static ExtentReports _extent;
        public static ExtentReports GenerateReport()
        {
            ConfigReader.FrameworkSetting();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + Path.DirectorySeparatorChar + "ExecutionResult_" + DateTime.Now.ToString("ddMMyyyy") + Path.DirectorySeparatorChar;
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("URL", Settings.URL.ToString());
            _extent.AddSystemInfo("Environment", Settings.ExecutionEnv.ToString());
            _extent.AddSystemInfo("Machine", Environment.MachineName);
            _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            return _extent;
        }
    }
}
