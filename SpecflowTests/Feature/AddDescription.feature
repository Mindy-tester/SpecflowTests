Feature: AddDescription
	In order to update my profile
	As a skill trader
	I want to add description

@mytag
Scenario: Add Description
	Given I navigate to profile page
	And I click on decription update icon
	And I added description and click save 
	Then Description should be added
