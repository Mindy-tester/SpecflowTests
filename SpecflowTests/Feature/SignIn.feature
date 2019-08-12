Feature: SignIn
	In order to access my account
	As a user 
	I want to log into the website

@mytag
Scenario: Login
	Given I have navigated to application
	And I entered username and password
	And I click login
	Then I should be at the home page