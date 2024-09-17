Feature: OrangeHRMPortalLogin

Orange HRM Portal login scenario

@Smoke
Scenario: OrangeHRMPortalLogin
	Given Enter the Orange HRM Portal Login URL
	When Enter the "<Username>","<Password>" and click on Login button
	Then Verify moved to Dashboard page
	Examples: 
	| Username | Password |
	| Admin    | admin123 |

@Smoke
Scenario: OrangeHRMPortalLogout
	Given Enter the Orange HRM Portal Login URL
	When Enter the "<Username>","<Password>" and click on Login button
	Then Verify moved to Dashboard page and click on logout
	Examples: 
	| Username | Password |
	| Admin    | admin123 |
