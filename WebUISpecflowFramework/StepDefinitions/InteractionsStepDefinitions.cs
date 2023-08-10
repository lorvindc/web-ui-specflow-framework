using WebUISpecflowFramework.ClientDrivers;

namespace WebUISpecflowFramework.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        private readonly IClientDriver clientDriver;

        public InteractionsStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }
        
        [Given(@"I am on the Sortable page")]
        public void GivenIAmOnTheSortablePage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToSortablePage();
        }

        [When(@"I sort the elements in descending order")]
        public void WhenISortTheElementsInDescendingOrder()
        {
            clientDriver.SortElements();
        }

        [Then(@"the elements are displayed in descending order")]
        public void ThenTheElementsAreDisplayedInDescendingOrder()
        {
            clientDriver.CheckSortableElementInDescendingOrder();
        }

        [Given(@"I am on the Droppable page")]
        public void GivenIAmOnTheDroppablePage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToDroppablePage();
        }

        [When(@"I drag the element inside the drop box")]
        public void WhenIDragTheElementInsideTheDropBox()
        {
            clientDriver.DragAndDropElement();
        }

        [Then(@"the message ""([^""]*)"" is displayed")]
        public void ThenTheMessageIsDisplayed(string expectedMessage)
        {
            var actualMessage = clientDriver.GetDroppableMessage();
            actualMessage.Should().Be(expectedMessage);
        }
    }
}
