Feature: LoginToPostman

@mytag
Scenario Outline: Login at the Postman page
	Given I visit the page <page>
	And I confirmed Cookies policy
	When Enter Login <login> and Password <password>
	Then The login is successful

	Examples:
	| page                        | login       | password    |
	| https://www.getpostman.com/ | globallogic | globallogic | 
