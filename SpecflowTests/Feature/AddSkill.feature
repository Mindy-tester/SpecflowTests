Feature: AddSkill
	In order to update my profile
	As a skill trader
	I want to be add my skills

@automate
Scenario: Add Skill
Given I navigate to skills tab under profile page
When I add new skills
Then the skills should be added
