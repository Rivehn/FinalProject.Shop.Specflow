using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class MyAccountPOM
    {
        IWebDriver driver;

        public MyAccountPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement orders => driver.FindElement(By.LinkText("Orders"));
        IWebElement shop => driver.FindElement(By.LinkText("Shop"));
        IWebElement logout => driver.FindElement(By.CssSelector
                (".woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-" +
                "navigation-link--customer-logout > a"));
        public IWebElement getOrders()
        {
            return orders;
        }
        public IWebElement getShop()
        {
            return shop;
        }
        public IWebElement getLogout()
        {
            return logout;
        }
    }
}
