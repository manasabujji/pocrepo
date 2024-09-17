using Microsoft.Extensions.Configuration;

namespace Sujitha_POC.Config
{
    public class ConfigReader
    {
        public static void FrameworkSetting()
        {
            TestSettings testSettings = new TestSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName).AddJsonFile("appSettings.json");

            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(testSettings);

            Settings.ExecutionType = testSettings.ExecutionType;
            if (Settings.ExecutionType.Equals("Local"))
            {
                Settings.ExecutionEnv = testSettings.ExecutionEnv;
            }
            else
            {
                Settings.ExecutionEnv = Environment.GetEnvironmentVariable("executionEnv", EnvironmentVariableTarget.Process);
            }
            Settings.BrowserType = testSettings.Browser;

            var envDataSection = configurationRoot.GetSection("EnvironmentData");
            foreach (IConfigurationSection section in envDataSection.GetChildren())
            {
                var key = section.GetValue<string>("environment");
                if (key == Settings.ExecutionEnv)
                {
                    Settings.URL = section.GetValue<string>("url");
                    Settings.TestType = section.GetValue<string>("testType");
                }

            }


        }
    }
}
