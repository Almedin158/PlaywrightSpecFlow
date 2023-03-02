Feature: Navigation buttons

As a user
I want to be navigated to different websites/pages when I click on navigation buttons/urls

Scenario: User clicks on the Your Cart button
	Given I am logged in to SourceLabs
	When I click the your cart button
	Then I should be redirected to the cart page

Scenario: User clicks on the Facebook button
	Given I am logged in to SourceLabs
	When I click the Facebook button
	Then I should be redirected to the Facebook page

Scenario: User clicks on the Twitter button
	Given I am logged in to SourceLabs
	When I click the Twitter button
	Then I should be redirected to the Twitter page

Scenario: User clicks on the LinkedIn button
	Given I am logged in to SourceLabs
	When I click the LinkedIn button
	Then I should be redirected to the LinkedIn page

Scenario: User clisk on the About button
	Given I am logged in to SourceLabs
	When I open the side menu
	And I click the About button
	Then I want to be redirected to the About page