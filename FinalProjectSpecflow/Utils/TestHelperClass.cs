using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.Utils
{
    public static class TestHelperClass
    {
        public static void UtilThreadSleeper(int seconds) //For all your most intense hatred of AJAX needs, just add how many seconds you want to KO the stupid machine for!
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void UtilUltraWaiter(IWebDriver driver, int seconds, By element) //Instantiate a unique wait object
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(drv => drv.FindElement(element).Displayed);
        }

        public static void UtilBasketClearer(IWebDriver driver) //MUST be at the basket page before calling this method
        {
            UtilThreadSleeper(5);//First wait for any leftover AJAX not accounted for.
            //Clear Coupon
            driver.FindElement(By.CssSelector(".woocommerce-remove-coupon")).Click();
            UtilThreadSleeper(5);
            //Clear Basket
            driver.FindElement(By.CssSelector(".remove")).Click(); //ONLY works with one item in basket I believe
        }

        public static void ElementBonker(IWebDriver driver, int seconds, IWebElement element) //Bonks an element (clicks it)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(drv => element.Displayed);
            element.Click();
        }
    }
}
