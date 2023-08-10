using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// DatePickerPage PageObject Class
    /// </summary>
    public class DatePickerPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePickerPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public DatePickerPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the Select Date Input
        /// </summary>
        /// <returns>Select Date Input element</returns>
        public IWebElement GetSelectDateInput()
        {
            return WaitForElementById(wait, "datePickerMonthYearInput");
        }

        /// <summary>
        /// Gets the Select Date and Time Input
        /// </summary>
        /// <returns>Select Date and Time Input element</returns>
        public IWebElement GetDateAndTimeInput()
        {
            return WaitForElementById(wait, "dateAndTimePickerInput");
        }

        /// <summary>
        /// Gets the Year Dropdown
        /// </summary>
        /// <returns>Select Year dropdown element</returns>
        public IWebElement GetYearDropdown()
        {
            return WaitForElementByCss(wait, "div.react-datepicker__year-dropdown-container");
        }

        /// <summary>
        /// Gets the Year option
        /// </summary>
        /// <returns>Year option element</returns>
        public IWebElement GetYearOption(string year)
        {
            return WaitForElementByXPath(
                wait,
                $"//div[contains(@class, 'react-datepicker__year-option') and text()='{year}']");
        }

        /// <summary>
        /// Gets the Month Dropdown
        /// </summary>
        /// <returns>Month Dropdown element</returns>
        public IWebElement GetMonthDropdown()
        {
            return WaitForElementByCss(wait, "div.react-datepicker__month-dropdown-container");
        }

        /// <summary>
        /// Gets the Month option
        /// </summary>
        /// <returns>Month option element</returns>
        public IWebElement GetMonthOption(string month)
        {
            return WaitForElementByXPath(
                wait,
                $"//div[contains(@class, 'react-datepicker__month-option') and text()='{month}']");
        }

        /// <summary>
        /// Gets the Day option
        /// </summary>
        /// <returns>Day option element</returns>
        public IWebElement GetDayOption(string day)
        {
            return WaitForElementByXPath(
                wait,
                $"//div[contains(@class, 'react-datepicker__day')	and text()='{day}']");
        }

        /// <summary>
        /// Gets the Time option
        /// </summary>
        /// <returns>Time option element</returns>
        public IWebElement GetTimeOption(string time)
        {
            return WaitForElementByXPath(
                wait,
                $"//li[contains(@class, 'react-datepicker__time-list-item') and text()='{time}']");
        }
    }
}
