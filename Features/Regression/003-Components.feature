Feature: 003-Digital form- Form component
Background:
	Given Navigate to Home page

@UIRegression
Scenario Outline: 001_Verify Detail component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Details' component
	Then Verify component label 'An expandable title that lets users reveal more detailed information only if they need it'
	Then Click on on the 'Details' Component
	Then Enter Title 'Detail component ' and content 'content<h1> heading</h1><p>paragraph</p>'
	Then Click on save button
	Then Click on preview button
	Then Verify 'First page' in page
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 002_Verify HTML component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'HTML' component
	Then Verify component label 'A block of text that you can apply basic HTML to, such as text formatting and hyperlinks'
	Then Click on on the 'HTML' Component
	Then Enter content in HTML content '<p>HTML content values.</p>'
	Then Click on preview button
	Then Verify 'First page' in page
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 003_Verify Inset text component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Inset text' component
	Then Verify component label 'A block of text that differentiates it from surrounding content, for example for quotes'
	Then Click on on the 'Inset text' Component
	Then Enter content in  content 'This is inset text content' in text 
	Then Click on preview button
	Then Verify 'First page' in page
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 004_Verify List component-Bullets
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Enter Add New List "<ListTitle>" and "<ListValue>"
	Then Click on create component in second page
	Then Verify 'List' component 
	Then Verify component label 'A series of bullet points'
	Then Click on on the 'List' Component
	Then Enter Title 'List2'
	Then Select the list "<ListTitle>" and list type 'Bullets'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        | ListTitle | ListValue   |
	| automationtest1 | List2     | item1,item2 |


@UIRegression
Scenario Outline: 005_Verify List component-numbered items
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'List' component 
	Then Verify component label 'A series of bullet points'
	Then Click on on the 'List' Component
	Then Enter Title 'List2'
	Then Select the list "<ListTitle>" and list type 'Numbered items'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        | ListTitle | ListValue   |
	| automationtest1 | List2     | item1,item2 |


@UIRegression
Scenario Outline: 006_Verify List component-Link
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'List' component 
	Then Verify component label 'A series of bullet points'
	Then Click on on the 'List' Component
	Then Enter Title 'List2'
	Then Select the list "<ListTitle>" and list type 'Links'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        | ListTitle | ListValue   |
	| automationtest1 | List2     | item1,item2 |


@UIRegression
Scenario Outline: 007_Verify Paragraph component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Paragraph' component
	Then Verify component label 'A block of text that differentiates it from surrounding content, for example for quotes'
	Then Click on on the 'Paragraph' Component
	Then Enter content in  content 'A block of text' in text 
	Then Click on preview button
	Then Verify 'First page' in page
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 008_Verify Autocomplete component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Autocomplete' component 
	Then Verify component label 'A series of bullet points'
	Then Click on on the 'Autocomplete' Component
	Then Enter Title 'auto complete '
	Then Select the list "List2"
	Then Enable optional in component 
	Then Click on save button
	Then Click on preview button
	Then Verify 'First page' in page
	Then Click on continue button
	Then Select "item1" in autocomplete 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |

	
@UIRegression
Scenario Outline: 009_Verify date component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Date and time' component
	Then Verify component label 'Users can enter the date and time in all available combinations within the component'
	Then Click on on the 'Date and time' Component
	Then Enter Title 'Title_Component'
	Then Add Date and Time
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Enter  the field "<Date>" Date in date component 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |Date          |
	| automationtest1 |2/7/2022/1/55 |


@UIRegression
Scenario Outline: 010_Verify file download component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Documents'
	Then Upload the file 'Access_List_15_7.csv' in designer
	Then Click on create component in second page
	Then Verify 'File download' component
	Then Verify component label 'Allow users to download files available for them'
	Then Click on on the 'File download' Component
	Then Enter Title 'Title_Component'
	Then Then User select the file in dropdown
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 011_Verify Email address component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Email address' component
	Then Verify component label 'A text box that users can enter an email address into'
	Then Click on on the 'Email address' Component
	Then Enter Title 'Email_Component'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<email>" Email component
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
	
Examples:
	| FormName        | email          |
	| automationtest1 | test@gmail.com |


