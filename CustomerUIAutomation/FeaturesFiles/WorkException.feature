Feature: WorkException

@Chrome
Scenario: Verify Work Exception home screen
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Work exception page
	Then Validate Work exception Home page fields and buttons

@Chrome
Scenario: Verify Workitem details page
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Work exception page
	Then Validate the Workexception details page fields

@Chrome
Scenario: Verify Reprocessing a work exception from details page
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Work exception page
	And I click on a Work exception
	Then Reprocess the work exception from details view

@Chrome
Scenario: Verify Reprocessing selecetd work exceptions
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I Navigate to Work exception page
	And I Select a Work exception
	Then Reprocess the selected work exception