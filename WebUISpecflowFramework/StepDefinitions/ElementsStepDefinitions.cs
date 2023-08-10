using WebUISpecflowFramework.ClientDrivers;

namespace WebUISpecflowFramework.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private readonly IClientDriver clientDriver;
        private Dictionary<string, string> user = null!;
        private string username = null!;

        public ElementsStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }
        
        [Given(@"the following user is specified")]
        public void GivenTheFollowingUserIsSpecified(Table table)
        {
            clientDriver.GoToHomePage();
            var tableHeaders = table.Header;
            user = table.Rows.Select(row =>
                    tableHeaders.ToDictionary(
                        attr => attr,
                        attr => row.TryGetValue(attr, out var value) ? value : null))
                .FirstOrDefault()!;
            
            clientDriver.FillUpTextboxForm(user);
        }

        [When(@"I submit the form")]
        public void GivenTheUserIsSpecifiedBelow()
        {
            clientDriver.SubmitTextboxForm();
        }

        [Then(@"the registered user is displayed")]
        public void ThenTheRegisteredUserIsDisplayed()
        {
            foreach (var kvp in user)
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    var actualResult = clientDriver.GetOutputUserField(kvp.Key);
                    actualResult.Should().BeEquivalentTo(user[kvp.Key]);
                }
            }
        }

        [Then(@"the email field shows error")]
        public void ThenTheEmailFieldShowsError()
        {
            var error = clientDriver.GetEmailInputFieldError();
            error.Should().NotBeNull();
        }

        [Given(@"I expand all the checkbox fields")]
        public void GivenIExpandAllTheCheckboxFields()
        {
            clientDriver.GoToHomePage();
            clientDriver.ExpandCheckBoxes();
        }

        [When(@"I check the ""([^""]*)"" checkbox")]
        public void WhenICheckTheCheckbox(string name)
        {
            clientDriver.ToggleCheckbox(name);
        }

        [Then(@"all child checkboxes for ""([^""]*)"" are checked")]
        public void ThenAllChildCheckboxesForAreChecked(string name)
        {
            var isChecked = clientDriver.ChildCheckboxesChecked(name);
            isChecked.Should().BeTrue();
        }

        [Given(@"the user ""([^""]*)"" has registered information")]
        public void GivenTheUserHasRegisteredInformation(string name)
        {
            username = name;
            clientDriver.GoToHomePage();
            clientDriver.WebTableUserRegistered(name).Should().BeTrue();
        }

        [When(@"I update the details of the registration")]
        public void WhenIUpdateTheDetailsOfTheRegistration(Table table)
        {
            var tableHeaders = table.Header;
            user = table.Rows.Select(row =>
                    tableHeaders.ToDictionary(
                        attr => attr,
                        attr => row.TryGetValue(attr, out var value) ? value : null))
                .FirstOrDefault()!;

            clientDriver.UpdateWebTableRow(username, user);
            username = user["First Name"];
        }

        [Then(@"the registration information is updated")]
        public void ThenTheRegistrationInformationIsUpdated()
        {
            clientDriver.CheckWebTableUserUpdated(username, user);
        }

        [Then(@"the registration information is not updated")]
        public void ThenTheRegistrationInformationIsNotUpdated()
        {
            clientDriver.CheckWebTableNotUpdated();
        }

        [Given(@"I am on the Buttons page")]
        public void GivenIAmOnTheButtonsPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToButtonsPage();
        }

        [When(@"I double click the button")]
        public void WhenIDoubleClickTheButton()
        {
            clientDriver.DoubleClickButton();
        }

        [When(@"I right click the button")]
        public void WhenIRightClickTheButton()
        {
            clientDriver.RightClickButton();
        }

        [When(@"I dynamic click button")]
        public void WhenIDynamicClickButton()
        {
            clientDriver.DynamicClickButton();
        }


        [Then(@"double click message ""([^""]*)"" is displayed")]
        public void ThenDoubleClickMessageIsDisplayed(string message)
        {
            var actualMessage = clientDriver.GetDoubleClickMessage();
            actualMessage.Should().Be(message);
        }

        [Then(@"right click message ""([^""]*)"" is displayed")]
        public void ThenRightClickMessageIsDisplayed(string message)
        {
            var actualMessage = clientDriver.GetRightClickMessage();
            actualMessage.Should().Be(message);
        }

        [Then(@"dynamic click message ""([^""]*)"" is displayed")]
        public void ThenDynamicClickMessageIsDisplayed(string message)
        {
            var actualMessage = clientDriver.GetDynamicClickMessage();
            actualMessage.Should().Be(message);
        }

        [Given(@"I am on the Upload and Download page")]
        public void GivenIAmOnTheUploadAndDownloadPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToUploadDownloadPage();
        }

        [When(@"I upload a file")]
        public void WhenIUploadAFile()
        {
            clientDriver.UploadFile();
        }

        [Then(@"the file path is displayed")]
        public void ThenTheFilePathIsDisplayed()
        {
            clientDriver.CheckFilePathDisplayed();
        }

        [When(@"I download a file")]
        public void WhenIDownloadAFile()
        {
            clientDriver.DownloadFile();
        }

        [Then(@"the file is downloaded")]
        public void ThenTheFileIsDownloaded()
        {
            clientDriver.CheckDownloadedFile();
        }
    }
}