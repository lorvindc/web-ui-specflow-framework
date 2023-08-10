Feature: Interactions

As an Automation Engineer,
I want to be able to automate Interactions Selenium commands 
So that I can automate different interaction with elements (Sort, Drag and Drop, etc.)

Scenario: Interactions - Sort Elements in Descending Order -> Elements are sorted
    Given I am on the Sortable page
    When I sort the elements in descending order
    Then the elements are displayed in descending order


Scenario: Interactions - Droppable -> Element is drag and dropped
    Given I am on the Droppable page
    When I drag the element inside the drop box
    Then the message "Dropped!" is displayed