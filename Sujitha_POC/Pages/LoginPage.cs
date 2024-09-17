using OpenQA.Selenium;
using Sujitha_POC.Drivers;
using Sujitha_POC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sujitha_POC.Pages
{
    public class LoginPage : BasePage
    {
        public DriverHelper _driverHelper;
       
        public LoginPage(DriverHelper driverHelper) :base(driverHelper)
        {
            _driverHelper = driverHelper;
        }
        By UserNameTextbox = By.Name("username");
        By PasswordTextbox =By.Name("password");
        By LoginButton =By.XPath("//button[contains(@class,'login-button')]");
        By LoginLabel=By.XPath("//h5[text()='Login']");
        public void EnterUsername(string text)
        {
            SendKey(UserNameTextbox,text);   
        }
        public void EnterPassword(string text)
        {
            SendKey(PasswordTextbox, text);
        }
        public void ClickLogin()
        {
            Click(LoginButton);
        }
        public bool VerifyLoginLabel()
        {
             return IsDisplayed(LoginLabel);
        }
    }
}
