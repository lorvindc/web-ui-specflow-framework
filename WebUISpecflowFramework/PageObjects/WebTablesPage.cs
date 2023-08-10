using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// WebTablesPage PageObject Class
    /// </summary>
    public class WebTablesPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebTablesPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public WebTablesPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        

        /// <summary>
        /// Gets the child checkbox elements by name
        /// </summary>
        /// <returns>checkbox elements</returns>
        public IEnumerable<IWebElement> GetTableRows()
        {
            return GetWebTable().FindElements(By.XPath("//div[@role='row']"));
        }

        /// <summary>
        /// Gets the child checkbox elements by name
        /// </summary>
        /// <returns>checkbox elements</returns>
        public IWebElement GetTableRowByName(string name)
        {
            return WaitForElementByXPath(wait, $"//div[@role='row']/div[normalize-space(text())='{name}']/..");
        }

        /// <summary>
        /// Gets the child checkbox elements by name
        /// </summary>
        /// <returns>checkbox elements</returns>
        private IWebElement GetWebTable()
        {
            return WaitForElementByXPath(wait, "//div[@class='rt-table' and @role='grid']");
        }

        /// <summary>
        /// Gets the edit button element by name
        /// </summary>
        /// <returns>Edit button element</returns>
        public IWebElement GetUserEditButton(string username)
        {
            return WaitForElementByXPath(
                wait, 
                $"//div[normalize-space(.)='{username}']/..//div/span[@title='Edit']");
        }

        /// <summary>
        /// Gets the First Name input field
        /// </summary>
        /// <returns>First Name element</returns>
        public IWebElement GetFirstNameTextbox()
        {
            return WaitForElementById(wait, "firstName");
        }

        /// <summary>
        /// Gets the Last Name input field
        /// </summary>
        /// <returns>Last Name element</returns>
        public IWebElement GetLastNameTextbox()
        {
            return WaitForElementById(wait, "lastName");
        }

        /// <summary>
        /// Gets the Email input field
        /// </summary>
        /// <returns>Email element</returns>
        public IWebElement GetEmailTextbox()
        {
            return WaitForElementById(wait, "userEmail");
        }

        /// <summary>
        /// Gets the Age input field
        /// </summary>
        /// <returns>Age element</returns>
        public IWebElement GetAgeTextbox()
        {
            return WaitForElementById(wait, "age");
        }

        /// <summary>
        /// Gets the Salary input field
        /// </summary>
        /// <returns>Salary element</returns>
        public IWebElement GetSalaryTextbox()
        {
            return WaitForElementById(wait, "salary");
        }

        /// <summary>
        /// Gets the Department input field
        /// </summary>
        /// <returns>Department element</returns>
        public IWebElement GetDepartmentTextbox()
        {
            return WaitForElementById(wait, "department");
        }

        /// <summary>
        /// Gets the Submit button
        /// </summary>
        /// <returns>Submit element</returns>
        public IWebElement GetSubmitButton()
        {
            return WaitForElementById(wait, "submit");
        }
    }
}
