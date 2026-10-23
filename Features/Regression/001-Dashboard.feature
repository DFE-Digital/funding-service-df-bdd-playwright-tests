Feature: 001-Digital form -Dashboard
Background:
	Given Navigate to Home page


Scenario Outline: 001-click on Start now and verify home page is displayed
	When Click on StartNow link
	Then the home page should be displayed
	             
@UIRegression
Scenario: 002_Verify that user should be able Create New Form
	When Click on StartNow link
	Then the home page should be displayed
	And Click on create new form
	And Verify Create a new form page
	And Enter the form name 'automationtest1'
	And Click on Next button
	And Verify label 'First page'
	And Verify label 'Second page'
	And Verify label 'Summary'

@UIRegression
Scenario Outline: 003_Verify that user should be able to change form status of existing form
	When Click on StartNow link
	Then the home page should be displayed
	Then User Select the form "<FormName>"
	Then User click on 'Form status' link
	Then user change status to "<FormStatus>"
	Then Verify the form status "<FormStatus>" for form "<FormName>"
Examples:
	| FormName        | FormStatus     |
	| automationtest1 | UAT            |
	| automationtest1 | Published      |
	| automationtest1 | Closed         |
	| automationtest1 | In development |

@UIRegression
Scenario Outline: 004_Verify that user should be able to delete the existing form
	When Click on StartNow link
	Then the home page should be displayed
	And Click on create new form
	And Verify Create a new form page
	Then Enter the form name 'automationtest6'
	Then Click on Next button
	Then go to Dashboard
	Then User Select the form "<FormName>"
	Then Delete the form
	Then User Select the form "<FormName>"
	Then Verify 'No items found' in results
Examples:
	| FormName        |
	| automationtest6 |

@UIRegression
Scenario Outline: 005_Verify that all the button should remain disable until user select any form for my forms
	When Click on StartNow link
	Then the home page should be displayed
	Then Verify button disabled in dashboard in 'My form'

@UIRegression
Scenario Outline: 006_Verify that all the button should become enable once user select a form for my forms
	When Click on StartNow link
	Then User Select the form "<FormName>"
	Then Verify button enabled in dashboard 'My form'
Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 007_Verify that all the button should remain disable until user select any form for my  Colleagues forms
	When Click on StartNow link
	Then click on Collegues form
	Then Verify button disabled in dashboard in 'Collegues form'
Examples:
	| FormName |
	| Test     |


@UIRegression
Scenario Outline: 008_Verify that all the button should become enable once user select a form for Colleagues forms
	When Click on StartNow link
	Then click on Collegues form
	Then User Select the form "<FormName>"
	Then select the top form
	Then Verify button enabled in dashboard 'Collegues form'
Examples:
	| FormName |
	| Test     |

@UIRegression
Scenario Outline: 009_Verify that if user try to access any close status application then user should be able to see static design error page
	When Click on StartNow link
	Then User Select the form "<FormName>"
	Then User click on 'Form status' link
	Then user change status to "<FormStatus>"
	Then select the top form 
	Then check 'UAT' link enabled for form "<FormName>"
	Then check 'Prod' link disabled for form "<FormName>"
	And Click on test link for form "<FormName>"
	Then Click on continue in First Page
	Then Click on continue in Second Page
	Then click on submit button
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on preview button
	Then Verify 'Applications have now closed' in page
	Then Verify 'Contact us if you need more information.' text
	Then Verify 'Sign up to the DfE newsletter for further updates.' text
	Then go to Dashboard
	Then User Select the form "<FormName>"
Examples:
	| FormName        | FormStatus |
	| automationtest1 | Closed     |

	@UIRegression
Scenario Outline: 010_Verify that if form status is "Closed" or "Published" and access type is Public, user click on preview button than user should be taken to production environment runner URL
	When Click on StartNow link
	Then the home page should be displayed
	Then User Select the form "<FormName>"
	Then User click on 'Form status' link
	Then user change status to "<FormStatus>"
	Then Verify the form status "<FormStatus>" for form "<FormName>"
	And Check the test link for form "<FormName>"
	Then check 'UAT' link enabled for form "<FormName>"
