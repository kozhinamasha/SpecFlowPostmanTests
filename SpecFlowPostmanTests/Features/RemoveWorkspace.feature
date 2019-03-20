Feature: RemoveWorkspace

@mytag
Scenario Outline: Remove new workplace
	Given I am logged in user
	When I remove workspace <name>
	Then The workspace has been removed

	Examples:
	| name          | page                              |
	| TestWorkSpace | https://web.postman.co/workspaces |