using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace POM_Selenium
{
    public class BaseClass
    {
        public static ChromeDriver chromeDriver;
        public void DriverConfigure()
        {

            chromeDriver = new ChromeDriver();
        }
        public void OpenBrowserAndURL()
        {
            var jsonData = JObject.Parse(File.ReadAllText(@"C:\Users\Muhammad Maaz\source\repos\POM_Selenium\POM_Selenium\Data.json"));
            string url = jsonData["baseUrl"].ToString();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            chromeDriver.Close();

        }
    }
}
