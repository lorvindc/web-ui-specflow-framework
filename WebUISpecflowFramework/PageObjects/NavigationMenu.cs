using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// Navigation Menu PageObject Class
    /// </summary>
    public class NavigationMenu : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationMenu"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public NavigationMenu(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Text Box Button
        /// </summary>
        /// <returns>Text Box Button element</returns>
        public IWebElement GetNavigationButtonByName(string name)
        {
            return WaitForElementByXPath(wait, $"//span[text()='{name}']");
        }
    }
}
