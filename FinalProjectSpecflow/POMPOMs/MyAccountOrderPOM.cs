using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class MyAccountOrderPOM
    {
        IWebDriver driver;
        public MyAccountOrderPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement accountOrderValue => driver.FindElement(By.CssSelector
                ("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
        public IWebElement getAccountOrderValue()
        {
            return accountOrderValue;
        }
    }
}
