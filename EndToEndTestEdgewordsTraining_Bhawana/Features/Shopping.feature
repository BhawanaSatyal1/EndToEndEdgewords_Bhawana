@regression 

Feature: Complete shopping activities 
@login 
Scenario: Login with valid credentials 

	Given I am on egdewordstraining homepage
    When I type in valid username
	And I type in valid password
	Then I should be logged in successfully

@addToCart 

Scenario: verify AddTo Cart Functionalities 

Given I am already logged in 
When I click on Shop Tab 
And  I add Hoddie with Pocket & click view cart 
And I  apply discount & The total calculation must be correct
Then I log out successfully 



@completeShopping  
Scenario: verify billing functionalities 

Given I am logged in  & have item added to cart 
When I proceed to checkout
And I complete billing details 
And I place order & order number should be generated 
Then I log out 

