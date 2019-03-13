Feature: LoginAtThePostmanPage

@mytag
Scenario Outline: Login at the Postman page
	Given I visit the page <page>
	And I confirmed Cookies policy
	When Enter Login <login> and Password <password>
	Then The login is successful

	Examples:
	| page                        | login       | password    |
	| https://www.getpostman.com/ | globallogic | globallogic | 

Scenario Outline: Create new workplace
	Given I am logged in user
	When I create new workspace <name>
	And I visit the page <page>
	Then I see new workspace <name> at the Dashboard

	Examples:
	| name          | page                              |
	| TestWorkSpace | https://web.postman.co/workspaces |

Scenario Outline: Remove new workplace
	Given I am logged in user
	When I remove workspace <name>
	Then The workspace has been removed

	Examples:
	| name          | page                              |
	| TestWorkSpace | https://web.postman.co/workspaces |