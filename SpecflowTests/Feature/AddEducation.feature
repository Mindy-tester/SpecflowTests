Feature: AddEducation
	In order to update my profile
	As a skill trader
	I want to add Education

@mytag
Scenario: Add Education
	Given I navigate the Education tab under Profile page
	When I clicked on AddNew button under education
	And I enetered College/University name, Country of university/College, Title, Degree and year of graduation
	Then the new education should be added