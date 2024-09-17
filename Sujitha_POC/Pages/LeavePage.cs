using OpenQA.Selenium;
using Sujitha_POC.Drivers;
using Sujitha_POC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sujitha_POC.Pages
{
    public class LeavePage : BasePage
    {
        public DriverHelper _driverHelper;

        public LeavePage(DriverHelper driverHelper) : base(driverHelper)
        {
            _driverHelper = driverHelper;
        }
        By AssignLeaveButton = By.XPath("//a[text()='Assign Leave']");
        By EmployeeNameTextbox = By.XPath("//label[text()='Employee Name']/..//following-sibling::div//input");
        By EmployeeNameDropdown = By.XPath("//div[@role='listbox']");
        public void ClickAssignLeaveButton()
        {
            Click(AssignLeaveButton);
        }
        public void EnterEmployeeNameTextbox(string name)
        {
            SendKey(EmployeeNameTextbox,name);
        }
        public void SelectEmployeeName()
        {
            Click(EmployeeNameDropdown);
        }
    }
}