Examples:
	| FormName        | FormStatus |
		| automationtest1 | Published  |


@UIRegression
Scenario Outline: 011_Verify that if form status is "In-Development" or "UAT" and access type is Public, user click on preview button than user should be taken to UAT environment runner URL
	When Click on StartNow link
	Then the home page should be displayed
	Then User Select the form "<FormName>"
	Then User click on 'Form status' link
	Then user change status to "<FormStatus>"
	Then Verify the form status "<FormStatus>" for form "<FormName>"
	And Check the test link for form "<FormName>"
	Then check 'UAT' link enabled for form "<FormName>"
	Then check 'Prod' link disabled for form "<FormName>"
Examples:
	| FormName        | FormStatus |
		| automationtest1 | UAT        |
	| automationtest1 | In development |


@UIRegression
Scenario: 012_Verify that a form should be get duplicated with provided new name once user clicks on duplicate button present on pop up
	When Click on StartNow link
	Given User is on Dashboard Page
	Then the home page should be displayed
	Then User Select the form "<FormName>"
	Then User click on 'Duplicate form'
	Then Enter to duplicate form "<FormName>"
	Then Click on duplicate form
Examples:
	| FormName        |
	| automationtest1 |

	
@UIRegression
Scenario Outline: 013_Verify that user is able to import form json from dashboard page
	Given User is on Dashboard Page
	Then Verify Start Now link
	Then click on Start Now link
	Then verify Digital Form Builder title
	And user clicks on import saved form link
	Then verify that system gives import json modal window
	Then Import the json "<JsonFile>" with "<Name>"
	And user clicks on import .json button
Examples:
	| JsonFile        |Name			|
	| n5msi0dc9a.json | TestForm    |

@UIRegression
Scenario Outline: 014_Verify that user is able to import form json from form designer page
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then the user edits the form and click on import saved form link
	And the user uploads form json file "<JsonFile>"
	Then verify that imported form with form name "<JsonFile>" is displayed in dashboard
Examples:
	| JsonFile        | 
	| n5msi0dc9a.json |


Scenario Outline: 015_Verify that user should be able Create Parent child relationship between forms
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	Then Verify all forms in dashboard
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	Then Verify the grouped parent child forms in dashboard
	And user change switch access type to DFESignIn with "<FileName>" for all the forms in parent group
Examples:
	| FileName    |
	| ukprn 1.csv |

 
Scenario Outline: 016_Verify that user should be able change status of Parent child forms
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	Then Verify the grouped parent child forms in dashboard
	And user change switch access type to DFESignIn with "<FileName>" for all the forms in parent group
	And user change status of parent and child forms to "<Status>"
Examples:
	| FileName    | Status    |
	| ukprn 1.csv | Published |

@UIRegression
Scenario Outline: 017_Verify that user should be able delete Parent child forms
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	Then Verify the grouped parent child forms in dashboard
	And user change switch access type to DFESignIn with "<FileName>" for all the forms in parent group
	And user change status of parent and child forms to "<Status>"
	And user deletes parent child forms from dashboard
Examples:
	| FileName    | Status |
	| ukprn 1.csv | UAT    |


@UIRegression
Scenario Outline: 018_Verify that user should be able add conditions in Parent child relationship
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	And user should add a DSI component "UKPRN" and  condition "<Condition>" in parent form with "<UKPRN>" and change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms with condition "<Condition>"
	Then Verify the grouped parent child forms in dashboard
	And user change switch access type to DFESignIn with "<FileName>" for all the forms in parent group
	And user deletes parent child forms from dashboard
Examples:
	| FileName    | UKPRN     | Condition |
	| ukprn 1.csv | 100078001 | Condition |

@UIRegression
Scenario: 019_Verify that user should be able duplicate Parent child forms
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	And user duplicates the parent child forms with new form names
	And user deletes duplicate parent child forms from dashboard
	And user deletes parent child forms from dashboard

@UIRegression
Scenario Outline: 020_Verify form status-DFE Signin
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then User Click on switch access and change to dfesignin with file"<FileName>"
	Then Verify the form status 'DFE SignIn'
