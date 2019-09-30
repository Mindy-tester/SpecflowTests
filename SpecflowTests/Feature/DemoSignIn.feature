Feature: DemoSignIn
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: SignIn
	Given I have navigated to  skill swap website
	And I have clicked on SignIn 
	When I have entered username "minty80@gmail.com" and password "121212"
	And I have clicke on Login button
	Then I should be on home page
