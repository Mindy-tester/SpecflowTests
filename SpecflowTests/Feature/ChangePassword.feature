Feature: ChangePassword
	In order to create new password 
	I want to chnage my old password

@mytag
 Scenario Outline: Change password
	Given I navigate to Account Setting page
	And I click on password edit icon
	And I enter <Current password>
	And I enter <New password> and <Confirm password>
	When I click Save button
	Then I should see the confirmation message
	
	Examples: 
	| Current password | New password | Confirm password|
	| 123123        | 121212      | 121212         |