Examples:
     | FileName  |
	 |ukprn 1.csv|


@UIRegression
Scenario Outline: 021-switch access to public
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then User Click on switch access and change to dfesignin with file"<FileName>"
	Then User Click on switch access and change to public
	Then Verify the form status 'Public'
	Examples:
     | FileName  |
	 |ukprn 1.csv|

@UIRegression
Scenario Outline: 022_Verify that user should be able Create Parent child relationship between forms and check runner
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
	    | DependentForm_Two   |
		| DependentForm_Three |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	And user change switch access type to DFESignIn with "<FileName>" for all the forms in parent group
	And user validates runner of the parent child form with user ID "<USERID>"
Examples:
	| FileName             | USERID							  |
	| ukprn_latest0924.csv |   digitalforms01+1@gmail.com     |


@UIRegression
Scenario: 023_Verify the error message of Parent child group if API fails
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName          |
		| ParentForm        |
		| ChildForm         |
		| DependentForm_One |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	And user update child heading to validate the error message
Examples:
	| FileName             |
	| ukprn_latest0924.csv |

	
@UIRegression
Scenario: 024_Verify that user should be able ungroup Parent child forms
	Given User is on Dashboard Page
	Then click on Start Now link
	Then Click on create new form button
		| FormName            |
		| ParentForm          |
		| ChildForm           |
		| DependentForm_One   |
		| DependentForm_Two   |
		| DependentForm_Three |
	And user change page type of Parent form as "Parent Child page"
	And user create parent child relationship between the created forms
	And user ungroup the parent child forms 
	Then Verify the ungrouped parent child forms in dashboard


@UIRegression
Scenario: 025_Verify that user should be able to validate error messages in Runner for DSI Signin if user have DSI access with one/no UKPRN added to his profile
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then User Click on switch access and change to dfesignin with file"ukprn 1.csv"
	Then User change status of the new form to "Published"
	And user validates runner of the form for error message for users
	 | User                         |
	 | digitalforms01+103@gmail.com |
	 | digitalforms01+102@gmail.com |

@UIRegression
Scenario Outline: 026_Verify that user should be able to validate error messages in Runner for DSI Signin if user have DSI access with multiple UKPRN added to his profile
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then User Click on switch access and change to dfesignin with file"ukprn_without10078001.csv"
	And user validates runner of the form for error message for user "<User>" with UKPRN as "<UKPRN>"
Examples:
	 |User                            | UKPRN    |
	 | digitalforms01+1@gmail.com | 10078001 |

@UIRegression
Scenario: 027_Verify that the user is not able to delete a Published form from dashboard
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then User change status of the new form to "Published"
	And the user tries to delete form and he shouldnt be able to delete it


@UIRegression
Scenario Outline: 028_Dashboard- Verify search forms -show filter-Form status
	When Click on StartNow link
	Then the home page should be displayed
	Then Click on show filter 
	Then Click on status 'In development'
	Then Click on search button
	Then Check the form status


@UIRegression
Scenario Outline: 029_Dashboard- Verify search forms -show filter-Access Type
	When Click on StartNow link
	Then the home page should be displayed
	Then Click on show filter 
	Then Click on Access Type 'DFE SignIn'
	Then Click on search button
	Then Check the form access type

@UIRegression
Scenario Outline: 030_Dashboard- Verify search forms -show filter-Modified on 
	When Click on StartNow link
	Then the home page should be displayed
	Then Click on show filter 
	Then Enter from date '1/1/2026' to todays date
	Then Click on search button


@UIRegression
Scenario Outline: 031_Dashboard- Verify search forms -show filter-created by 
	When Click on StartNow link
	Then the home page should be displayed
	Then Click on show filter 
	Then Enter name in created by  
	Then Click on search button
	Then Check the result

@UIRegression
Scenario: 032_Verify that if user enter a form name in pop up which is already exist then user should get an error that "This title is already in use for a different form"
	Given User is on Dashboard Page
	Then click on Start Now link
	Then I click on Create form button and create a new form
	Then I click on Create form button and create a new form with existing form name
