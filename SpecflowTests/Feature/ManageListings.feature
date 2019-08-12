Feature: ManageListings
	In order to change my skills
	As a skill trader
	I want to update and delete skill

@mytag
Scenario: Edit skill
Given I naviagte to profile page and click on Manage Listing
When I click Edit listing
Then skill should be updated


Scenario: Delete Skill
Given I navigate to profile page and click on Manage Listing
When I click delete listing
Then skill should be deleted