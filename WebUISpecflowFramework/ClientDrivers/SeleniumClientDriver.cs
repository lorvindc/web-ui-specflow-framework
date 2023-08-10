using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Text;
using WebUISpecflowFramework.PageObjects;
using WebUISpecflowFramework.Selenium;
using WebUISpecflowFramework.Support;
using System.Net.Http.Headers;

namespace WebUISpecflowFramework.ClientDrivers
{
    public class SeleniumClientDriver : IClientDriver
    {
        private IWebDriver webDriver = null!;
        private HomePage homePage = null!;
        private NavigationMenu navMenu = null!;
        private TextboxPage textboxPage = null!;
        private CheckboxPage checkboxPage = null!;
        private WebTablesPage webTablesPage = null!;
        private ButtonsPage buttonsPage = null!;
        private UploadDownloadPage uploadDownloadPage = null!;
        private BrowserWindowsPage browserWindowsPage = null!;
        private AlertsPage alertsPage = null!;
        private AutoCompletePage autoCompletePage = null!;
        private DatePickerPage datePickerPage = null!;
        private ToolTipsPage toolTipsPage = null!;
        private SortablePage sortablePage = null!;
        private DroppablePage droppablePage = null!;
        private LoginPage loginPage = null!;
        private ProfilePage profilePage = null!;

        private const string uploadFilePath = @"C:\fakepath\uploadFile.jpeg";
        private readonly string projectPath = Path.GetDirectoryName(
            Path.GetDirectoryName(Directory.GetCurrentDirectory()))!;
        private string parentWindow = null!;
        private string newWindow = null!;
        const string baseUrl = "https://demoqa.com/Account/v1/";
        private static string userId = string.Empty;
        private static string userToken = string.Empty;

        /// <inheritdoc />
        public void SetUp()
        {
            webDriver = MakeDriver();
            homePage = new HomePage(webDriver);
            navMenu = new NavigationMenu(webDriver);
            textboxPage = new TextboxPage(webDriver);
            checkboxPage = new CheckboxPage(webDriver);
            webTablesPage = new WebTablesPage(webDriver);
            buttonsPage = new ButtonsPage(webDriver);
            uploadDownloadPage = new UploadDownloadPage(webDriver);
            browserWindowsPage = new BrowserWindowsPage(webDriver);
            alertsPage = new AlertsPage(webDriver);
            autoCompletePage = new AutoCompletePage(webDriver);
            datePickerPage = new DatePickerPage(webDriver);
            toolTipsPage = new ToolTipsPage(webDriver);
            sortablePage = new SortablePage(webDriver);
            droppablePage = new DroppablePage(webDriver);
            loginPage = new LoginPage(webDriver);
            profilePage = new ProfilePage(webDriver);
            
            webDriver.Navigate().GoToUrl($"{TestConfiguration.TargetUrl}");
        }

        /// <inheritdoc />
        public void TearDown()
        {
            webDriver?.Close();
            webDriver?.Quit();
        }

        public void FillUpTextboxForm(Dictionary<string, string> user)
        {
            homePage.GetElementsCard().Click();
            navMenu.GetNavigationButtonByName("Text Box").Click();
            textboxPage.GetFullNameTextbox().SendKeys(user["name"]);
            textboxPage.GetEmailTextbox().SendKeys(user["email"]);
            textboxPage.GetCurrentAddressTextArea().SendKeys(user["currentAddress"]);
            textboxPage.GetPermanentAddressTextArea().SendKeys(user["permanentAddress"]);
            Thread.Sleep(5000);
        }

        public void SubmitTextboxForm()
        {
            textboxPage.GetSubmitButton().Click();
        }

        public string GetOutputUserField(string field)
        {
            var fieldValue = textboxPage.GetOutputField(field).Text;

            return fieldValue.Split(':').Last();
        }

        public void GoToHomePage()
        {
            webDriver.Navigate().GoToUrl($"{TestConfiguration.TargetUrl}");
        }

        public IWebElement GetEmailInputFieldError()
        {
            return textboxPage.GetEmailInputFieldError();
        }

