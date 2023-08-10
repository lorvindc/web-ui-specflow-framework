using OpenQA.Selenium;

namespace WebUISpecflowFramework.ClientDrivers
{
    /// <summary>
    /// Interface for the client drivers
    /// </summary>
    public interface IClientDriver
    {
        void SetUp();

        void TearDown();

        void FillUpTextboxForm(Dictionary<string, string> user);

        void SubmitTextboxForm();

        string GetOutputUserField(string field);

        void GoToHomePage();

        IWebElement GetEmailInputFieldError();
        
        void ExpandCheckBoxes();
        
        void ToggleCheckbox(string name);
        
        bool ChildCheckboxesChecked(string name);
        
        bool WebTableUserRegistered(string user);
        
        void UpdateWebTableRow(string username, Dictionary<string, string> user);
        
        void CheckWebTableUserUpdated(string updatedUsername, Dictionary<string, string> user);

        void CheckWebTableNotUpdated();

        void GoToButtonsPage();
        
        void DoubleClickButton();
        
        void RightClickButton();
        
        void DynamicClickButton();
        
        string GetDoubleClickMessage();

        string GetRightClickMessage();
        
        string GetDynamicClickMessage();
        
        void GoToUploadDownloadPage();
        
        void UploadFile();
        
        void CheckFilePathDisplayed();
        
        void DownloadFile();
        
        void CheckDownloadedFile();

        void GoToBrowserWindowsPage();

        void GoToAlertPage();

        void ClickNewTab();
        
        void CheckNewTabOpened();
        
        void ClickNewWindow();
        
        void CheckNewWindowOpened();
        
        void ClickNewMessage();

        void CheckNewMessageOpened();
        
        void ClickAlertButton();

        void ClickTimerAlertButton();

        void ClickConfirmButton();

        void ClickPromptButton();

        void CheckAlertPopupWindow();

        void CheckTimerAlertPopupWindow();
        
        void CheckConfirmPopupWindow();
        
        void CheckPromptWindow();

        void GoToAutoCompletePage();
        
        void SpecifySecondOption(string[] hints);

        List<string> GetSelectedOptions();
        
        void SpecifyOption(string hint);
        
        string GetSelectedOption();
        
        void GotoDatePickerPage();
        
        void SpecifySelectDate(string inputDate);
        
        string GetSelectedDate();
        
        void SpecifySelectDateTime(string dateTime);
        
        string GetSelectedDateTime();
        
        void SpecifySelectDateTimeUsingPicker(Dictionary<string, string?> dateTime);
        
        void GoToToolTipsPage();
        
        void HoverOverButton();
        
        void CheckButtonToolTipDisplayed();
        
        void HoverOverTextbox();
        
        void CheckTextboxToolTipDisplayed();
        
        void HoverOverLink();
        
        void CheckLinkToolTipDisplayed();
        
        void GoToSortablePage();
        
        void SortElements();
        
        void CheckSortableElementInDescendingOrder();
        
        void GoToDroppablePage();
        
        void DragAndDropElement();
        
        string GetDroppableMessage();
        
        void RegisterTestUser();

        void DeleteTestUser();

        void GoToLoginPage();
        
        void EnterLoginCredentials(string testUsername, string testPassword);
        
        void CheckProfilePageDisplayed();
        
        string CheckLoginErrorMessage();
    }
}
