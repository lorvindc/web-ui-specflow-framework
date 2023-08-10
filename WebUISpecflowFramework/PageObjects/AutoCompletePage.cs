using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// AutoCompletePage PageObject Class
    /// </summary>
    public class AutoCompletePage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompletePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public AutoCompletePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Auto Complete Multiple Input Textbox
        /// </summary>
        /// <returns>Auto Complete Multiple Input Textbox element</returns>
        public IWebElement GetAutoCompleteMultipleInputTextbox()
        {
            return WaitForElementById(wait, "autoCompleteMultipleInput");
        }

        /// <summary>
        /// Gets the Auto Complete Single Input Textbox
        /// </summary>
        /// <returns>Auto Complete Single Input Textbox element</returns>
        public IWebElement GetAutoCompleteSingleInputTextbox()
        {
            return WaitForElementById(wait, "autoCompleteSingleInput");
        }

        /// <summary>
        /// Gets the Auto Complete Multiple Textbox Container
        /// </summary>
        /// <returns>Auto Complete Textbox Container element</returns>
        public IEnumerable<IWebElement> GetSelectedItems()
        {
            return WaitForElementById(wait, "autoCompleteMultipleContainer")
                .FindElements(By.XPath("//div[contains(@class, 'auto-complete__multi-value__label')]"));
        }

        /// <summary>
        /// Gets the Auto Complete Single Textbox Container
        /// </summary>
        /// <returns>Auto Complete Single Textbox Container element</returns>
        public IWebElement GetSelectedItem()
        {
            return WaitForElementByXPath(wait, "//div[contains(@class, 'auto-complete__single-value')]");
        }
    }
}
