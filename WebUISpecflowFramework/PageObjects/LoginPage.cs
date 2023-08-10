using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// LoginPage PageObject Class
    /// </summary>
    public class LoginPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public LoginPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Login Button element
        /// </summary>
        /// <returns>Login Button element</returns>
        public IWebElement GetLoginButton()
        {
            return WaitForElementById(wait, "login");
        }

        /// <summary>
        /// Gets the Username textbox element
        /// </summary>
        /// <returns>Username textbox element</returns>
        public IWebElement GetUsernameTextbox()
        {
            return WaitForElementById(wait, "userName");
        }

        /// <summary>
        /// Gets the Password element
        /// </summary>
        /// <returns>Password element</returns>
        public IWebElement GetPasswordTextbox()
        {
            return WaitForElementById(wait, "password");
        }

        /// <summary>
        /// Gets the Login Error Message element
        /// </summary>
        /// <returns>Login Error Message element</returns>
        public IWebElement GetLoginErrorMessage()
        {
            return WaitForElementByXPath(wait, "//div[@id='output']//p[@id='name']");
        }
    }
}
