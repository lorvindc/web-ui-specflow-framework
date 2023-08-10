Feature: Elements

As an Automation Engineer,
I want to be able to automate Selenium commands on Elements
So that I can automate interaction with Web Elements


Scenario Outline: Textbox - Submit User Info in Textbox -> Displays User Info
	Given the following user is specified
    | name   | email   | currentAddress   | permanentAddress   |
    | <name> | <email> | <currentAddress> | <permanentAddress> |
	When I submit the form
	Then the registered user is displayed

    Examples: 
    | name       | email               | currentAddress      | permanentAddress    |
    | John Doe   | johndoe@example.com | 123 Main St, City A | 456 Oak Ave, City B |
    | Jane Smith |                     |                     |                     |
    |            | janedoe@example.com |                     |                     |
    |            |                     | 789 Elm St, City D  |                     |
    |            |                     |                     | 321 Pine Dr, City E |

Scenario: Textbox - Submit Details with invalid Email in Textbox
	Given the following user is specified
    | name     | email   | currentAddress      | permanentAddress    |
    | John Doe | johndoe | 123 Main St, City A | 456 Oak Ave, City B |
	When I submit the form
	Then the email field shows error


Scenario: Checkbox - Parent checkbox is checked -> All child checkboxes are checked
    Given I expand all the checkbox fields
    When I check the "Home" checkbox
    Then all child checkboxes for "Home" are checked


Scenario: Web Table - Successful Edit of Web Tables -> Data in table is updated
    Given the user "Cierra" has registered information 
    When I update the details of the registration
    | First Name | Last Name | Age | Email             | Salary | Department |
    | Madre      | Balrog    | 40  | madre@example.com | 200000 | IT         |
    Then the registration information is updated

Scenario Outline: Web Table - Failed Edit of Web Tables -> Data in table is updated
    Given the user "Cierra" has registered information 
    When I update the details of the registration
    | First Name   | Last Name   | Age   | Email   | Salary   | Department   |
    | <First Name> | <Last Name> | <Age> | <Email> | <Salary> | <Department> |
    Then the registration information is not updated

    Examples: 
    | First Name | Last Name | Age | Email        | Salary  | Department |
    |            |           |     |              |         |            |
    | Madre      | Balrog    | -1  | madre        | -200000 | IT         |
    | Madre      | Balrog    | abc | @example.com | def     | IT         |


Scenario: Buttons - Double Click a button -> Double Click message is displayed
    Given I am on the Buttons page
    When I double click the button
    Then double click message "You have done a double click" is displayed


Scenario: Buttons - Right Click a button -> Right Click message is displayed
    Given I am on the Buttons page
    When I right click the button
    Then right click message "You have done a right click" is displayed


Scenario: Buttons - Click a button -> Click message is displayed
    Given I am on the Buttons page
    When I dynamic click button
    Then dynamic click message "You have done a dynamic click" is displayed


Scenario: Upload and Download - Upload a file -> Displays uploaded file path
    Given I am on the Upload and Download page
    When I upload a file
    Then the file path is displayed


Scenario: Upload and Download - Download a file -> File is downloaded
    Given I am on the Upload and Download page
    When I download a file
    Then the file is downloaded