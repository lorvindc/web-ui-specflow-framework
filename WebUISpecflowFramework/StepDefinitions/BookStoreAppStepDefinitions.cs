using WebUISpecflowFramework.ClientDrivers;
using WebUISpecflowFramework.Support;

namespace WebUISpecflowFramework.StepDefinitions
{
    [Binding]
    public class BookStoreAppStepDefinitions
    {
        private readonly IClientDriver clientDriver;

        public BookStoreAppStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }

        [Given(@"I am on the Login page")]
        public void GivenIAmOnTheLoginPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToLoginPage();
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            clientDriver.EnterLoginCredentials(TestConfiguration.TestUsername, TestConfiguration.TestPassword);
        }

        [Then(@"the Profile Page is displayed")]
        public void ThenTheProfilePageIsDisplayed()
        {
            clientDriver.CheckProfilePageDisplayed();
        }

        [When(@"I enter invalid username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterInvalidUsernameAndPassword(string invalidUsername, string invalidPassword)
        {
            clientDriver.EnterLoginCredentials(invalidUsername, invalidUsername);
        }

        [Then(@"the error message ""([^""]*)"" is displayed")]
        public void ThenTheErrorMessageIsDisplayed(string expectedErrorMessage)
        {
            var actualErrorMessage = clientDriver.CheckLoginErrorMessage();
            actualErrorMessage.Should().Be(expectedErrorMessage);
        }
    }
}
