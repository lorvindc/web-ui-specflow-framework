using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// Class for PageObject to retrieve PageObject elements
    /// </summary>
    public class PageObject
    {
        /// <summary>
        /// Wait for element using Xpath locator
        /// </summary>
        /// <param name="wait">WebDriverWait</param>
        /// <param name="xpath">Xpath locator of the element</param>
        /// <returns>WebElement</returns>
        public static IWebElement WaitForElementByXPath(WebDriverWait wait, string xpath)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.XPath(xpath)));
        }

        /// <summary>
        /// Wait for element using ID locator
        /// </summary>
        /// <param name="wait">WebDriverWait</param>
        /// <param name="id">ID locator of the element</param>
        /// <returns>WebElement</returns>
        public static IWebElement WaitForElementById(WebDriverWait wait, string id)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.Id(id)));
        }

        /// <summary>
        /// Wait for element using CSS locator
        /// </summary>
        /// <param name="wait">WebDriverWait</param>
        /// <param name="selector">selector locator of the element</param>
        /// <returns>WebElement</returns>
        public static IWebElement WaitForElementByCss(WebDriverWait wait, string selector)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.CssSelector(selector)));
        }

        /// <summary>
        /// Waits and returns the element sought by condition
        /// </summary>
        /// <param name="wait">Waiter object</param>
        /// <param name="condition">Condition of element to look for</param>
        /// <returns>IWebElement -  The found element</returns>
        private static IWebElement WaitForElement(WebDriverWait wait, Func<IWebDriver, IWebElement> condition)
        {
            try
            {
                return wait.Until(condition);
            }
            catch
            {
                return null!;
            }
        }
    }
}
