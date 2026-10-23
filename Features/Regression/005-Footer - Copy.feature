Feature: 005-Digital form- Footer
Background:
	Given Navigate to Home page


@UIRegression
Scenario Outline: 001 Check footers link -Information guide
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Check Footer link 'Information guide' section


@UIRegression
Scenario Outline: 002 Check footers link -Support shortcuts
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Check Footer link 'Support shortcuts' section


@UIRegression
Scenario Outline: 003 Check footers link -CopyRight
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Check Footer link 'Copy Right' section

@UIRegression
Scenario Outline: 004 Check footers link -Accessibility statement
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Check Footer "Accessibility" and URL "/help/accessibility-statement" in designer


@UIRegression
Scenario Outline: 005_footer-runner -Accessibility statement
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	And Click on test link for form "<FormName>"
	Then Check Footer "<Link>" and URL "<URL>"
	Examples:
	| FormName        | Link | URL |
	| automationtest1 |  Accessibility statement    |  /help/accessibility-statement   |
	
@UIRegression
Scenario Outline: 006_footer-runner -Cookies
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then Click on test link in dashboard in "<FormName>"
	Then Check Footer "Cookies" and URL "/cookies"
	Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 007_footer-runner -Privacy
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then Click on test link in dashboard in "<FormName>"
	Then Check Footer "Privacy" and URL "https://www.gov.uk/government/publications/privacy-information-education-providers-workforce-including-teachers/privacy-information-education-providers-workforce-including-teachers"
	Examples:
	| FormName        |
	| automationtest1 |