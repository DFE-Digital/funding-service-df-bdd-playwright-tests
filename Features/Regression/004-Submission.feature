Feature: 004-Digital form- Form Submission
Background:
	Given Navigate to Home page

	###	"is at least": (">="),

#
#"is at most": ("<="),
#
#"is less than": ("<"),
#
#"is more than": (">"),
#
#"is": "=="
#
#"is not": "!="
@UIRegression
Scenario: 001_Result condition Worflow
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then Click on test link in dashboard in "<FormName>"
	Then Click on continue button
	Then Enter the number value "<Value>"
	Then Click on continue button
	Then Verify "<ConditionPageName>" in page
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
Examples:
	| FormName                             | Value | ConditionPageName |
	| Regression_ResultComponent_Condition | 119   | is at least_120   |
	| Regression_ResultComponent_Condition | 94    | is at most_95     |
	| Regression_ResultComponent_Condition | 96    | is less than_99   |
	| Regression_ResultComponent_Condition | 110   | is more than_110  |
	| Regression_ResultComponent_Condition | 107   | is_108            |
	| Regression_ResultComponent_Condition | 106   | is not_98         |

