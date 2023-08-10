using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// CheckboxPage PageObject Class
    /// </summary>
    public class CheckboxPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckboxPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public CheckboxPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Full Name input field
        /// </summary>
        /// <returns>Full Name element</returns>
        public IWebElement GetExpandAllButton()
        {
            return WaitForElementByXPath(wait, "//button[@title='Expand all']");
        }

        /// <summary>
        /// Gets the checkbox element by name
        /// </summary>
        /// <returns>checkbox element</returns>
        public IWebElement GetCheckboxElementByName(string name)
        {
            return WaitForElementByXPath(wait, $"//span[text()='{name}']");
        }

        /// <summary>
        /// Gets the child checkbox elements by name
        /// </summary>
        /// <returns>checkbox elements</returns>
        public IEnumerable<IWebElement> GetChildCheckboxes(string name)
        {
            return GetCheckboxElementByName(name)
                .FindElements(By.XPath("//input[@type='checkbox']"));
        }
    }
}
