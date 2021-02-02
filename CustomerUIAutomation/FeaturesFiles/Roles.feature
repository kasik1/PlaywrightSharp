Feature: Roles
	
@chrome
Scenario: Verify UsersScreen
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I click on Hambuger menu
	And I Click on Roles Menu
	And Add an new Role