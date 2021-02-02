Feature: Search

@Chrome
Scenario: Verify Search screen fields
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	And I Navigate to Search screen
	And I validate the current search and saved search details


@Chrome
Scenario: Verify Search results for a criteria
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	And I Navigate to Search screen
	When I fill the search criteria details and click on Search
	Then validate the search results	

@Chrome
Scenario: Verify saved search details
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	And I Navigate to Search screen
	When I fill the search criteria details and click on Save
	And I Fill the Save search pop-up and click on Save
	Then Validate the Saved search item
