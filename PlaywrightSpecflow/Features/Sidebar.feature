Feature: Sidebar

I as a user want to be able to open the left sidebar when I click on a button

Scenario: Open the sidebar successfully
	Given I am logged in to SourceLabs
	When I click the burget button
	Then The sidebar should open

Scenario: Close the sidebar successfully
	Given I am logged in to SourceLabs
	When I click the burget button
	And I click the burget cross button
	Then The sidebar should close