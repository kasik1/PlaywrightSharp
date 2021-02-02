Feature: DashBoard

@Chrome
Scenario: Verify Customer Applications Screen
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When Verify View And DashBoard Reports
	Then Validate DashBoard Screen
    