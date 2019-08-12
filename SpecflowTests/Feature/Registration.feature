Feature: Registration
	In order to share my skill
	As a skill trader
	I want to register to skillswap website

@mytag
Scenario: Registration
	Given I have navigated to registration page
	And I enter all the following details
		|Fisrtname|Lastname|Emailaddress|Password|ConfirmPassword|
		| Minty     | Bansal   | abd@gmail.com | minty  | minty  |
	And I Select the terms and conditions checkbox
	Then I click on Join button
	Then I should be registered