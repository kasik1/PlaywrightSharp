Feature: ServiceBusMonitor

@firefox

Scenario: Verify Service Bus Monitor Screen
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I click on Hambuger menu
	And I Click on Production Control Menu
	And I click on ServiceBus Monitor
	And I search using filter
	And I click on Enable