        public void ExpandCheckBoxes()
        {
            homePage.GetElementsCard().Click();
            navMenu.GetNavigationButtonByName("Check Box").Click();
            checkboxPage.GetExpandAllButton().Click();
        }

        public void ToggleCheckbox(string name)
        {
            checkboxPage.GetCheckboxElementByName(name).Click();
        }

        public bool ChildCheckboxesChecked(string name)
        {
            var checkboxes = checkboxPage.GetChildCheckboxes(name);
            foreach (var checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    return false;
                }
            }

            return true;
        }

        public bool WebTableUserRegistered(string user)
        {
            homePage.GetElementsCard().Click();
            navMenu.GetNavigationButtonByName("Web Tables").Click();
            var tableRows = webTablesPage.GetTableRows();

            foreach (var row in tableRows)
            {
                var firstName = row.FindElement(By.XPath("//div[@role='gridcell'][1]")).Text;

                if (firstName.Equals(user))
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateWebTableRow(string username, Dictionary<string, string> user)
        {
            webTablesPage.GetUserEditButton(username).Click();
            webDriver.SwitchTo().ActiveElement();

            webTablesPage.GetFirstNameTextbox().Clear();
            webTablesPage.GetFirstNameTextbox().SendKeys(user["First Name"]);

            webTablesPage.GetLastNameTextbox().Clear();
            webTablesPage.GetLastNameTextbox().SendKeys(user["Last Name"]);

            webTablesPage.GetAgeTextbox().Clear();
            webTablesPage.GetAgeTextbox().SendKeys(user["Age"]);

            webTablesPage.GetEmailTextbox().Clear();
            webTablesPage.GetEmailTextbox().SendKeys(user["Email"]);

            webTablesPage.GetSalaryTextbox().Clear();
            webTablesPage.GetSalaryTextbox().SendKeys(user["Salary"]);

            webTablesPage.GetDepartmentTextbox().Clear();
            webTablesPage.GetDepartmentTextbox().SendKeys(user["Department"]);

            webTablesPage.GetSubmitButton().Click();
        }

        public void CheckWebTableUserUpdated(string updatedUsername, Dictionary<string, string> user)
        {
            var tableCells = webTablesPage
                .GetTableRowByName(updatedUsername)
                .FindElements(By.XPath("//div[@role='gridcell']"));

            var updatedUser = new Dictionary<string, string>
            {
                ["First Name"] = tableCells[0].Text,
                ["Last Name"] = tableCells[1].Text,
                ["Age"] = tableCells[2].Text,
                ["Email"] = tableCells[3].Text,
                ["Salary"] = tableCells[4].Text,
                ["Department"] = tableCells[5].Text,
            };

            updatedUser.Should().BeEquivalentTo(user);
        }

        public void CheckWebTableNotUpdated()
        {
            webTablesPage.GetFirstNameTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetLastNameTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetEmailTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetAgeTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetSalaryTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetDepartmentTextbox().Displayed.Should().BeTrue();
            webTablesPage.GetSubmitButton().Displayed.Should().BeTrue();
        }

        public void GoToButtonsPage()
        {
            homePage.GetElementsCard().Click();
            navMenu.GetNavigationButtonByName("Buttons").Click();
        }

        public void DoubleClickButton()
        {
            var doubleClickButton = buttonsPage.GetDoubleClickButton();
            var act = new Actions(webDriver);
            act.DoubleClick(doubleClickButton).Build().Perform();
        }

        public void RightClickButton()
        {
            var rightClickButton = buttonsPage.GetRightClickButton();
            var act = new Actions(webDriver);
            act.ContextClick(rightClickButton).Build().Perform();
        }

        public void DynamicClickButton()
        {
            var button = buttonsPage.GetDynamicClickButton();
            button.Click();
        }

        public string GetDoubleClickMessage()
        {
            return buttonsPage.GetDoubleClickMessage().Text;
        }

        public string GetRightClickMessage()
        {
            return buttonsPage.GetRightClickMessage().Text;
        }

        public string GetDynamicClickMessage()
        {
            return buttonsPage.GetDynamicClickMessage().Text;
        }

        public void GoToUploadDownloadPage()
        {
            homePage.GetElementsCard().Click();
            var uploadDownloadMenu = navMenu.GetNavigationButtonByName("Upload and Download");
            ScrollThenClick(uploadDownloadMenu);
        }

        public void UploadFile()
        {
            var uploadFile = uploadDownloadPage.GetUploadButton();
            var filePath = Path.GetFullPath(Path.Join(projectPath, @"..\TestFiles\uploadFile.jpeg"));

            uploadFile.SendKeys(filePath);
        }

        public void CheckFilePathDisplayed()
        {
            var filePath = uploadDownloadPage.GetFilePath().Text;
            filePath.Should().Be(uploadFilePath);
        }

        public void DownloadFile()
        {
            var downloadButton = uploadDownloadPage.GetDownloadButton();
            downloadButton.Click();
        }

        public void CheckDownloadedFile()
        {
            var downloadedFile = Path.GetFullPath(
                Path.Join(projectPath, @"..\TestFiles\Download\sampleFile.jpeg"));
            
            // Wait for file to be downloaded (for improvement, instead of explicit wait
            Thread.Sleep(TimeSpan.FromSeconds(5));
            File.Exists(downloadedFile).Should().BeTrue();
            
            // Cleanup download folder after verification
            if (File.Exists(downloadedFile))
            {
                File.Delete(downloadedFile);
            }
        }

        public void GoToBrowserWindowsPage()
        {
            homePage.GetAlertsFrameWindowsCard().Click();
            navMenu.GetNavigationButtonByName("Browser Windows").Click();
        }

        public void GoToAlertPage()
        {
            homePage.GetAlertsFrameWindowsCard().Click();
            navMenu.GetNavigationButtonByName("Alerts").Click();
        }

        public void ClickNewTab()
        {
            parentWindow = webDriver.CurrentWindowHandle;
            browserWindowsPage.GetNewTabButton().Click();
            newWindow = webDriver.WindowHandles.Last();
            webDriver.SwitchTo().Window(newWindow);
        }

        public void CheckNewTabOpened()
        {
            CheckNewWindowOrTabOpened();
        }

        public void ClickNewWindow()
        {
            parentWindow = webDriver.CurrentWindowHandle;
            browserWindowsPage.GetNewWindowButton().Click();
            newWindow = webDriver.WindowHandles.Last();
            webDriver.SwitchTo().Window(newWindow);
        }

        public void CheckNewWindowOpened()
        {
            CheckNewWindowOrTabOpened();
        }

        public void ClickNewMessage()
        {
            parentWindow = webDriver.CurrentWindowHandle;
            browserWindowsPage.GetNewWindowMessageButton().Click();
            newWindow = webDriver.WindowHandles.Last();
            webDriver.SwitchTo().Window(newWindow);
        }

        public void CheckNewMessageOpened()
        {
            webDriver.WindowHandles.Count.Should().Be(2);
            webDriver.CurrentWindowHandle.Should().Be(newWindow);
            // TODO: Verified that new window is displayed, but cannot retrieve element in the new window DOM
            // var windowMessage = browserWindowsPage.GetNewWindowMessageBody();
            // windowMessage.Displayed.Should().BeTrue();
            // windowMessage.Text.Should().Be(
            //    "Knowledge increases by sharing but not by saving. " +
            //    "Please share this website with your friends and in your organization.");
            webDriver.Close();
            webDriver.SwitchTo().Window(parentWindow);
        }

        public void ClickAlertButton()
        {
            alertsPage.GetAlertButton().Click();
        }

        public void ClickTimerAlertButton()
        {
            alertsPage.GetTimerAlertButton().Click();
        }

        public void ClickConfirmButton()
        {
            alertsPage.GetConfirmButton().Click();
        }

        public void ClickPromptButton()
        {
            alertsPage.GetPromptButton().Click();
        }
        public void CheckAlertPopupWindow()
        {
            CheckAlertWindow("You clicked a button");
        }
        
        public void CheckTimerAlertPopupWindow()
        {
            CheckAlertWindow("This alert appeared after 5 seconds");
        }

        public void CheckConfirmPopupWindow()
        {
            CheckAlertWindow("Do you confirm action?");
            alertsPage.GetConfirmResult().Text.Should().Be("You selected Ok");
        }

        public void CheckPromptWindow()
        {
            const string name = "John Doe";
            var alert = WaitForAlert(webDriver);
            alert.Text.Should().Be("Please enter your name");
            alert.SendKeys(name);
            alert.Accept();
            alertsPage.GetPromptResult().Text.Should().Be($"You entered {name}");
        }

        public void GoToAutoCompletePage()
        {
            homePage.GetWidgetsCard().Click();
            navMenu.GetNavigationButtonByName("Auto Complete").Click();
        }

        public void SpecifySecondOption(string[] hints)
        {
            foreach (var hint in hints)
            {
                var multipleInputTextbox = autoCompletePage.GetAutoCompleteMultipleInputTextbox();
                multipleInputTextbox.SendKeys(hint);
                multipleInputTextbox.SendKeys(Keys.Down);
                multipleInputTextbox.SendKeys(Keys.Enter);
            }
        }

        public List<string> GetSelectedOptions()
        {
            var selectedOptionElements = autoCompletePage.GetSelectedItems();
            var selectedOptions = selectedOptionElements.Select(element => element.Text).ToList();
            return selectedOptions;
        }

        public void SpecifyOption(string hint)
        {
            var singleInputTextbox = autoCompletePage.GetAutoCompleteSingleInputTextbox();
            singleInputTextbox.SendKeys(hint);
            singleInputTextbox.SendKeys(Keys.Enter);
        }

        public string GetSelectedOption()
        {
            var selectedOptionElement = autoCompletePage.GetSelectedItem();
            return selectedOptionElement.Text;
        }

        public void GotoDatePickerPage()
        {
            homePage.GetWidgetsCard().Click();
            navMenu.GetNavigationButtonByName("Date Picker").Click();
        }

        public void SpecifySelectDate(string inputDate)
        {
            var selectDate = datePickerPage.GetSelectDateInput();
            var text = selectDate.GetAttribute("value");
            for (var i = 0; i < text.Length; i++)
            {
                selectDate.SendKeys(Keys.Backspace);
            }
            selectDate.SendKeys(inputDate);
            selectDate.SendKeys(Keys.Enter);
        }

        public string GetSelectedDate()
        {
            return datePickerPage.GetSelectDateInput().GetAttribute("value");
        }

        public void SpecifySelectDateTime(string dateTime)
        {
            var selectDateTime = datePickerPage.GetDateAndTimeInput();
            var text = selectDateTime.GetAttribute("value");
            for (var i = 0; i < text.Length; i++)
            {
                selectDateTime.SendKeys(Keys.Backspace);
            }
            selectDateTime.SendKeys(dateTime);
            selectDateTime.SendKeys(Keys.Enter);
        }

        public string GetSelectedDateTime()
        {
            var selectDateTime = datePickerPage.GetDateAndTimeInput();
            return selectDateTime.GetAttribute("value");
        }

        public void SpecifySelectDateTimeUsingPicker(Dictionary<string, string?> dateTime)
        {
            var year = dateTime["Year"];
            var month= dateTime["Month"];
            var day= dateTime["Day"];
            var time= dateTime["Time"];
            datePickerPage.GetDateAndTimeInput().Click();
            datePickerPage.GetYearDropdown().Click();
            datePickerPage.GetYearOption(year!).Click();
            datePickerPage.GetMonthDropdown().Click();
            datePickerPage.GetMonthOption(month!).Click();
            datePickerPage.GetDayOption(day!).Click();
            datePickerPage.GetTimeOption(time!).Click();
        }

        public void GoToToolTipsPage()
        {
            homePage.GetWidgetsCard().Click();
            var toolTipMenu = navMenu.GetNavigationButtonByName("Tool Tips");
            ScrollThenClick(toolTipMenu);
        }

        public void HoverOverButton()
        {
            var toolTipButton = toolTipsPage.GetToolTipButton();
            MouseHover(toolTipButton);
        }

        public void CheckButtonToolTipDisplayed()
        {
            var toolTip = toolTipsPage.GetToolTipButton().GetAttribute("aria-describedby");
            toolTip.Should().Be("buttonToolTip");
        }

        public void HoverOverTextbox()
        {
            var toolTipTextbox = toolTipsPage.GetToolTipTextbox();
            MouseHover(toolTipTextbox);
        }

        public void CheckTextboxToolTipDisplayed()
        {
            var toolTip = toolTipsPage.GetToolTipTextbox().GetAttribute("aria-describedby");
            toolTip.Should().Be("textFieldToolTip");
        }

        public void HoverOverLink()
        {
            var toolTipLink = toolTipsPage.GetToolTipLink();
            MouseHover(toolTipLink);
        }

        public void CheckLinkToolTipDisplayed()
        {
            var toolTip = toolTipsPage.GetToolTipLink().GetAttribute("aria-describedby");
            toolTip.Should().Be("contraryTexToolTip");
        }

        public void GoToSortablePage()
        {
            homePage.GetInteractionsCard().Click();
            navMenu.GetNavigationButtonByName("Sortable").Click();
        }

        public void SortElements()
        {
            sortablePage.GetSortableElementByIndex(1).Displayed.Should().Be(true);
            sortablePage.GetSortableElementByIndex(2).Displayed.Should().Be(true);
            sortablePage.GetSortableElementByIndex(3).Displayed.Should().Be(true);
            sortablePage.GetSortableElementByIndex(4).Displayed.Should().Be(true);
            sortablePage.GetSortableElementByIndex(5).Displayed.Should().Be(true);
            sortablePage.GetSortableElementByIndex(6).Displayed.Should().Be(true);


            var action = new Actions(webDriver);
            action.DragAndDrop(sortablePage.GetSortableElementByIndex(2), sortablePage.GetListTab()).Perform();
            action.DragAndDrop(sortablePage.GetSortableElementByIndex(3), sortablePage.GetListTab()).Perform();
            action.DragAndDrop(sortablePage.GetSortableElementByIndex(4), sortablePage.GetListTab()).Perform();
            action.DragAndDrop(sortablePage.GetSortableElementByIndex(5), sortablePage.GetListTab()).Perform();
            action.DragAndDrop(sortablePage.GetSortableElementByIndex(6), sortablePage.GetListTab()).Perform();
        }

        public void CheckSortableElementInDescendingOrder()
        {
            sortablePage.GetSortableElementByIndex(1).Text.Should().Be("Six");
            sortablePage.GetSortableElementByIndex(2).Text.Should().Be("Five");
            sortablePage.GetSortableElementByIndex(3).Text.Should().Be("Four");
            sortablePage.GetSortableElementByIndex(4).Text.Should().Be("Three");
            sortablePage.GetSortableElementByIndex(5).Text.Should().Be("Two");
            sortablePage.GetSortableElementByIndex(6).Text.Should().Be("One");
        }

        public void GoToDroppablePage()
        {
            homePage.GetInteractionsCard().Click();
            var droppableMenu = navMenu.GetNavigationButtonByName("Droppable");
            ScrollThenClick(droppableMenu);
        }

        public void DragAndDropElement()
        {
            droppablePage.GetDraggableElement().Displayed.Should().BeTrue();
            droppablePage.GetDroppableElement().Displayed.Should().BeTrue();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var action = new Actions(webDriver);
            action.DragAndDrop(
                droppablePage.GetDraggableElement(),
                droppablePage.GetDroppableElement())
                .Perform();
        }

        public string GetDroppableMessage()
        {
            return droppablePage.GetDroppableElement().Text;
        }

        public void RegisterTestUser()
        {
            var uri = new Uri($"{baseUrl}/User");
            string jsonBody = $"{{ \"userName\": \"{TestConfiguration.TestUsername}\"," +
                              $" \"password\": \"{TestConfiguration.TestPassword}\" }}";

            var jsonToken = Post(uri, jsonBody);
            userId = jsonToken?["userID"]?.ToString()!;
        }

        public void DeleteTestUser()
        {
            var uri = new Uri($"{baseUrl}/GenerateToken");
            string jsonBody = $"{{ \"userName\": \"{TestConfiguration.TestUsername}\"," +
                              $" \"password\": \"{TestConfiguration.TestPassword}\" }}";

            var jsonToken = Post(uri, jsonBody);
            userToken = jsonToken?["token"]?.ToString()!;

            var deleteUri = new Uri($"{baseUrl}/User/{userId}");
            Delete(deleteUri);
        }

        public void GoToLoginPage()
        {
            var bookStoreCard = homePage.GetBookStoreApplicationCard();
            ScrollThenClick(bookStoreCard);
            var loginMenu = navMenu.GetNavigationButtonByName("Login");
            ScrollThenClick(loginMenu);
        }

        public void EnterLoginCredentials(string testUsername, string testPassword)
        {
            loginPage.GetUsernameTextbox().SendKeys(testUsername);
            loginPage.GetPasswordTextbox().SendKeys(testPassword);
            loginPage.GetLoginButton().Click();
        }

        public void CheckProfilePageDisplayed()
        {
            profilePage.GetProfileHeader().Displayed.Should().BeTrue();
            profilePage.GetLoggedInUser().Displayed.Should().BeTrue();
            profilePage.GetLoggedInUser().Text.Should().Be(TestConfiguration.TestUsername);
            profilePage.GetLogoutButton().Displayed.Should().BeTrue();
        }

        public string CheckLoginErrorMessage()
        {
            return loginPage.GetLoginErrorMessage().Text;
        }

        private void ScrollThenClick(IWebElement element)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        private void MouseHover(IWebElement element)
        {
            const string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                      "evObj.initMouseEvent(\"mouseover\",true, false, window, " +
                                      "0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                      "arguments[0].dispatchEvent(evObj);";

            var executor = (webDriver as IJavaScriptExecutor)!;
            executor?.ExecuteScript(javaScript, element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private void CheckNewWindowOrTabOpened()
        {
            webDriver.WindowHandles.Count.Should().Be(2);
            var heading = browserWindowsPage.GetNewTabHeading();
            heading.Displayed.Should().BeTrue();
            heading.Text.Should().Be("This is a sample page");
            webDriver.Close();
            webDriver.SwitchTo().Window(parentWindow);
        }

        private void CheckAlertWindow(string expectedAlertText)
        {
            var alert = WaitForAlert(webDriver);
            alert.Text.Should().Be(expectedAlertText);
            alert.Accept();
        }

        private static IAlert WaitForAlert(IWebDriver webDriver)
        {
            var i = 0;
            IAlert alert = null!;
            while (i++ < 10)
            {
                try
                {
                    alert = webDriver.SwitchTo().Alert();
                    break;
                }
                catch (NoAlertPresentException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }

            return alert;
        }

        private static JToken Post(Uri uri, string body)
        {
            using var client = new HttpClient();
            // Create the JSON request content
            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            try
            {
                // Send the POST request
                var response = client.PostAsync(uri, content).Result;

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Response Body:");
                    Console.WriteLine(responseBody);

                    using var stringReader = new StringReader(responseBody);
                    using var jsonReader = new JsonTextReader(stringReader)
                    {
                        DateParseHandling = DateParseHandling.None
                    };

                    var jsonToken = jsonReader.Read() ? JToken.ReadFrom(jsonReader) : null;
                    return jsonToken!;
                }

                Console.WriteLine($"Error: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null!;
        }

        private static void Delete(Uri uri)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                userToken);

            try
            {
                // Send the POST request
                var response = client.DeleteAsync(uri).Result;

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User has been deleted");
                }

                Console.WriteLine($"Error: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Makes a Selenium Web Driver
        /// </summary>
        /// <returns>Selenium Web Driver</returns>
        private static IWebDriver MakeDriver()
        {
            var builder = WebDriverBuilderFactory.MakeWebDriverBuilder(TestConfiguration.BrowserType);

            if (TestConfiguration.SeleniumUiMode == "Headless")
            {
                builder = builder.SetHeadless();
            }

            var driver = builder.Build();
            var manage = driver.Manage();
            manage.Cookies.DeleteAllCookies();
            manage.Window.Maximize();

            return driver;
        }
    }
}
