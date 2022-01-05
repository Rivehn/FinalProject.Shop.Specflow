Feature: OrderAnItem

User logs in, selects an item from the shop and adds to cart, 
goes to checkout, applies a coupon and places an order, finally 
verifying the order number in my accounts

@Dryrun
Scenario: Apply a discount and verify a placed order
	Given The user is logged in with 'peter.deng@nfocus.co.uk' and 'Q8UGRr2K27ZW2hJ'
	When the user adds an item of clothing
	And applies a discount coupon 'edgewords'
	And places an order
	Then the order appears in their account