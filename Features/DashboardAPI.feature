Feature: API Testing
@apitest
Rule: Execute API testing 
@APIRegression
Scenario: 001-Add new configration 
    When I send a POST request to addConfiguration
	Then the status code should be 200

@APIRegression
Scenario: 002-Check the listform configration API
	When I send a GET request to "listFormConfigurations"
	Then the response should contain "up94y_am1j"

@APIRegression
Scenario: 003-Update new configration 
    When I send a POST request to updateconfigration
	Then the status code should be 200
	Then the response should contain "testapicodeupdated"

@APIRegression
Scenario: 004-Checkform Exist
    When I check the form exist "testapicodeupdated"
	Then the status code should be 200

@APIRegression
Scenario:005-Getformid getConfiguration
  When I check the form id exist 'up94y_am1j'
  	Then the status code should be 200

@APIRegression
Scenario:006-upload configration 
  When upload the json file config 'up94y_am1j' with UKPRN '10078001'
  	Then the status code should be 200

@APIRegression
Scenario:007-Delete form 
  When delete the form  'up94y_am1j'
  Then the status code should be 200

