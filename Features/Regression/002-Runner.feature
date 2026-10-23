Feature: 002-Digital form -Submission -Runner
Background:
	Given Navigate to Home page

@UIRegression
Scenario Outline: 001_Verify that user should be able to see  Submit the form
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then Click on test link in dashboard in "<FormName>"
	Then Verify 'First page' in page
	Then Click on continue button
	Then Verify 'Second page' in page
	Then Click on continue button
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
Examples:
	| FormName        |
	| automationtest1 |