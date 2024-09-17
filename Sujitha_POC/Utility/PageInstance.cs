using Sujitha_POC.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Sujitha_POC.Utility
{
    public class PageInstance
    {
        private DriverHelper _driverHelper;

        public PageInstance(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }
        public TPage As<TPage>() where TPage : PageInstance
        {
            _driverHelper.CurrentPage = (TPage)Activator.CreateInstance(typeof(TPage), _driverHelper);
            return (TPage)_driverHelper.CurrentPage;
        }
    }
}
