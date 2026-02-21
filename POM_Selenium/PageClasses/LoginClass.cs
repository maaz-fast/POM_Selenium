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
    public class LoginClass : BaseClass
    {
        public void ValidLogin()
        {
            var jsonData = JObject.Parse(File.ReadAllText(@"C:\Users\Muhammad Maaz\source\repos\POM_Selenium\POM_Selenium\Data.json"));

            var userName = jsonData["validUsername"].ToString();
            var password = jsonData["validPassword"].ToString();
            var expectedProductText = jsonData["producttext"].ToString();

            chromeDriver.FindElement(By.Id(LocatorClass.UserName)).SendKeys(userName);
            chromeDriver.FindElement(By.Id(LocatorClass.Password)).SendKeys(password);
            chromeDriver.FindElement(By.Id(LocatorClass.LoginButton)).Click();

            var actualProductText = chromeDriver.FindElement(By.XPath(LocatorClass.ExpectedProdcutTextLocator)).Text;
            Assert.AreEqual(expectedProductText, actualProductText);
        }

        public void InValidLogin()
        {
            var jsonData = JObject.Parse(File.ReadAllText(@"C:\Users\Muhammad Maaz\source\repos\POM_Selenium\POM_Selenium\Data.json"));

            var invalidUserName = jsonData["invalidUsername"].ToString();
            var invalidPass = jsonData["invalidPassword"].ToString();
            var expectedError = jsonData["invalidLoginError"].ToString();


            chromeDriver.FindElement(By.Id(LocatorClass.UserName)).SendKeys(invalidUserName);
            chromeDriver.FindElement(By.Id(LocatorClass.Password)).SendKeys(invalidPass);
            chromeDriver.FindElement(By.Id(LocatorClass.LoginButton)).Click();

            var actualError = chromeDriver.FindElement(By.XPath(LocatorClass.ErrorMessage)).Text;
            Assert.AreEqual(expectedError, actualError);
        }
    }
}
