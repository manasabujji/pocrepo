using OpenQA.Selenium;
using Sujitha_POC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sujitha_POC.Drivers
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }
        public PageInstance CurrentPage { get; set; }
    }
}
