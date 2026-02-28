using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POM_Selenium
{
    [TestClass]
    public class SwagLabTests
    {
        

        [TestMethod]
        public void ValidLogin()
        {
            LoginClass loginClass = new LoginClass();
            loginClass.DriverConfigure();
            loginClass.OpenBrowserAndURL();
            loginClass.ValidLogin();
            loginClass.CloseBrowser();
        }

        [TestMethod]
        public void InValidLogin()
        {
            LoginClass loginClass = new LoginClass();
            loginClass.DriverConfigure();
            loginClass.OpenBrowserAndURL();
            loginClass.InValidLogin();
            loginClass.CloseBrowser();
        }

        [TestMethod]
        public void FirstNameError()
        {
            LoginClass loginClass = new LoginClass();
            ProductClass productClass = new ProductClass();
            ShipmentOrderClass shipmentOrderClass = new ShipmentOrderClass();

            loginClass.DriverConfigure();
            loginClass.OpenBrowserAndURL();
            loginClass.ValidLogin();
            productClass.AddProductToCart();
            shipmentOrderClass.InValidShipmentOrder();
            loginClass.CloseBrowser();
        }

        [TestMethod]
        public void OrderPlacemmet()
        {
            LoginClass loginClass = new LoginClass();
            ProductClass productClass = new ProductClass();
            ShipmentOrderClass shipmentOrderClass = new ShipmentOrderClass();

            loginClass.DriverConfigure();
            loginClass.OpenBrowserAndURL();
            loginClass.ValidLogin();
            productClass.AddProductToCart();
            shipmentOrderClass.ValidShipmentOrder();
        }
    }
}