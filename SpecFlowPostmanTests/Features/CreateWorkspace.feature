Feature: CreateWorkplace

@mytag
Scenario Outline: Create new workplace
	Given I am logged in user
	When I create new workspace <name>
	And I visit the page <page>
	Then I see new workspace <name> at the Dashboard

	Examples:
	| name          | page                              |
	| TestWorkSpace | https://web.postman.co/workspaces |