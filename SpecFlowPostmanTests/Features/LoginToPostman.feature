Feature: LoginAtThePostmanPage

@mytag
Scenario Outline: Login at the Postman page
	Given I have opened page <page>
	And I confirmed Cookies policy
	When Enter Login <login> and Password <password>
	Then The login is successful

	Examples:
	| page                        | login                   | password    |
	| https://www.getpostman.com/ | kozhinamasha@gmail.com  | Kykolka1987 | 

