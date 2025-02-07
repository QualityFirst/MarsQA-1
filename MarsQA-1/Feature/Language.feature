Feature: Language

As a user I should be able to show what languages I know.
 So that the people seeking for skills and languages can look at what details I hold.

@regression
Scenario: 1. Add new language to user profile
	When User adds a new language and level to the profile section
	Then The language is successfully added to the profile

Scenario: 2. Edit existing language on user profile page
	When User edits an existing language and level on the profile section
	Then The language is successfully updated on the profile 

Scenario: 3. Delete existing language on user profile page
	When User deletes an existing language and level on the profile section
	Then The language is successfully deleted from the profile 
