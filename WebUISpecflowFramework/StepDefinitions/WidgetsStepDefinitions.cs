using WebUISpecflowFramework.ClientDrivers;

namespace WebUISpecflowFramework.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        private readonly IClientDriver clientDriver;

        public WidgetsStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }

        [Given(@"I am on the AutoComplete page")]
        public void GivenIAmOnTheAutoCompletePage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToAutoCompletePage();
        }

        [When(@"I specify the hints ""([^""]*)"" and ""([^""]*)"" and select the second option")]
        public void WhenISpecifyTheHintsAndAndSelectTheSecondOption(string hint1, string hint2)
        {
            string[] hints = {
                hint1,
                hint2
            };
            
            clientDriver.SpecifySecondOption(hints);
        }

        [Then(@"the ""([^""]*)"" and ""([^""]*)"" options are selected")]
        public void ThenTheAndOptionsAreSelected(string selectedOption1, string selectedOption2)
        {
            var actualResult = clientDriver.GetSelectedOptions();
            actualResult.Should().Contain(selectedOption1);
            actualResult.Should().Contain(selectedOption2);
        }

        [When(@"I specify the hints ""([^""]*)"" and select the first option")]
        public void WhenISpecifyTheHintsAndSelectTheFirstOption(string hint)
        {
            clientDriver.SpecifyOption(hint);
        }

        [Then(@"the ""([^""]*)"" option is selected")]
        public void ThenTheOptionIsSelected(string selectedOption)
        {
            var actualResult = clientDriver.GetSelectedOption();
            actualResult.Should().Be(selectedOption);
        }

        [Given(@"I am on the Date Picker page")]
        public void GivenIAmOnTheDatePickerPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GotoDatePickerPage();
        }

        [When(@"I specify the input date (.*)")]
        public void WhenISpecifyTheDate(string inputDate)
        {
            clientDriver.SpecifySelectDate(inputDate);
        }

        [Then(@"the expected date (.*) is displayed")]
        public void ThenTheIsDisplayed(string expectedDate)
        {
            var actualResult = clientDriver.GetSelectedDate();
            actualResult.Should().Be(expectedDate);
        }

        [When(@"I specify the date and time (.*)")]
        public void WhenISpecifyTheDateAndTime(string dateTime)
        {
            clientDriver.SpecifySelectDateTime(dateTime);
        }

        [When(@"I specify the following value using the date picker")]
        public void WhenISpecifyTheFollowingValueUsingTheDatePicker(Table table)
        {
            var tableHeaders = table.Header;
            var dateTimeDictionary = table.Rows.Select(row =>
                    tableHeaders.ToDictionary(
                        attr => attr,
                        attr => row.TryGetValue(attr, out var value) ? value : null))
                .FirstOrDefault()!;

            clientDriver.SpecifySelectDateTimeUsingPicker(dateTimeDictionary);
        }

        [Then(@"the date and time ""(.*)"" is displayed")]
        public void ThenTheDateAndTimeFebruaryAMIsDisplayed(string expectedDateTime)
        {
            var actualResult = clientDriver.GetSelectedDateTime();
            actualResult.Should().Be(expectedDateTime);
        }


        [Given(@"I am on the Tool Tips page")]
        public void GivenIAmOnTheToolTipsPage()
        {
            clientDriver.GoToHomePage();
            clientDriver.GoToToolTipsPage();
        }

        [When(@"I hover over the button")]
        public void WhenIHoverOverTheButton()
        {
            clientDriver.HoverOverButton();
        }

        [When(@"I hover over the textbox")]
        public void WhenIHoverOverTheTextbox()
        {
            clientDriver.HoverOverTextbox();
        }


        [When(@"I hover over the link")]
        public void WhenIHoverOverTheLink()
        {
            clientDriver.HoverOverLink();
        }

        [Then(@"the button tooltip is displayed")]
        public void ThenTheButtonTooltipIsDisplayed()
        {
            clientDriver.CheckButtonToolTipDisplayed();
        }

        [Then(@"the textbox tooltip is displayed")]
        public void ThenTheTextboxTooltipIsDisplayed()
        {
            clientDriver.CheckTextboxToolTipDisplayed();
        }

        [Then(@"the link tooltip is displayed")]
        public void ThenTheLinkTooltipIsDisplayed()
        {
            clientDriver.CheckLinkToolTipDisplayed();
        }
    }
}
