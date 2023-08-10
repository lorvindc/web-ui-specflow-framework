using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// ButtonsPage PageObject Class
    /// </summary>
    public class ButtonsPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonsPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public ButtonsPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the double click button element
        /// </summary>
        /// <returns>Double click button element</returns>
        public IWebElement GetDoubleClickButton()
        {
            return WaitForElementById(wait, "doubleClickBtn");
        }

        /// <summary>
        /// Gets the double click message element
        /// </summary>
        /// <returns>Double click message element</returns>
        public IWebElement GetDoubleClickMessage()
        {
            return WaitForElementById(wait, "doubleClickMessage");
        }

        /// <summary>
        /// Gets the right click button element
        /// </summary>
        /// <returns>Right click button element</returns>
        public IWebElement GetRightClickButton()
        {
            return WaitForElementById(wait, "rightClickBtn");
        }

        /// <summary>
        /// Gets the right click message element
        /// </summary>
        /// <returns>Right click message element</returns>
        public IWebElement GetRightClickMessage()
        {
            return WaitForElementById(wait, "rightClickMessage");
        }

        /// <summary>
        /// Gets the dynamic click button element
        /// </summary>
        /// <returns>Dynamic click button element</returns>
        public IWebElement GetDynamicClickButton()
        {
            return WaitForElementByXPath(wait, "//button[text()='Click Me']");
        }

        /// <summary>
        /// Gets the dynamic click message element
        /// </summary>
        /// <returns>Dynamic click message element</returns>
        public IWebElement GetDynamicClickMessage()
        {
            return WaitForElementById(wait, "dynamicClickMessage");
        }
    }
}
