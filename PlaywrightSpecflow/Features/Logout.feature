Feature: Logout

As a user
I want to be able to log out my Sauce Demo account
So that I redirected back to the login page

@tag1
Scenario: User can logout successfully
	Given I am logged in to SourceLabs
	When I open the side menu
	And I click the logout button
	Then I should be redirected to the login page

Scenario: User cannot access protected pages after logout
    Given I am logged in to SourceLabs
    When I open the side menu
    And I click the logout button
    And I try to access a protected page
    Then I should be redirected to the login page
    And I should see a error message