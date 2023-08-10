using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace WebUISpecflowFramework.Selenium
{
    /// <summary>
    /// Class for the Firefox Web Driver builder
    /// </summary>
    public class FirefoxDriverBuilder : BaseDriverBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirefoxDriverBuilder"/> class.
        /// </summary>
        public FirefoxDriverBuilder() : base(new FirefoxOptions())
        {
        }

        private FirefoxOptions FirefoxOptions => (Options as FirefoxOptions)!;

        /// <inheritdoc/>
        public override IWebDriverBuilder SetHeadless()
        {
            FirefoxOptions.AddArgument("--headless");
            FirefoxOptions.AcceptInsecureCertificates = true;
            return this;
        }

        /// <inheritdoc/>
        protected override IWebDriver MakeLocalWebDriver()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var downloadPath = Path.GetFullPath(Path.Join(projectPath, @"..\TestFiles\Download\"));
            FirefoxOptions.SetPreference("security.sandbox.content.level", 5);
            FirefoxOptions.SetPreference("network.proxy.type", 0);
            FirefoxOptions.SetPreference("browser.download.folderList", 2);
            FirefoxOptions.SetPreference("browser.download.dir", downloadPath);
            FirefoxOptions.SetPreference("browser.download.useDownloadDir", true);
            FirefoxOptions.LogLevel = FirefoxDriverLogLevel.Info;
            FirefoxOptions.AcceptInsecureCertificates = true;

            var path = GetAssemblyPath();

            var driver = new FirefoxDriver(Path.GetDirectoryName(path), FirefoxOptions, CommandTimeout);

            return driver;
        }
    }
}
