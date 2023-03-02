Feature: ProductSortContainer

As a user I want to be able to sort the products displayed

Scenario: Sort products by price highest to lowest
	Given I am logged in to SourceLabs
	When I change the product sort order to Price (high to low)
	Then I want the products to be displayed in a descending order by price

Scenario: Sort products by price lowest to highest
	Given I am logged in to SourceLabs
	When I change the product sort order to Price (high to low)
	And I change the product sort order to Price (low to high)
	Then I want the products to be displayed in a ascending order by price

Scenario: Sort products by name A to Z 
	Given I am logged in to SourceLabs
	When I change the product sort order to Name (A to Z)
	Then I want the products to be displayed in a ascending order by name

Scenario: Sort products by name Z to A
	Given I am logged in to SourceLabs
	When I change the product sort order to Name (Z to A)
	Then I want the products to be displayed in a descending order by name