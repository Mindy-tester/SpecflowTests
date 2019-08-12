Feature: AddCertifications
	In order to update my profile
	As a skill trader
	I want to add Certifications

@mytag
Scenario: Add Certification
	Given I navigate the Certifications tab under Profile page
	When I clicked on AddNew button
	And I enetered Certification, Certified from and Year of certification
	Then new certicifation should be added

