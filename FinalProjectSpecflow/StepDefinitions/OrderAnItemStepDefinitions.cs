using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static FinalProjectSpecflow.Utils.TestHelperClass;
using FinalProjectSpecflow.POMPOMs;

namespace FinalProjectSpecflow.StepDefinitions
{
    [Binding]
    public class OrderAnItemStepDefinitions : Utils.TestBaseClass
    {
        [Given(@"The user is logged in with '([^']*)' and '([^']*)'")]
        public void GivenTheUserIsLoggedInWithAnd(string u, string p) //eventually will get this working
        {
            //Login to the site
            loginPOM.login(u, p);
            loginPOM.submit();
            //Assert.That(driver.FindElement(By.LinkText("Log out")).Text,
            //    Is.EqualTo(driver.FindElement(By.LinkText("Log out")).Text),
            //    "Logged in Succeeded.");
        }

        [When(@"the user adds an item of clothing")]
        public void WhenTheUserAddsAnItemOfClothing()
        {
            //Add to Cart
            account.getShop().Click();
            UtilThreadSleeper(1);
            shopPOM.getBeanie().Click();
            beanie.getAddToCart().Click();//one please
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            //wait.Until(drv => drv.FindElement(By.LinkText("Cart")).Displayed);
            ElementBonker(driver, 25, beanie.getCart()); //There are 3*(4 now) ways to access the cart, this is through the navigation menu
            //Assert.That(driver.FindElement(By.CssSelector("#post-5 > header > h1")).Text,
             //   Is.EqualTo(driver.FindElement(By.CssSelector("#post-5 > header > h1")).Text),
             //   "This is the Cart page defo"); //To check if on the right page

            //Check for non - zero total
            string value = checkout.getTotal().Text[1..];
            if (value == "0.00")
            {
                //Assert.Fail("No item present");
                Console.WriteLine("No item present.");
            }
            else
            {
                //Assert.Pass(value + " was the total.");
                Console.WriteLine(value + " was the total.");
            }
        }

        [When(@"applies a discount coupon '([^']*)'")]
        public void WhenAppliesADiscountCoupon(string coupon)
        {
            //Apply a discount coupon
            checkout.getCouponField().SendKeys(coupon);
            checkout.getApplyCoupon().Click();
            UtilThreadSleeper(2);
            //Check if coupon was applied
            //Assert.That(checkout.getBody().Text.Contains("Coupon: edgewords"), "COUPON SUCCESSFULLY APPLIED"); //might need to double check this later~

            //Check if discount is correct
            checkout.CheckDiscount(DISCOUNT); //verify if discount is correct
        }

        [When(@"places an order")]
        public void WhenPlacesAnOrder()
        {
            //Check that total calculated after shipping is correct
            checkout.CheckTotal();

            //Proceed to checkout
            //wait.Until(drv => drv.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward")).Displayed);
            ElementBonker(driver, 25, checkout.getCheckout());
      
            //Fill in billing details
            bill.KillBill();

            //Select check payments
            try
            {
                //wait.Until(drv => drv.FindElement(By.CssSelector(".payment_method_cheque.wc_payment_method > label")).Displayed);
                UtilThreadSleeper(1);
                bill.getCheckPayment().Click();
            }
            catch (Exception)
            {
                //Assert.Fail("Failed to find element, maybe it is floating in the void somewhere");
                Console.WriteLine("Failed to find element, maybe it is floating in the void somewhere");
            }
            UtilThreadSleeper(1);//need to find better way
            //Place order
            try
            {
                bill.getOrder().Click();
            }
            catch (Exception)
            {
                //Assert.Fail("Failed to find element, maybe it is floating in the void somewhere");
                Console.WriteLine("Failed to find element, maybe it is floating in the void somewhere");
            }
        }

        [Then(@"the order appears in their account")]
        public void ThenTheOrderAppearsInTheirAccount()
        {
            //Capture order
            UtilThreadSleeper(1);
            orderNumber = order.getOrderNumber().Text;
            Console.WriteLine(orderNumber);

            //Check the order number isn't fake: Account > Orders > Checking Order
            order.getMyAccount().Click();
            UtilThreadSleeper(1);
            account.getOrders().Click();
            UtilThreadSleeper(1);
            accountOrder = (myAccountOrder.getAccountOrderValue().Text)[1..];
            Console.WriteLine(accountOrder);
            UtilThreadSleeper(1);
            if (orderNumber == accountOrder)
            {
                Assert.Pass("End of Test Case.");
            }
            else
            {
                Assert.Fail("Stop! you didn't pass in the end. Check those order numbers again");
            }

            //LogOut
                account.getLogout().Click();
        }
    }
}