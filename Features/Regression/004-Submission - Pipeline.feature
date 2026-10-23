Feature: Execute regression and RQ form and API calls
Background:

@Pipeliline
Scenario Outline: 001-Run Regression form in Dev
	Given User Navigated to runner with formID "<FormID>"
	Then Enter "<DFEUserName>" and "<Password>" and select the "<DFESignin>" in "<Org>"
	And Click on Save and continue
	And Click on Save and continue
	And Select 'Optional Fields' in Select component
	And Click on Save and continue
	And Check the page name "<PageName>"
	And check the Section name "<sectionName>"
	And Verify component in page
	And Verify Table component "<Org>"
	And Enter  the field "<Autocomplete>" autocomplete
	And Enter  the field "<Email>" Email
	And Upload the file  "<File_upload>"
	And Enter  the field "<Multiline>" Multiline
	And Enter  the field "<Telephone>" Telephone
	And Enter  the field "<Text>" Text
	And Select the radio button "<Radios>"
	And Select the select button "<Select>"
	And Select the yesNo component  "<YesNo>"
	And Select the Checkboxes "<Checkboxes>"
	And Enter  the field "<Number>" Number
	And Enter  the field "<Date>" Date
	And Click on Save and continue
	And Verify 'Summary' in page
	And Verify 'Submit' Button in summary
	And Verify 'Save summary as PDF' Button in summary
	And Click on 'Submit' button in summary
	And Verify 'Submission complete' in page
	#Then Click on Signout Button
Examples:
	| FormID     | FormName             | DFEUserName                | Password | DFESignin | Org      | PageName       | sectionName      | Autocomplete    | Email                          | File_upload          | Multiline                | Telephone | Text | Radios         | Select         | YesNo | Checkboxes     | Number | Date          | result |
	| v5a3x74w6k | regressionpack_ukprn | digitalforms01+2@gmail.com | Password | UKPRN     | 10078003 | OptionalFields | Optional section | Optional Fields | test@education.gov.uk		 | Access_List_15_7.csv | Multiline text component |    123456 | text | OptionalFields | OptionalFields | true  | OptionalFields |      2 | 2/7/2022/1/55 |        |
         

@Pipeliline
Scenario Outline: 002- Submitting RQ Phase 2 form
	Given User Navigated to runner with formID "<FormID>"
	Then Enter "<DFEUserName>" and "<Password>" and select the "<DFESignin>" in "<Org>"
	And verify Organization  "<Org>" and "<FormName>" in your detail page
	And I enter all input details in the form
	Then I validate the fields in summary page
	And I submit the form
	And Verify 'Submission complete' in page
Examples:
	| FormID     | FormName             | DFEUserName                | Password | DFESignin | Org      |
	| c0wtxe4tmp | RQ_Phase2_PT_24_07   | digitalforms01+2@gmail.com | Password | UKPRN     | 10078003 |

@Pipeliline	
Scenario Outline: 003- Change summary for RQ Phase 2 form
	Given User Navigated to runner with formID "<FormID>"
	Then Enter "<DFEUserName>" and "<Password>" and select the "<DFESignin>" in "<Org>"
	And verify Organization  "<Org>" and "<FormName>" in your detail page
	And I enter all input details in the form
	And I change values from summary page
	And I submit the form
	And Verify 'Submission complete' in page
Examples:
	| FormID     | FormName             | DFEUserName                | Password | DFESignin | Org      |
	| yx5m8zyqqv | RQ_PT_DuplicateForm_08072026   | digitalforms01+2@gmail.com | Password | UKPRN     | 10078003 |