@UIRegression
Scenario Outline: 012_Verify Multiline text component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Multiline text' component
	Then Verify component label "A text box for users to enter multiple lines of text into, for example as 'Additional info'"
	Then Click on on the 'Multiline text' Component
	Then Enter Title 'Multiline Component'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Multiline>" Multiline component 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |Multiline|
	| automationtest1 |  Multiline     |


@UIRegression
Scenario Outline: 013_Verify Telephone number component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Telephone number' component
	Then Verify component label "A text box for users to enter multiple lines of text into, for example as 'Additional info'"
	Then Click on on the 'Telephone number' Component
	Then Enter Title 'Telephone Component'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Telephone>" Telephone component 
	Then Click on continue button
	#Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        | Telephone |
	| automationtest1 |  12121212 |


@UIRegression
Scenario Outline: 014_Verify Text component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Text' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Text' Component
	Then Enter Title 'Text Component'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Text>" Text component
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component

Examples:
	| FormName        |Text|
	| automationtest1 |  test   |


@UIRegression
Scenario Outline: 015_Verify File upload component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'File upload' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'File upload' Component
	Then Enter Title 'File upload'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Upload the file  "<File_upload>" component 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |File_upload               |
	| automationtest1 |Access_List_15_7.csv		 |

@UIRegression
Scenario Outline: 016_Verify CheckBox component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Checkboxes' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Checkboxes' Component
	Then Enter Title 'Checkboxes'
	Then Select the list "List2"
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Select the Checkboxes "item1"
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression  
Scenario Outline: 017_Verify Radiobox component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Radios' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Radios' Component
	Then Enter Title 'Radios'
	Then Select the list "List2"
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Select the radio button "item1"
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 018_Verify selectbox component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Select' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Select' Component
	Then Enter Title 'Select'
	Then Select the list "List2"
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Select the select button "item1" in component
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |
	
@UIRegression
Scenario Outline: 019_Verify YesNo component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'YesNo' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'YesNo' Component
	Then Enter Title 'YesNo component'
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Select the yesNo component  "true"
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |

	
@UIRegression
Scenario Outline: 020-Data Import Component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Documents'
	Then Upload the file 'Dataset examplessmall NEW.csv' in designer
	Then Click on create component in second page
	Then Verify 'Data Import' component
	Then Verify component label 'Allow users to download files available for them'
	Then Click on on the 'Data Import' Component
	Then Enter Title 'Data Import Component'
	Then Then User select the file in dropdown
	Then Select the schema 
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Upload the file  'Dataset examplessmall NEW.csv' and validate 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |


@UIRegression
Scenario Outline: 021_Verify table component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Import data set'
	Then Upload the file 'Dataset examples-small-ukprn.csv' in import dataset
	Then Click on menu 'Design data set'
	Then design data set 
	Then Click on create component in second page
	Then Verify 'Table' component
	Then Verify component label 'Allow users to download files available for them'
	Then Click on on the 'Table' Component
	Then Enter Title 'table Component'
	Then User select the design data set
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 022_Verify tab component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Tabs' component
	Then Verify component label 'Allow users to download files available for them'
	Then Click on on the 'Tabs' Component
	Then Enter Title 'Tabs Component'
	Then User select the design data set for tab
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	Then clean the component
Examples:
	| FormName        | Number |
	| automationtest1 | 2      |

@UIRegression
Scenario Outline: 023_Verify number component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add prefix value pound
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12 |


@UIRegression
Scenario Outline: 024_Verify Number component with prefix-Designer
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add prefix value pound
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	Then Verify prefix value '£'
	And Enter  the field "<Number>" Number component 
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12 |


@UIRegression
Scenario Outline: 025_Verify Number component with suffix-Designer
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add suffix value 
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component in suffix
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12 |


@UIRegression 
Scenario Outline: 026_Verify Number component with precision-Designer
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add precision value 
	Then Click on save button
	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component in suffix
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12.88 |


@UIRegression
Scenario Outline: 027_Verify result component 
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add precision value 
	Then Click on save button
	Then Add calculation in designer 
	Then Click on create component in second page for result
	Then Click on on the 'Result' Component
	Then Enter Title 'Result Component'
	Then Select the calculation
	Then Click on save button
 	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component in suffix
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window

Examples:
	| FormName        | Number |
	| automationtest1 |     12.88 |

