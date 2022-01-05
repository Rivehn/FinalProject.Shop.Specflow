using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class OrderPOM
    {
        IWebDriver driver;
        public OrderPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement orderNumber => driver.FindElement(By.CssSelector(".order > strong"));
        IWebElement myAccount => driver.FindElement(By.LinkText("My account"));
        public IWebElement getOrderNumber()
        {
            return orderNumber;
        }
        public IWebElement getMyAccount()
        {
            return myAccount;
        }
    }
}
