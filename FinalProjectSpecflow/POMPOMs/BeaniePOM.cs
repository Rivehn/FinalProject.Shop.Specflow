using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class BeaniePOM
    {
        IWebDriver driver;
        public BeaniePOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement addToCart => driver.FindElement(By.CssSelector("button[name='add-to-cart']"));
        IWebElement cart => driver.FindElement(By.LinkText("Cart"));
        public IWebElement getAddToCart()
        {
            return addToCart;
        }
        public IWebElement getCart()
        {
            return cart;
        }
    }
}
