using OpenQA.Selenium;
using Sujitha_POC.Drivers;
using Sujitha_POC.Utility;

namespace Sujitha_POC.Pages
{
    public class DashboardPage : BasePage
    {

        public DriverHelper _driverHelper;
        public DashboardPage(DriverHelper driverHelper) : base(driverHelper)
        {
            _driverHelper = driverHelper;
        }
        By DashboadLabel = By.XPath("//h6[text()='Dashboard']");
        By UserDropdown = By.XPath("//li[contains(@class,'userdropdown')]");
        By LogoutButton = By.XPath("//a[text()='Logout']");
        By LeaveButton = By.XPath("//span[text()='Leave']");

        public bool VerifyDashboardLabel()
        {
            return IsDisplayed(DashboadLabel);
        }
        public void ClickLogoutButton()
        {
            Click(UserDropdown);
            Click(LogoutButton);
        }
        public void ClickLeaveButton()
        {
            Click(LeaveButton);
        }
    }
}
