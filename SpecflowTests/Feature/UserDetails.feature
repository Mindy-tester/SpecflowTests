Feature: UserDetails
	In order to update my profile
	As a skill trader
	I want to add my details

@mytag
Scenario: Add User Details
	Given I navigate to profile page
	And I add my avalibity
	And I add hours available
	And I add earn target
	Then all details should be added
