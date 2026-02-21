using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ShipmentOrderClass : BaseClass
    {
        public void ValidShipmentOrder()
        {
            var jsonData = JObject.Parse(File.ReadAllText(@"C:\Users\Muhammad Maaz\source\repos\POM_Selenium\POM_Selenium\Data.json"));
            var firstName = jsonData["firstName"].ToString();
            var lastName = jsonData["lastName"].ToString();
            var zipCode = jsonData["postalCode"].ToString();
            var orderConfirmationText = jsonData["orderConfirmation"].ToString();
            chromeDriver.FindElement(By.Id(LocatorClass.FirstName)).SendKeys(firstName);
            chromeDriver.FindElement(By.Id(LocatorClass.LastName)).SendKeys(lastName);
            chromeDriver.FindElement(By.Id(LocatorClass.Zipcode)).SendKeys(zipCode);
            chromeDriver.FindElement(By.Id(LocatorClass.ContinueButton)).Click();
            chromeDriver.FindElement(By.Id(LocatorClass.FinishButton)).Click();
            var actualOrderConfirmationText = chromeDriver.FindElement(By.XPath(LocatorClass.OrderConfirmation)).Text;
            Assert.AreEqual(orderConfirmationText, actualOrderConfirmationText);
        }

        public void InValidShipmentOrder()
        {
            var jsonData = JObject.Parse(File.ReadAllText(@"C:\Users\Muhammad Maaz\source\repos\POM_Selenium\POM_Selenium\Data.json"));
            
            var firstNameMissingError = jsonData["firstNameMissingError"].ToString();
            
            chromeDriver.FindElement(By.Id(LocatorClass.ContinueButton)).Click();
            var actualFirstNameMissingError = chromeDriver.FindElement(By.XPath(LocatorClass.FirstNameMissingError)).Text;
            Assert.AreEqual(firstNameMissingError, actualFirstNameMissingError);
        }
    }
}