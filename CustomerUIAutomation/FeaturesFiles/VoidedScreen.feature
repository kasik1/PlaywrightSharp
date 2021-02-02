Feature: VoidedItemsPage

@Chrome
Scenario: Verify Voided Items home screen
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Voided items page
	Then Validate Voided items Home page fields and buttons

@Chrome
Scenario: Verify Voided items details page
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Voided items page
	Then Validate the Voided Item details page fields

@Chrome
Scenario: Verify Reprocessing a Voided Item from details page
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Voided items page
	Then Reprocess the Voided item from details view

@Chrome
Scenario: Verify Reprocessing seleceted Voided Item
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Voided items page
	And I Select a Voided item
	Then Reprocess the selected Voided Item