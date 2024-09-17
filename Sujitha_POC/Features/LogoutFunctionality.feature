Feature: LogoutFunctionality

A short summary of the feature

@Smoke
Scenario: LogoutScenario
	Given Enter the Orange HRM Portal Login URL
	When Enter the "<Username>","<Password>" and click on Login button
	Then Verify moved to Dashboard page and click on logout
	Examples: 
	| Username | Password |
	| Admin    | admin123 |
