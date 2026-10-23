Feature: 006-Digital Component form validation 
Background:
	Given Navigate to Home page

	@UIRegression  
Scenario Outline: 000_clean component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Delete the form using API
	
Examples:
	| FormName        |
	| automationtest1 |