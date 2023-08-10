using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// BrowserWindowsPage PageObject Class
    /// </summary>
    public class BrowserWindowsPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserWindowsPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public BrowserWindowsPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the New Tab Button element
        /// </summary>
        /// <returns>New Tab Button element</returns>
        public IWebElement GetNewTabButton()
        {
            return WaitForElementById(wait, "tabButton");
        }

        /// <summary>
        /// Gets the New Tab heading element
        /// </summary>
        /// <returns>New New Tab heading element</returns>
        public IWebElement GetNewTabHeading()
        {
            return WaitForElementById(wait, "sampleHeading");
        }

        /// <summary>
        /// Gets the New Window Button element
        /// </summary>
        /// <returns>New Window Button element</returns>
        public IWebElement GetNewWindowButton()
        {
            return WaitForElementById(wait, "windowButton");
        }

        /// <summary>
        /// Gets the New Window Message Button element
        /// </summary>
        /// <returns>New Window Message Button element</returns>
        public IWebElement GetNewWindowMessageButton()
        {
            return WaitForElementById(wait, "messageWindowButton");
        }

        /*
        / TODO: Verified that new window is displayed, but cannot retrieve element in the new window DOM
        /// <summary>
        /// Gets the New Window Message body element
        /// </summary>
        /// <returns>New New Tab heading element</returns>
        public IWebElement GetNewWindowMessageBody()
        {
            return WaitForElementByXPath(wait, "//body");
        }
        */
    }
}
