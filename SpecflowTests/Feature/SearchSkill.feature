Feature: SearchSkill
	In order to avoid silly mistakes
	As a skill trader
	I want to be searck skill by category or sub category

@mytag
Scenario: Search skill by category 
	Given I navigate to home page
	And I enter skill in search box
	When I select categories
	Then selected categories skill should open
@mytag
	Scenario: Search skill by subcategory
	Given I navigate to home page
	And I enter skill in search box
	And  I select categories
	When I select subcategories 
	Then selected sub categories skill should open
