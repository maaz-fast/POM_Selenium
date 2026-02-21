using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace POM_Selenium
{
    public class BaseClass
    {
        public static ChromeDriver chromeDriver;

        public  void DriverConfiguration()
            {
                chromeDriver = new ChromeDriver();
            }
        public void OpenBrowserAndURL()
        {
            var jsonData = JObject.Parse(File.ReadAllText(
        "C:\\Users\\Muhammad Maaz\\source\\repos\\POM_Selenium\\POM_Selenium\\Data.json" ));
            var baseUrl = jsonData["baseUrl"].ToString();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl(baseUrl);
        }
        public void CloseBrowser()
        {
            chromeDriver.Close();
        }

    }
}
