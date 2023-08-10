namespace WebUISpecflowFramework.Selenium
{
    public class WebDriverBuilderFactory
    {
        /// <summary>
        /// Identifies the Chrome browser.
        /// </summary>
        public const string Chrome = "Chrome";

        /// <summary>
        /// Identifies the firefox browser.
        /// </summary>
        public const string FireFox = "Firefox";

        /// <summary>
        /// Makes the web driver factory.
        /// </summary>
        /// <param name="browserType">the type of browser to create</param>
        /// <returns>the driver factory instance</returns>
        public static IWebDriverBuilder MakeWebDriverBuilder(string browserType)
        {
            var factories = new Dictionary<string, Func<IWebDriverBuilder>>
            {
                { Chrome, () => new ChromeDriverBuilder() },
                { FireFox, () => new FirefoxDriverBuilder() }
            };

            if (!factories.ContainsKey(browserType))
            {
                throw new InvalidOperationException($"The browser type is unknown: {browserType}");
            }

            return factories[browserType]();
        }
    }
}
