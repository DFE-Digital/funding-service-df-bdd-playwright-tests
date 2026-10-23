using Microsoft.Extensions.Configuration;

namespace DigitalForm_AutomationSuite.Helper
{
    public class ConfigHelper
    {
        private static Microsoft.Extensions.Configuration.IConfiguration _config;

        public ConfigHelper()
        {
            var a = Directory.GetCurrentDirectory();
            _config = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\MIRFAN1\\OneDrive - Department for Education\\Desktop\\dfe\\Manual\\Automation execution\\DigitalForm_Automation\\")
                .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables() // For CI/CD overrides
                .Build();
        }

        public static string GetValue(string key)
        {
            var a = Directory.GetCurrentDirectory();
            return _config[key];
        }
    }
}


