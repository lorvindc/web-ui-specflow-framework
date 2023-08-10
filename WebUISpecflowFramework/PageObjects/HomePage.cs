using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// Home PageObject Class
    /// </summary>
    public class HomePage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextboxPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public HomePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Elements card
        /// </summary>
        /// <returns>Elements card element</returns>
        public IWebElement GetElementsCard()
        {
            return GetCardByName("Elements");
        }

        /// <summary>
        /// Gets the AlertsFrameWindows card
        /// </summary>
        /// <returns>AlertsFrameWindows card element</returns>
        public IWebElement GetAlertsFrameWindowsCard()
        {
            return GetCardByName("Alerts, Frame & Windows");
        }

        /// <summary>
        /// Gets the Widgets card
        /// </summary>
        /// <returns>Widgets card element</returns>
        public IWebElement GetWidgetsCard()
        {
            return GetCardByName("Widgets");
        }

        /// <summary>
        /// Gets the Interactions card
        /// </summary>
        /// <returns>Interactions card element</returns>
        public IWebElement GetInteractionsCard()
        {
            return GetCardByName("Interactions");
        }

        /// <summary>
        /// Gets the Book Store Application card
        /// </summary>
        /// <returns>Book Store Application card element</returns>
        public IWebElement GetBookStoreApplicationCard()
        {
            return GetCardByName("Book Store Application");
        }

        /// <summary>
        /// Gets the Permanent Address input field
        /// </summary>
        /// <returns>Search Permanent Address element</returns>
        private IWebElement GetCardByName(string name)
        {
            return WaitForElementByXPath(
                wait,
                $"//div[contains(@class, 'top-card') and normalize-space(.)='{name}']");
        }
    }
}
