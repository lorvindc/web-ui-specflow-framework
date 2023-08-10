using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// AlertsPage PageObject Class
    /// </summary>
    public class AlertsPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertsPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public AlertsPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Alert Button element
        /// </summary>
        /// <returns>Alert Button element</returns>
        public IWebElement GetAlertButton()
        {
            return WaitForElementById(wait, "alertButton");
        }

        /// <summary>
        /// Gets the Timer Alert Button element
        /// </summary>
        /// <returns>Timer Alert Button element</returns>
        public IWebElement GetTimerAlertButton()
        {
            return WaitForElementById(wait, "timerAlertButton");
        }

        /// <summary>
        /// Gets the Confirm Button element
        /// </summary>
        /// <returns>Confirm Button element</returns>
        public IWebElement GetConfirmButton()
        {
            return WaitForElementById(wait, "confirmButton");
        }

        /// <summary>
        /// Gets the Confirm Result element
        /// </summary>
        /// <returns>Confirm Result element</returns>
        public IWebElement GetConfirmResult()
        {
            return WaitForElementById(wait, "confirmResult");
        }

        /// <summary>
        /// Gets the Prompt Button element
        /// </summary>
        /// <returns>Prompt Button element</returns>
        public IWebElement GetPromptButton()
        {
            return WaitForElementById(wait, "promtButton");
        }

        /// <summary>
        /// Gets the Prompt Result element
        /// </summary>
        /// <returns>Prompt Result element</returns>
        public IWebElement GetPromptResult()
        {
            return WaitForElementById(wait, "promptResult");
        }
    }
}
