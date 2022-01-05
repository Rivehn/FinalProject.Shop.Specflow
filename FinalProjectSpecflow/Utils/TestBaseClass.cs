using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectSpecflow.POMPOMs;

namespace FinalProjectSpecflow.Utils
{
    [Binding]
    public class TestBaseClass
    {
        public static IWebDriver? driver;

        public const int DISCOUNT = 10; // 100 = 100% ACTUAL DISCOUNT = 15
        public string? orderNumber; //Captured after checkout
        public string? accountOrder; //Captured in My accounts
        public LoginPOM loginPOM = new(driver);
        public ShopPOM shopPOM = new(driver);
        public CheckoutPOM checkout = new(driver);
        public BillPOM bill = new(driver);
        public OrderPOM order = new(driver);
        public MyAccountPOM account = new(driver);
        public BeaniePOM beanie = new(driver);
        public MyAccountOrderPOM myAccountOrder = new(driver);
        [BeforeTestRun]
        public static void Setup()
        {
            ChromeOptions options = new();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            driver.FindElement(By.LinkText("Dismiss")).Click();

        }
        [AfterTestRun]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
