Feature: OrangeHRMPortalLogout

Orange HRM Portal logout scenario

@Smoke
Scenario: OrangeHRMPortalLogout
	Given Enter the Orange HRM Portal Login URL
	When Enter the "<Username>","<Password>" and click on Login button
	Then Verify moved to Dashboard page
	Then Click on the username dropdown and click on logout
	Then Verify logout and moved to login page
	Examples: 
	| Username | Password |
	| Admin    | admin123 |
