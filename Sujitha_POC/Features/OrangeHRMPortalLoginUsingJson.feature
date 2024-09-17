Feature: OrangeHRMPortalLoginUsingJson

Orange HRM Portal login scenario

@Smoke
Scenario: OrangeHRMPortalLoginUsingJson
	Given Enter the Orange HRM Portal Login URL
	When Login using "Login.json" with "<UserType>" and click on Login button
	Then Verify moved to Dashboard page
	Examples: 
	| UserType      |
	| OrangeHRMUser |