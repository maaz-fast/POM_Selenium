using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POM_Selenium
{
    [TestClass]
    public class SwagLabTests
    {
        LoginClass loginClass;
        ProductClass productClass;
        ShipmentOrderClass shipmentOrderClass;

        [TestInitialize]
        public void Setup()
        {
            loginClass = new LoginClass();
            productClass = new ProductClass();
            shipmentOrderClass = new ShipmentOrderClass();

            loginClass.DriverConfiguration();
            loginClass.OpenBrowserAndURL();
        }

        [TestCleanup]
        public void Cleanup()
        {
            loginClass.CloseBrowser();
        }

        [TestMethod]
        public void ValidLogin()
        {
            loginClass.ValidLogin();
        }

        [TestMethod]
        public void InValidLogin()
        {
            loginClass.InValidLogin();
        }

        [TestMethod]
        public void FirstNameError()
        {
            loginClass.ValidLogin();
            productClass.AddProductToCart();
            shipmentOrderClass.InValidShipmentOrder();
        }

        [TestMethod]
        public void OrderPlacemmet()
        {
            loginClass.ValidLogin();
            productClass.AddProductToCart();
            shipmentOrderClass.ValidShipmentOrder();
        }
    }
}