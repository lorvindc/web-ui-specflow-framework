using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// SortablePage PageObject Class
    /// </summary>
    public class SortablePage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortablePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public SortablePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Sortable element
        /// </summary>
        /// <returns>Sortable element</returns>
        public IWebElement GetSortableElementByIndex(int index)
        {
            return WaitForElementByXPath(wait, $"//div[@id='demo-tabpane-list']/div/div[{index}]");
        }

        /// <summary>
        /// Gets the Sortable element
        /// </summary>
        /// <returns>Sortable element</returns>
        public IWebElement GetListTab()
        {
            return WaitForElementById(wait, "demo-tab-list");
        }
    }
}
