using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebUISpecflowFramework.PageObjects
{
    /// <summary>
    /// UploadDownloadPage PageObject Class
    /// </summary>
    public class UploadDownloadPage : PageObject
    {
        private readonly WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadDownloadPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver</param>
        public UploadDownloadPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets the upload button element
        /// </summary>
        /// <returns>Upload button element</returns>
        public IWebElement GetUploadButton()
        {
            return WaitForElementById(wait, "uploadFile");
        }

        /// <summary>
        /// Gets the download button element
        /// </summary>
        /// <returns>download button element</returns>
        public IWebElement GetDownloadButton()
        {
            return WaitForElementById(wait, "downloadButton");
        }

        /// <summary>
        /// Gets the file path
        /// </summary>
        /// <returns>file path element</returns>
        public IWebElement GetFilePath()
        {
            return WaitForElementById(wait, "uploadedFilePath");
        }
    }
}
