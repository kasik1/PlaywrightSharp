Feature: FavouriteApps

@Chrome
Scenario: Verify Selection of fav Apps
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps 
	Then All Apps displayed in dashboard
	When I favourites Apps from all 5 Apps in view and Navigate to DashBoard i validate throught dashboard and fav Apps Tab
	Then Favourited Apps should be displayed in favourite App wrapper
	When I remove all fav apps 
	Then selected Fav Should be removed and validated
	And I Logout From Portal


@Chrome
Scenario: Verify Selection of more than Five fav Apps
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps
	Then All Apps displayed in dashboard
	When I favourites Apps try to favourite 6 Apps 
	Then Error Message Should be displayed
	Then Favourited Apps should be displayed in favourite App wrapper
	When I remove all fav apps 
	Then selected Fav Should be removed and validated
	And I Logout From Portal

@Chrome
Scenario: Verify Selection of fav Apps with Add favourite Tab Functionality
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps
	Then All Apps displayed in dashboard
	When I favourites Apps From Add Fav Apps TaB 
	And Navigate to DashbOard
	Then Favourited Apps should be displayed in favourite App wrapper
	When I remove all fav apps 
	Then selected Fav Should be removed and validated
	And I Logout From Portal

@Chrome
Scenario: Verify Remove of fav FromUnselection Apps
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps
	Then All Apps displayed in dashboard
	When I favourites Apps From Add Fav Apps TaB 
	Then i Remove Added Fav Apps From Star unSelection And validate As unselected 
	When Navigate to DashbOard
	Then selected Fav Should be removed and validated
	And I Logout From Portal
	
@Chrome
Scenario: Verify Remove of fav From UnFavOption Apps
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps
	Then All Apps displayed in dashboard
	
	When I favourites Apps from all 5 Apps in view
	When Navigate to DashbOard
	Then selected Fav Should be removed and validated
	And I Logout From Portal


@Chrome
Scenario: Verify All Apps display
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	Then Customer Portal Home Page is displayed
	When I validate No Apps are favourite
	When I click on favourites Apps Tab
	Then View all Apps Tab should be displayed with No Fav Apps 
	Then All Apps displayed in dashboard as expected
	Then Verify App Name, description and tool tip values
	When click Launch button from App menu
	Then URL Should be open as expected
	And I Logout From Portal