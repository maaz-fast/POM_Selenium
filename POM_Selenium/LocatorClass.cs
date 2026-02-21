using System;

namespace POM_Selenium
{
    public static class LocatorClass
    {
        // Login Page Locators
        public const string UserName = "user-name";
        public const string Password = "password";
        public const string LoginButton = "login-button";
        public const string ExpectedProdcutTextLocator = "//span[@class='title']";
        public const string ErrorMessage = "//h3[@data-test='error']";
        //h3[@data-test='error']

        //h3[@data-test='error']


        // Cart Page Locators
        public const string Product1 = "add-to-cart-sauce-labs-backpack";
        public const string CartLink = "//span[@class='shopping_cart_badge']";
        public const string CheckoutButton = "checkout";

        //CHeckOut Page Locators
        public const string FirstName = "first-name";
        public const string LastName = "last-name";
        public const string Zipcode = "postal-code";
        public const string ContinueButton = "continue";
        public const string OrderNumber = "//div[contains(text(),'SauceCard #31337')]";
        public const string FinishButton = "finish";
        public const string OrderConfirmation = "//h2[@class='complete-header']";
        public const string FirstNameMissingError = "//h3[@data-test='error']";
    }
}