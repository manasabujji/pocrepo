using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sujitha_POC.Utility
{
    public class Screenshots
    {
        public static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + Path.DirectorySeparatorChar + "ExecutionResult_" + DateTime.Now.ToString("ddMMyyyy") + Path.DirectorySeparatorChar;

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            takesScreenshot.GetScreenshot().SaveAsFile(Path.Combine(path, scenarioContext.ScenarioInfo.Title + ".png"), ScreenshotImageFormat.Png);

            return Path.Combine(path, scenarioContext.ScenarioInfo.Title + ".png");

        }
        public static MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            return MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver,scenarioContext)).Build();
        }
    }
}
