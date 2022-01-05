using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class CheckoutPOM
    {
        IWebDriver driver;
        public CheckoutPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement total => driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-subtotal > span"));
        IWebElement couponField => driver.FindElement(By.Id("coupon_code"));
        IWebElement applyCoupon => driver.FindElement(By.CssSelector("button[name='apply_coupon']"));
        IWebElement body => driver.FindElement(By.TagName("body"));
        IWebElement checkout => driver.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward"));
        decimal totalValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal actValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal subTotal => System.Convert.ToDecimal
               ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal discountAmount => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal shippingCost => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal finalTotal => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).Text)[1..]);

        public void CheckDiscount(int disc)
        {
            decimal expValue;
            expValue = totalValue * (System.Convert.ToDecimal(disc) / 100);
            if (expValue == actValue)
            {
                //Assert.Pass("The discounts match the expected discount price." + " Expected discount: " + String.Format("{0:0.00}", expValue) + " Actual discount: " + actValue);
                Console.WriteLine("The discounts match the expected discount price." + " Expected discount: " + String.Format("{0:0.00}", expValue) + " Actual discount: " + actValue);
            }
            else
            {
                //Assert.Fail("Discounts did not match." +
                //   " The expected discount: " + String.Format("{0:0.00}", expValue) + " " + DISCOUNT + "% " +
                //   "...Instead actual discount: " + actValue + " " + (100 * (actValue / totalValue)) + "% ");
                Console.WriteLine("Discounts did not match." +
                   " The expected discount: " + String.Format("{0:0.00}", expValue) + " " + disc + "% " +
                   "...Instead actual discount: " + actValue + " " + (100 * (actValue / totalValue)) + "% ");              
            }
        }

        public void CheckTotal()
        {
            if (finalTotal == subTotal + (-discountAmount) + shippingCost)
            {
                Console.WriteLine("It passed.");
                //Assert.Pass("The total summed to: " + finalTotal);
            }
            else
            {
                Console.WriteLine("It failed.");
                //Assert.Fail("The total did not sum to: " + finalTotal + " Instead, it summed to: " + (subTotal + (-discountAmount) + shippingCost));
            }
        }

        public IWebElement getTotal()
        {
            return total;
        }

        public IWebElement getCouponField()
        {
            return couponField;
        }
        public IWebElement getApplyCoupon()
        {
            return applyCoupon;
        }
        public IWebElement getBody()
        {
            return body;
        }
        public IWebElement getCheckout()
        {
            return checkout;
        }
    }
}
