using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Sujitha_POC.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sujitha_POC.Utility
{
    public class BasePage : PageInstance
    {
        private DriverHelper _driverHelper;
        public BasePage(DriverHelper driverHelper) : base(driverHelper)
        { 
             _driverHelper = driverHelper;
        }
        protected const int DefaultTimeout = 30;

        //Wait for element
        protected IWebElement WaitOn(By by, int timeout = DefaultTimeout)
        {
            var wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes((typeof(NoSuchElementException)));
            wait.IgnoreExceptionTypes((typeof(ElementNotVisibleException)));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

            }
            catch (Exception)
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            }
        }

        //Sending value to field
        protected void SendKey(By by, string value, int timeout = DefaultTimeout)
        {
            WaitOn(by, timeout).SendKeys(value);
            Console.WriteLine($"{DateTime.Now}:Entered text as '{value}' using By Reference:" + by);
        }

        //Click action
        protected void Click(By by, int timeout = DefaultTimeout)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    WaitOn(by, timeout).Click();
                    Console.WriteLine($"{DateTime.Now}:Clicked the element using By Reference:" + by);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    _driverHelper.Driver.Navigate().Refresh();
                }
                attempts++;
            }
        }

        //Element Displayed
        protected bool IsDisplayed(By by, int timeout = DefaultTimeout)
        {
            try
            {
                if (WaitOn(by, timeout).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) { Console.WriteLine($"{DateTime.Now} Elemet not visible using reference {by}\nMessage : {e.Message}"); return false; }
        }
    }
}
