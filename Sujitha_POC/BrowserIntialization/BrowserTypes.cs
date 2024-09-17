using MongoDB.Driver.Core.Misc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using Sujitha_POC.Config;
using Sujitha_POC.Drivers;
using Sujitha_POC.FileHandler;
using WebDriverManager.DriverConfigs.Impl;

namespace Sujitha_POC.BrowserInitialization
{
    public class BrowserTypes
    {
        private DriverHelper _driver;
        public BrowserTypes(DriverHelper driver)
        {
            _driver = driver;
        }
        public void InitializeBrowser()
        {
            OpenBrowser(Settings.BrowserType);
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            var DownloadLocation = FileLocations.GetFilesDownloadLoation();
            switch (browserType)
            {
                case BrowserType.Edge:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    edgeOptions.AddArguments("--browser.download.dir=" + DownloadLocation);
                    edgeOptions.AddUserProfilePreference("download.default_directory", DownloadLocation);
                    _driver.Driver = new EdgeDriver(edgeOptions);
                    break;
                case BrowserType.Chrome:
                    //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("start-maximized");
                    option.AddArgument("--disable-gpu");
                    option.AddArguments("--browser.download.dir=" + DownloadLocation);
                    option.AddUserProfilePreference("download.default_directory", DownloadLocation);
                    _driver.Driver = new ChromeDriver(option);
                    break;
                case BrowserType.ChromeRemote:
                    String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
                    String accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions capabilities = new ChromeOptions();
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("userName", username);
                    browserstackOptions.Add("accessKey", accessKey);
                    capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

                    ////_driver.Driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capabilities);
                    //String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
                    //String accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
                    //String buildName = Environment.GetEnvironmentVariable("BROWSERSTACK_BUILD_NAME");
                    //String local = Environment.GetEnvironmentVariable("BROWSERSTACK_LOCAL");
                    //String localIdentifier = Environment.GetEnvironmentVariable("BROWSERSTACK_LOCAL_IDENTIFIER");

                    //ChromeOptions capabilities = new ChromeOptions();
                    //Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    //browserstackOptions.Add("os", "Windows");
                    //browserstackOptions.Add("osVersion", "10");
                    //browserstackOptions.Add("sessionName", "BStack Build Name: " + buildName);
                    //browserstackOptions.Add("userName", username);
                    //browserstackOptions.Add("accessKey", accessKey);
                    //browserstackOptions.Add("seleniumVersion", "4.0.0");
                    //browserstackOptions.Add("local", local);
                    //browserstackOptions.Add("localIdentifier", localIdentifier);
                    //capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

                    _driver.Driver = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"), capabilities);
                    
                    break;
            }
        }
    }
}
