using NUnit.Framework;
using Sujitha_POC.Config;
using Sujitha_POC.Drivers;
using Sujitha_POC.Helpers;
using Sujitha_POC.Pages;

namespace Sujitha_POC.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private DriverHelper driverhelper;
        private ScenarioContext _scenarioContext;
        public StepDefinitions(DriverHelper driver, ScenarioContext scenarioContext)
        {
            driverhelper = driver;
            _scenarioContext = scenarioContext;
        }
        [Given(@"Enter the Orange HRM Portal Login URL")]
        public void GivenEnterTheOrangeHRMPortalLoginURL()
        {
            driverhelper.Driver.Navigate().GoToUrl(Settings.URL);
        }

        [When(@"Enter the ""([^""]*)"",""([^""]*)"" and click on Login button")]
        public void WhenEnterTheAndClickOnLoginButton(string username, string password)
        {
            driverhelper.CurrentPage.As<LoginPage>().EnterUsername(username);
            driverhelper.CurrentPage.As<LoginPage>().EnterPassword(password);
            driverhelper.CurrentPage.As<LoginPage>().ClickLogin();
        }

        [Then(@"Verify moved to Dashboard page")]
        public void ThenVerifyMovedToDashboardPage()
        {
            Assert.That(driverhelper.CurrentPage.As<DashboardPage>().VerifyDashboardLabel(), Is.True, "Dashboard label is not present");
        }
        [Then(@"Click on the username dropdown and click on logout")]
        public void ThenClickOnTheUsernameDropdownAndClickOnLogout()
        {
            driverhelper.CurrentPage.As<DashboardPage>().ClickLogoutButton();
        }
        [Then(@"Verify logout and moved to login page")]
        public void ThenVerifyLogoutAndMovedToLoginPage()
        {
            Assert.That(driverhelper.CurrentPage.As<LoginPage>().VerifyLoginLabel(), Is.True, "Login label is not present");
        }

        [When(@"Login using ""([^""]*)"" with ""([^""]*)"" and click on Login button")]
        public void WhenLoginUsingWithAndClickOnLoginButton(string fileName, string UserType)
        {
            var inputData = new JsonHelper().ReadingInputData(UserType, fileName);
            _scenarioContext["testData"] = inputData;
            driverhelper.CurrentPage.As<LoginPage>().EnterUsername(inputData["username"].ToString());
            driverhelper.CurrentPage.As<LoginPage>().EnterPassword(inputData["password"].ToString());
            driverhelper.CurrentPage.As<LoginPage>().ClickLogin();
        }

        [Then(@"Verify moved to Dashboard page and click on logout")]
        public void ThenVerifyMovedToDashboardPageAndClickOnLogout()
        {
            throw new Exception("Testcase failed due to no such element");
        }


    }
}
