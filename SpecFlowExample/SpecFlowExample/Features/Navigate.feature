Feature: Navigator

Example test for web page navigation.

Scenario: Navigate to Katalyst 
	Given I start on 'https://www.codurance.com/'
	When I mouse over 'Insights'
	And I click on 'Katas'
	Then I get taken to 'https://www.codurance.com/katas'
