using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// ProfilePage PageObject Class
    /// </summary>
    public class ProfilePage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public ProfilePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Logged In User element
        /// </summary>
        /// <returns>Logged In User element</returns>
        public IWebElement GetLoggedInUser()
        {
            return WaitForElementById(wait, "userName-value");
        }

        /// <summary>
        /// Gets the Logged In User element
        /// </summary>
        /// <returns>Logged In User element</returns>
        public IWebElement GetLogoutButton()
        {
            return WaitForElementByXPath(wait, "//button[text()='Log out']");
        }

        /// <summary>
        /// Gets the Profile Header element
        /// </summary>
        /// <returns>Profile Header element</returns>
        public IWebElement GetProfileHeader()
        {
            return WaitForElementByXPath(wait, "//div[contains(@class,'main-header') and text()='Profile']");
        }
    }
}
