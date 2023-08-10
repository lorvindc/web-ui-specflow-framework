using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// DroppablePage PageObject Class
    /// </summary>
    public class DroppablePage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="DroppablePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public DroppablePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Draggable element
        /// </summary>
        /// <returns>Draggable element</returns>
        public IWebElement GetDraggableElement()
        {
            return WaitForElementById(wait, "draggable");
        }

        /// <summary>
        /// Gets the Droppable element
        /// </summary>
        /// <returns>Droppable element</returns>
        public IWebElement GetDroppableElement()
        {
            return WaitForElementById(wait, "droppable");
        }
    }
}
