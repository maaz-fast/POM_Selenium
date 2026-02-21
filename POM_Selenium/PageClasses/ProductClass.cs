using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Selenium
{
    public class ProductClass : BaseClass
    {
        public void AddProductToCart()
        {
            chromeDriver.FindElement(By.Id(LocatorClass.Product1)).Click();

            chromeDriver.FindElement(By.XPath(LocatorClass.CartLink)).Click();

            chromeDriver.FindElement(By.Id(LocatorClass.CheckoutButton)).Click();
        }
    }
}
