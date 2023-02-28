Feature: ResetAppState

I as a user want to fully reset the web application when I click on the ResetAppState button
In the left sidebar

Scenario: ResetAppState removed products from the cart
	Given I am logged in to SourceLabs
	When  I add a product to the cart
	And I open the side menu
	And I click the ResetAppState button
	Then Cart should be emptied

Scenario: ResetAppState resets Remove button back to Add To Cart
	Given I am logged in to SourceLabs
	When I add a product to the cart
	And I open the side menu
	And I click the ResetAppState button
	Then Product Remove button should be change back to Add To Cart

Scenario: ResetAppState resets the product sort order
	Given I am logged in to SourceLabs
	When I change the product sort order
	And I open the side menu
	And I click the ResetAppState button
	Then Product sort order should be changed back to the default order