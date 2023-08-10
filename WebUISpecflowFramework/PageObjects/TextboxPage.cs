using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// Textbox PageObject Class
    /// </summary>
    public class TextboxPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextboxPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public TextboxPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Full Name input field
        /// </summary>
        /// <returns>Full Name element</returns>
        public IWebElement GetFullNameTextbox()
        {
            return WaitForElementById(wait,"userName");
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
        /// Gets the Current Address input field
        /// </summary>
        /// <returns>Current Address element</returns>
        public IWebElement GetCurrentAddressTextArea()
        {
            return WaitForElementByXPath(wait, "//textarea[@id='currentAddress']");
        }

        /// <summary>
        /// Gets the Permanent Address input field
        /// </summary>
        /// <returns>Permanent Address element</returns>
        public IWebElement GetPermanentAddressTextArea()
        {
            return WaitForElementByXPath(wait, "//textarea[@id='permanentAddress']");
        }

        /// <summary>
        /// Gets the Submit button
        /// </summary>
        /// <returns>Submit button element</returns>
        public IWebElement GetSubmitButton()
        {
            return WaitForElementById(wait, "submit");
        }

        /// <summary>
        /// Gets the Name output field
        /// </summary>
        /// <returns>Full Name element</returns>
        public IWebElement GetOutputField(string field)
        {
            return WaitForElementByXPath(wait, $"//p[@id='{field}']");
        }

        public IWebElement GetEmailInputFieldError()
        {
            return WaitForElementByCss(wait, "input.field-error");
        }
    }
}