@UIRegression
Scenario Outline: 028_Verify result component -hide results
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Hide on page
	Then Click on save button
 	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component in suffix
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	#And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12.88 |

@UIRegression
Scenario Outline: 029_Verify result component -hide summary
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Hide on summary
	Then Click on save button
 	Then Click on preview button
	Then Click on continue button
	And Enter  the field "<Number>" Number component in suffix
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component

Examples:
	| FormName        | Number |
	| automationtest1 |     12.88 |


@UIRegression
Scenario Outline: 030_Form Menu- Verify if user is able to import a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Design data set'
	Then design data set for table

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 031_Form Menu- Verify if user is able to edit imported a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Design data set'
	Then edit the design data set 

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 032_Form Menu- Verify if user is able to delete  imported a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Design data set'
	Then Delete data set 

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 033_Form Menu- Verify if user is able to import a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Import data set'
	Then Upload the file 'Dataset examples-small-ukprn.csv' in import dataset in dataset

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 034_Form Menu- Verify if user is able to edit import a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Import data set'
	Then Upload the file 'Dataset examplessmall NEW.csv' in edit data set

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 035_Form Menu- Verify if user is able to delete import a data set
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Import data set'
	Then delete import data set 

Examples:
	| FormName        |
	| automationtest1 |

@UIRegression
Scenario Outline: 036-Verify Add condition value
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'Number' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'Number' Component
	Then Enter Title 'Number Component'
	Then Add precision value 
	Then Click on save button
	Then Click on menu 'Conditions'
	Then Add condition value "<DisplayName>","<Componentname>","<condition>","<value>"

Examples:
	| FormName        | DisplayName | Componentname  | condition | value |
	| automationtest1 | Condition   |Number Component  | is        | 12    |


@UIRegression 
Scenario Outline: 037-Verify import condition
	Given User is on Dashboard Page
	Then Verify Start Now link
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Import data set'
	Then Upload the file '2000.csv' in import dataset for condition
	Then Click on menu 'Conditions'
	Then Add condition value "<DisplayName>","<Componentname>","<condition>","<value>" in import

Examples:
	| FormName        | DisplayName | Componentname  | condition | value |
	| automationtest1 | Condition1   |Number Component  | is        | 12    |


@UIRegression
Scenario Outline: 038-Delete condition
	Given User is on Dashboard Page
	Then Verify Start Now link
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on menu 'Conditions'
	Then Delete "<DisplayName>" in condition
Examples:
	| FormName        | DisplayName |
	| automationtest1 | Condition1   |


@UIRegression 
Scenario Outline: 039_Verify DSI data access component
	Given User is on Dashboard Page
	Then click on Start Now link
	Then User Select the form "<FormName>"
	Then User click on Edit form in my form
	Then Click on create component in second page
	Then Verify 'DSI data access' component
	Then Verify component label "A text box that users can enter letters, numbers and symbols into"
	Then Click on on the 'DSI data access' Component
	Then Enter Title 'DSI data access Component'
	Then Click on save button
 	Then Click on preview button
	Then Click on continue button
	Then Click on continue button
	Then Verify 'Summary' in page
	Then Verify 'Submit' Button in summary
	Then Verify 'Save summary as PDF' Button in summary
	Then Click on 'Submit' button in summary
	Then Verify 'Submission complete' in page
	Then close the runner window
	And clean the component
Examples:
	| FormName        |
	| automationtest1 |




@UIRegression
Scenario Outline: 040_Verify Import List
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I add a list"<ListTitle>" file "<File_upload>" in import dataset
	And I click on Lists from form menu and create a list "<ListTitle>" by importing a file "<File_upload>"
	And I delete the created form using DF API Delete call
Examples:
	|File_upload               |ListTitle|
	|List-template.csv  	   |List    |

	
@UIRegression
Scenario Outline: 041_Verify edit List item
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I add a list"<ListTitle>" file "<File_upload>" in import dataset
	And I click on Lists from form menu and create a list "<ListTitle>" by importing a file "<File_upload>"
	And I add a new list"<ListTitle>" file "<File_upload_Updated>" in import dataset
	And I edit the created list and update list title "<ListTitle>" and file "<File_upload_Updated>"
	And I delete the created form using DF API Delete call
