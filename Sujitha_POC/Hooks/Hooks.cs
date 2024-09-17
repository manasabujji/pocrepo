using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Sujitha_POC.BrowserInitialization;
using Sujitha_POC.Drivers;
using Sujitha_POC.Utility;

namespace Sujitha_POC.Hooks
{
    [Binding]
    public sealed class Hooks : BrowserTypes
    {
        private readonly DriverHelper driverHelper;
        private static ExtentReports _extent;
        private static ExtentTest _featureName;
        private readonly FeatureContext _featureContext;
        private ExtentTest _scenarioName;
        private ScenarioContext _scenarioContext;
        public Hooks(DriverHelper driver, FeatureContext featureContext, ScenarioContext scenarioContext): base(driver)
        {
            driverHelper = driver;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            driverHelper.CurrentPage = new PageInstance(driverHelper);
        }
        [BeforeTestRun]
        public static void GenerateReport()
        {
            _extent = Reports.GenerateReport();
        }

        [BeforeScenario]
        public void SetuUpBeforeScenario()
        {
            InitializeBrowser();
            //Get feature Name
            _featureName = _extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            //ScenarioName
            _scenarioName = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterEachStep()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = _scenarioContext.StepContext.StepInfo.Text;

            //When Scenario passed
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenarioName.CreateNode<Given>(stepName);
                else if (stepType == "When")
                    _scenarioName.CreateNode<When>(stepName);
                else if (stepType == "Then")
                    _scenarioName.CreateNode<Then>(stepName);
                else if (stepType == "And")
                    _scenarioName.CreateNode<And>(stepName);
            }
            //when Scenario failed
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _scenarioName.CreateNode<Given>(stepName).Fail(_scenarioContext.TestError.Message,Screenshots.CaptureScreenshot(driverHelper.Driver, _scenarioContext));
                else if (stepType == "When")
                    _scenarioName.CreateNode<When>(stepName).Fail(_scenarioContext.TestError.Message, Screenshots.CaptureScreenshot(driverHelper.Driver, _scenarioContext));
                else if (stepType == "Then")
                    _scenarioName.CreateNode<Then>(stepName).Fail(_scenarioContext.TestError.Message, Screenshots.CaptureScreenshot(driverHelper.Driver, _scenarioContext));
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driverHelper.Driver.Quit();
        }
        [AfterTestRun]
        public static void ReportTearDown()
        {
            _extent.Flush();
        }
    }
}