using WebUISpecflowFramework.ClientDrivers;

namespace WebUISpecflowFramework.StepDefinitions
{
    [Binding]
    public class AlertsFramesWindowsStepDefinitions
    {
        private readonly IClientDriver clientDriver;

        public AlertsFramesWindowsStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }
        
        [Given(@"I am on the Browser Windows page")]
        public void GivenIAmOnTheBrowserWindowsPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToBrowserWindowsPage();
        }

        [Given(@"I am on the Alert page")]
        public void GivenIAmOnTheAlertPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToAlertPage();
        }


        [When(@"I click on the New Tab button")]
        public void WhenIClickOnTheNewTabButton()
        {
            clientDriver.ClickNewTab();
        }

        [Then(@"a New Tab is opened")]
        public void ThenANewTabIsOpened()
        {
            clientDriver.CheckNewTabOpened();
        }

        [When(@"I click on the New Window button")]
        public void WhenIClickOnTheNewWindowButton()
        {
            clientDriver.ClickNewWindow();
        }

        [Then(@"a New Window is opened")]
        public void ThenANewWindowIsOpened()
        {
            clientDriver.CheckNewWindowOpened();
        }

        [When(@"I click on the New Window Message button")]
        public void WhenIClickOnTheNewWindowMessageButton()
        {
            clientDriver.ClickNewMessage();
        }

        [Then(@"a New Window Message is opened")]
        public void ThenANewWindowMessageIsOpened()
        {
            clientDriver.CheckNewMessageOpened();
        }

        [When(@"I click on the Alert button")]
        public void WhenIClickOnTheAlertButton()
        {
            clientDriver.ClickAlertButton();
        }

        [Then(@"an Alert window is opened")]
        public void ThenAnAlertWindowIsOpened()
        {
            clientDriver.CheckAlertPopupWindow();
        }

        [When(@"I click on the Timer Alert button")]
        public void WhenIClickOnTheTimerAlertButton()
        {
            clientDriver.ClickTimerAlertButton();
        }

        [Then(@"a Timer Alert window is opened")]
        public void ThenATimerAlertWindowIsOpened()
        {
            clientDriver.CheckTimerAlertPopupWindow();
        }

        [When(@"I click on the Confirm button")]
        public void WhenIClickOnTheConfirmButton()
        {
            clientDriver.ClickConfirmButton();
        }

        [Then(@"a Confirm window is opened")]
        public void ThenAConfirmWindowIsOpened()
        {
            clientDriver.CheckConfirmPopupWindow();
        }


        [When(@"I click on the Prompt button")]
        public void WhenIClickOnThePromptButton()
        {
            clientDriver.ClickPromptButton();
        }

        [Then(@"a Prompt window is opened")]
        public void ThenAPromptWindowIsOpened()
        {
            clientDriver.CheckPromptWindow();
        }

    }
}
