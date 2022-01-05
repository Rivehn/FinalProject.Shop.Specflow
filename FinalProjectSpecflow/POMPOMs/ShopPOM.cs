using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecflow.POMPOMs
{
    public class ShopPOM
    {
        IWebDriver driver;

        public ShopPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement beanie => driver.FindElement(By.CssSelector("#main > ul > li.post-27.product.type-product.status-publish.has-post-thumbnail.product_cat-accessories.first.instock.sale.shipping-taxable.purchasable.product-type-simple"));

        public IWebElement getBeanie()
        {
            return beanie;
        }
    }
}
