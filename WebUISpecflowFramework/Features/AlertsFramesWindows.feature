Feature: Alerts Frames and Windows

As an Automation Engineer,
I want to be able to automate Selenium commands on Alerts, Frames, and Windows
So that I can automate interaction with Alerts, Frames, and Windows

Scenario: Browser Windows - New Tab -> Opens a new tab
    Given I am on the Browser Windows page
    When I click on the New Tab button
    Then a New Tab is opened


Scenario: Browser Windows - New Window -> Opens a new window
    Given I am on the Browser Windows page
    When I click on the New Window button
    Then a New Window is opened


Scenario: Browser Windows - New Window Message -> Opens a new window message
    Given I am on the Browser Windows page
    When I click on the New Window Message button
    Then a New Window Message is opened


Scenario: Alerts - Alert -> Opens an alert
    Given I am on the Alert page
    When I click on the Alert button
    Then an Alert window is opened


Scenario: Alerts - Timer Alert -> Opens an alert after 5 seconds
    Given I am on the Alert page
    When I click on the Timer Alert button
    Then a Timer Alert window is opened


Scenario: Alerts - Confirm dialog -> Opens a Confirm dialog
    Given I am on the Alert page
    When I click on the Confirm button
    Then a Confirm window is opened


Scenario: Alerts - Input Prompt -> Opens a Input Prompt dialog
    Given I am on the Alert page
    When I click on the Prompt button
    Then a Prompt window is opened