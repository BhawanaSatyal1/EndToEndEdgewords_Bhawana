@regression

Feature: Complete shopping activities
@smoke
Scenario: Login with valid credentials

	Given I am on egdewordstraining homepage
	When I type in valid username
	And I type in valid password
	Then I should be logged in successfully

@sanity

Scenario: verify AddTo Cart Functionalities


	Given I am Logged in as registered user
	When I add an item to the cart
	Then I  apply discount & The total calculation must be correct




@functional
Scenario: verify billing functionalities
	Given I am logged in  & have item added to cart
	When I proceed to checkout
	And I complete billing details
		| Field     | Value           |
		| FirstName | Bhawana         |
		| LastName  | Satyal          |
		| HouseName | 55 Kings St     |
		| City      | London          |
		| Postcode  | NW10 1TT        |
		| PhoneNum  | 0777777777      |
		| Bil_Email | xyz@hotmail.com |
	
	Then I place order & order number should be generated


