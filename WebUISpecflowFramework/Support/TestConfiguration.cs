using Microsoft.Extensions.Configuration;

namespace WebUISpecflowFramework.Support
{
    public class TestConfiguration
    {
        private const string ConfigurationFileName = "appsettings.Development.json";

        /// <summary>
        /// Initializes static members of the <see cref="TestConfiguration"/> class.
        /// </summary>
        static TestConfiguration()
        {
            var config = BuildConfiguration();
            TestConfig = config.GetSection("TestConfig");
        }

        /// <summary>
        /// Gets the Test Mode
        /// </summary>
        public static string TestMode => GetEnvironmentValue("TestMode");

        /// <summary>
        /// Gets the Target tUrl
        /// </summary>
        public static string TargetUrl => GetEnvironmentValue("TargetUrl");

        /// <summary>
        /// Gets the Selenium UI mode
        /// </summary>
        public static string SeleniumUiMode => GetEnvironmentValue("SeleniumUiMode");

        /// <summary>
        /// Gets the Browser Type of the Web Driver
        /// </summary>
        public static string BrowserType => GetEnvironmentValue("BrowserType");

        /// <summary>
        /// Gets the Username of the Test User
        /// </summary>
        public static string TestUsername => GetEnvironmentValue("TestUsername");

        /// <summary>
        /// Gets the Password of the Test User
        /// </summary>
        public static string TestPassword => GetEnvironmentValue("TestPassword");

        /// <summary>
        /// Builds the application configuration.
        /// </summary>
        /// <returns>The application configuration.</returns>
        public static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigurationFileName, optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private static IConfigurationSection TestConfig { get; }

        /// <summary>
        /// Used to get the values of environment parameters for testing. E.g Browser Width
        /// </summary>
        /// <param name="key"> The name stored in the environment to get the desired value from.</param>
        /// <returns>A value based on the parsed "key" </returns>
        private static string GetEnvironmentValue(string key)
        {
            var env = Environment.GetEnvironmentVariable(key);
            return env ?? TestConfig[key]!;
        }
    }
}
