Feature: UserSettings
	


@Chrome
Scenario: Verify the Summary of user settings View
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	When I Click on User Settings Icon
	Then I click on User profile Icon and Validate details
    Then I Logout From Portal
@Chrome
Scenario: Verify the upload AVATAR
	Given Navigate to the Customer UI Login pagee
	When I enter with valid login credentials
	When I Click on User Settings Icon
	When I click on Edit profile Icon
	When I Upload image formats of png with size within 2mb
	Then System should upload icon and Validate Notification
	When I Upload image formats of jpg with size within 2mb
	Then System should upload icon and Validate Notification
	When I Upload image formats of gif with size within 2mb
	Then System should upload icon and Validate Notification
    Then I upload invalid image formats as Avatar and Validate error message
    Then I click on cancel button
    Then I Logout From Portal  
   
   
 @Chrome
Scenario: Verify setting model popup window from different links
Given Navigate to the Customer UI Login pagee
    When I enter with valid login credentials
    When I Click on User Settings Icon
    When I Click on User Settings Icon displayed on image
    Then setting model popup window should be displayed as expected
    Then I click on cancel button
    When I Click on User Settings Icon
    When I Click on 'Edit your Account Settings' when click on image
    Then setting model popup window should be displayed as expected
    Then I click on cancel button
    When I Click on User Settings Icon
    When I Click on 'Languages' when click on image
    Then setting model popup window should be displayed as expected
    Then I click on cancel button
    When I Click on User Settings Icon
    When I Click on 'Theme' when click on image
    Then setting model popup window should be displayed as expected
    Then I click on cancel button
    Then I Logout From Portal   

 @Chrome
Scenario: Verify the update of all fileds in setting model popup window
Given Navigate to the Customer UI Login page
    When I enter with valid login credentials
    And I Click on User Settings Icon
    And I Click on 'Edit your Account Settings' when click on image
    Then setting model popup window should be displayed as expected
    When i enter valid username Dob and language and click on save 
    Then successfull message should be displayed
    When I Click on User Settings Icon
    Then updated values should be displayed when user click on profile
    When I Click on 'Edit your Account Settings' when click on image
    Then Valid the updated data for the corresponding feilds
    When i enter Invalid username Dob and language and click on save
    Then I Logout From Portal