Feature: Reports
	

@Chrome
Scenario: Verify Reports Screen 
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I click on Hambuger menu
	And I Click on Reports Menu 
	And Switch to Grid View
	Then Reports Cards Should be displayed and also click on report cards should navigate to Detail view of report
    When Click on Next Button
	And Click on Previous Button
	When I click on back to reports
	Then Grid View is displayed
	When Switch to List View
	Then Select Report and view them
	And I Logout From Portal
	