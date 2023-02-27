Feature: Login

As a user
I want to be able to log in to my Sauce Demo account
So that I can access the site's features and content

Scenario: Successful login with valid credentials
	Given I am on the Sauce Demo login page
    When I enter valid username "standard_user" and password "secret_sauce"
    And I click the login button
    Then I should be redirected to the Sauce Demo products page

Scenario: Unsuccessful login with invalid credentials
    Given I am on the Sauce Demo login page
    When I enter invalid username "invalid_user" and password "invalid_password"
    And I click the login button
    Then I should see an error message "Epic sadface: Username and password do not match any user in this service"

Scenario: Unsuccessful login with empty username
    Given I am on the Sauce Demo login page
    When I enter password "invalid_password"
    And I click the login button
    Then I should see an error message "Epic sadface: Username is required"

Scenario: Unsuccessful login with empty password
    Given I am on the Sauce Demo login page
    When I enter username "invalid_username"
    And I click the login button
    Then I should see an error message "Epic sadface: Password is required"

Scenario: Unsuccessful login with locked out user
    Given I am on the Sauce Demo login page
    When I enter invalid username "locked_out_user" and password "secret_sauce"
    And I click the login button
    Then I should see an error message "Epic sadface: Sorry, this user has been locked out."

Scenario: Unsuccessful login with not-matching credentials
    Given I am on the Sauce Demo login page
    When I enter username "standard_user" and invalid password "secret_sauce1"
    And I click the login button
    Then I should see an error message "Epic sadface: Username and password do not match any user in this service"