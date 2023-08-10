@BookStoreApp
Feature: Book Store Application

As an Automation Engineer,
I want to be able to automate Login functionality
So that I can automate authentication mechanisms of different systems


Scenario: Book Store Application - Successful Login -> Profile Page is displayed
    Given I am on the Login page
    When I enter valid credentials
    Then the Profile Page is displayed


Scenario: Book Store Application - Failed Login -> Error message is displayed
    Given I am on the Login page
    When I enter invalid username "invalidUsername" and password "invalidPassword" 
    Then the error message "Invalid username or password!" is displayed