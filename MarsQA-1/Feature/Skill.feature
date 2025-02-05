Feature: Skills

As a user I should be able to show what skills I have.
 So that the people seeking for certain skills can look at what details I hold.

@regression
Scenario: 1. Add new skill to user profile
	When User adds a new skill and level to the profile section
	Then The skill is successfully added to the profile

Scenario: 2. Edit existing skill on user profile page
	When User edits an existing skill and level on the profile section
	Then The skill is successfully updated on the profile 

Scenario: 3. Delete existing skill on user profile page
	When User deletes an existing skill and level on the profile section
	Then The skill is successfully deleted from the profile 