Examples:
	| File_upload       | ListTitle | File_upload_Updated |
	| List-template.csv | List      |    ListItems.csv    |

@UIRegression
Scenario Outline: 042_Verify remove List item
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I add a list"<ListTitle>" file "<File_upload>" in import dataset
	And I click on Lists from form menu and create a list "<ListTitle>" by importing a file "<File_upload>"
	And I remove a list item from the added list
	And I delete the created form using DF API Delete call
Examples:
	| File_upload       | ListTitle |
	| ListItems.csv | List      |   


@UIRegression
Scenario Outline: 043_Verify remove List
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I add a list"<ListTitle>" file "<File_upload>" in import dataset
	And I click on Lists from form menu and create a list "<ListTitle>" by importing a file "<File_upload>"
	And I deleted the created list
	And I delete the created form using DF API Delete call
Examples:
	| File_upload       | ListTitle |
	| ListItems.csv | List      |  


@UIRegression
Scenario Outline: 044_Verify the page add and edit functionality in form designer
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I add a new page with title "<NewPageName>" in the form
	And I edit the second page title "<EditedName>"
	Then verify page titles "<NewPageName>" and "<EditedName>" in form runner
	And I delete the created form using DF API Delete call
Examples:
	| NewPageName | EditedName					 |
	| Third page  |   Second Page_Edited         |

@UIRegression
Scenario: 045_Verify the duplciate and delete page functionality in form designer
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I edit the second page and click on duplicate page link
	Then I verify the duplicated page
	And I edit the duplicated page and click on delete page
	Then verify that the page got deleted
	And I delete the created form using DF API Delete call



@UIRegression
Scenario Outline: 046_Verify  if user is able to Add section
Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And the user add a new section "<SectionName>" to the form and verify the added section in the sections list
	And the user add the new section "<SectionName>" to the page
	Then user verifies the section name "<SectionName>" is added to the page
	And I delete the created form using DF API Delete call
	Examples:
	 |SectionName         | 
	 | PageSection_Normal | 


@UIRegression
Scenario Outline: 047 --Edit section
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And the user add a new section "<SectionName>" to the form and verify the added section in the sections list
	And I edit the newly added section title as "<SectionName>"
	And I delete the created form using DF API Delete call
	Examples:
	 |SectionName         | 
	 | PageSection_Normal |

	
@UIRegression
Scenario Outline: 048 --Delete section
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And the user add a new section "<SectionName>" to the form and verify the added section in the sections list
	And I delete the newly added section "<SectionName>" and verify that the deleted section is not displayed in the sections list
	And I delete the created form using DF API Delete call
	Examples:
	 |SectionName         | 
	 | PageSection_Normal | 

@UIRegression
Scenario: 049 --Skip Summary
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I click on summary behaviour and select skip summary
	And Click on preview button
	And I validate the summary is skipped in runner
	And I delete the created form using DF API Delete call

@UIRegression
Scenario Outline: 050_Verify form menu- import document
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I click on documents and import a file "<File_upload>"
	And I delete the created form using DF API Delete call
Examples:
	|File_upload               |
	|Access_List_15_7.csv	   |
	
@UIRegression
Scenario Outline: 051_Verify form menu- edit document
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I click on documents and import a file "<File_upload>"
	And I click on documents and edit document with file "<Edit_File_Upload>"
	And I delete the created form using DF API Delete call
Examples:
	|File_upload               |Edit_File_Upload|
	|Access_List_15_7.csv	   |ukprn 1.csv	    |

@UIRegression
Scenario Outline: 052_Verify form menu- delete document
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	And I click on documents and import a file "<File_upload>"
	And I click on documents and delete document
	And I delete the created form using DF API Delete call
Examples:
	|File_upload               |
	|Access_List_15_7.csv	   |

@UIRegression
Scenario Outline: 053 Verify form menu- Outputs- API
	Given User is on Dashboard Page
	Then click on Start Now link
	And I create a form using DF API Post call
	Then User Click on switch access and change to dfesignin with file"<FileName>"
	And I click on outputs button and add a output "<OutputName>" with DSI
	Then I verify that the output "<OutputName>" is added
	And I delete the created form using DF API Delete call
Examples:
     | FileName    |OutputName|
     | ukprn 1.csv |  Output  |