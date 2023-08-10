using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// ToolTipsPage PageObject Class
    /// </summary>
    public class ToolTipsPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolTipsPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public ToolTipsPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Tool Tip Button
        /// </summary>
        /// <returns>Tool Tip Button element</returns>
        public IWebElement GetToolTipButton()
        {
            return WaitForElementById(wait, "toolTipButton");
        }

        /// <summary>
        /// Gets the Tool Tip Textbox
        /// </summary>
        /// <returns>Tool Tip Textbox element</returns>
        public IWebElement GetToolTipTextbox()
        {
            return WaitForElementById(wait, "toolTipTextField");
        }

        /// <summary>
        /// Gets the Tool Tip Textbox
        /// </summary>
        /// <returns>Tool Tip Textbox element</returns>
        public IWebElement GetToolTipLink()
        {
            return WaitForElementByXPath(wait, "//a[text()='Contrary']");
        }
    }
}
