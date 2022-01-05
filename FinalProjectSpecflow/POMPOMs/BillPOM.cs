using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class BillPOM
    {
        IWebDriver driver;
        public BillPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement firstname => driver.FindElement(By.Id("billing_first_name"));
        IWebElement lastname => driver.FindElement(By.Id("billing_last_name"));
        IWebElement company => driver.FindElement(By.Id("billing_company"));
        IWebElement addressOne => driver.FindElement(By.Id("billing_address_1"));
        IWebElement addressTwo => driver.FindElement(By.Id("billing_address_2"));
        IWebElement city => driver.FindElement(By.Id("billing_city"));
        IWebElement state => driver.FindElement(By.Id("billing_state"));
        IWebElement postcode => driver.FindElement(By.Id("billing_postcode"));
        IWebElement phone => driver.FindElement(By.Id("billing_phone"));
        IWebElement email => driver.FindElement(By.Id("billing_email"));
        IWebElement checkPayment => driver.FindElement(By.CssSelector(".payment_method_cheque.wc_payment_method > label"));
        IWebElement order => driver.FindElement(By.CssSelector("button#place_order"));
        public void KillBill() //Extra Killer Form Filler
        {
            //first name
            firstname.Clear();
            firstname.SendKeys("Peter");
            //last name
            lastname.Clear();
            lastname.SendKeys("Deng");
            //company name
            company.Clear();
            company.SendKeys("nFocus");
            //street address
            addressOne.Clear();
            addressOne.SendKeys("University Rd");
            //apartment
            addressTwo.Clear();
            addressTwo.SendKeys("Building 36");
            //town / city
            city.Clear();
            city.SendKeys("Southampton ");
            //county
            state.Clear();
            state.SendKeys("Hampshire");
            //postcode
            postcode.Clear();
            postcode.SendKeys("SO17 1BJ");
            //phone
            phone.Clear();
            phone.SendKeys("02380592180");
            //email address
            email.Clear();
            email.SendKeys("peter.deng@nfocus.co.uk");
        }

        public IWebElement getCheckPayment()
        {
            return checkPayment;
        }
        public IWebElement getOrder()
        {
            return order;
        }

    }


}
