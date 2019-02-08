Feature: TranslateWord

Background: 
	Given I have opened translator page

@mytag
Scenario Outline: Translate the word from English to Spain
	When I select language <language1> for original text
	And I select language <language2> for translate
	And I enter the word <word1>
	Then The word has been translated on <word2>

	Examples:
		| language1 | language2 | word1   | word2  |
		| English   | Spanish   | parents | padres |
