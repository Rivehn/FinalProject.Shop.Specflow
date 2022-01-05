using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class LoginPOM
    {
        IWebDriver driver;

        public LoginPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement usernameField => driver.FindElement(By.Id("username"));
        IWebElement passwordField => driver.FindElement(By.Id("password"));
        IWebElement submitButton => driver.FindElement(By.CssSelector("button[name='login']"));

        public void login(string username, string password)
        {
            usernameField.Clear();
            passwordField.Clear();
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }

        public void submit()
        {
            submitButton.Click();
        }

    }
}
