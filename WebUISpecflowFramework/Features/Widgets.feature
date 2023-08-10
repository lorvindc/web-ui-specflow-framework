Feature: Widgets

As an Automation Engineer,
I want to be able to automate Selenium commands on Widgets
So that I can automate interaction with Widgets

Scenario: AutoComplete - Multiple Color Names -> Opens a new tab
    Given I am on the AutoComplete page
    When I specify the hints "Re" and "Bl" and select the second option
    Then the "Green" and "Black" options are selected


Scenario: AutoComplete - Single Color Name -> Opens a new tab
    Given I am on the AutoComplete page
    When I specify the hints "Re" and select the first option
    Then the "Red" option is selected


Scenario Outline: Date Picker - Select Date -> Date is selected
    Given I am on the Date Picker page
    When I specify the input date <Input Date>
    Then the expected date <Expected Date> is displayed

    Examples: 
    | Input Date | Expected Date |
    | 02/04/06   | 02/04/2006    |
    | 2001-02-03 | 02/03/2001    |


Scenario Outline: Date Picker - Select Date and Time -> Date and Time is selected
    Given I am on the Date Picker page
    When I specify the date and time <Input Date and Time>
    Then the date and time "<Expected Date and Time>" is displayed

    Examples: 
    | Input Date and Time | Expected Date and Time   |
    | 02/04/06 2:00       | February 4, 2006 2:00 AM |
    | 2001-02-03 01:23    | February 3, 2001 1:23 AM |


Scenario Outline: Date Picker - Select Date and Time using picker -> Date and Time is selected
    Given I am on the Date Picker page
    When I specify the following value using the date picker 
    | Year | Month   | Day | Time  |
    | 2024 | October | 19  | 04:00 |
    Then the date and time "October 19, 2024 4:00 AM" is displayed


Scenario: Tool Tips - Hover over button -> Tool tip is displayed
    Given I am on the Tool Tips page
    When I hover over the button
    Then the button tooltip is displayed


Scenario: Tool Tips - Hover over Textbox -> Tool tip is displayed
    Given I am on the Tool Tips page
    When I hover over the textbox
    Then the textbox tooltip is displayed


Scenario: Tool Tips - Hover over Link -> Tool tip is displayed
    Given I am on the Tool Tips page
    When I hover over the link
    Then the link tooltip is displayed
