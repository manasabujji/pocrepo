using Newtonsoft.Json;
using Sujitha_POC.BrowserInitialization;

namespace Sujitha_POC.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("executionType")]
        public string ExecutionType { get; set; }

        [JsonProperty("executionEnv")]
        public string ExecutionEnv { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

    }
}
