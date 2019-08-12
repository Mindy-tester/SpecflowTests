Feature: ShareSkillFeature
	In order to share my skill
	As a skill trader
	I want to share new skill

@mytag
Scenario: add new skill
Given I navigate to profile page and click on Share skil button
When I fill the all the mandotory details
Then skill should be added in my listing
