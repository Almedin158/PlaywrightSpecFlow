using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.PageObjectModels;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.EnvironmentAccess;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    public class ProductSortContainerStepDefinitions
    {
        private Driver _driver;
        private InventoryPage _inventoryPage;

        public ProductSortContainerStepDefinitions(Driver driver)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(_driver.Page);
        }

        [When(@"I change the product sort order to Price \(high to low\)")]
        public async Task WhenIChangeTheProductSortOrderToPriceHighToLow()
        {
            await _inventoryPage.SelectHighToLowOrder();
        }

        [Then(@"I want the products to be displayed in a descending order by price")]
        public async Task ThenIWantTheProductsToBeDisplayedInADescendingOrderByPrice()
        {
            var products = await _driver.Page
                .Locator(_inventoryPage.GetProductPriceLocator())
                .AllAsync();
            List<double> productPrices = new List<double>();
            foreach (var product in products)
            {
                var productPrice = await product.InnerTextAsync();
                productPrices.Add(Convert.ToDouble(productPrice.Remove(0,1)));
            }
            var descending = productPrices.OrderByDescending(c => c);
            Assert.AreEqual(descending, productPrices);
            //NASTAVI OVDJE, preuzeo si lokator, .AllAsync preuzima sve elemente koji ispune kriterij
            //Znaci, gettaj atribute (cijenu u ovom slucaju) sortiraj i uporedi.
        }

        [When(@"I change the product sort order to Price \(low to high\)")]
        public async Task WhenIChangeTheProductSortOrderToPriceLowToHigh()
        {
            await _inventoryPage.SelectLowToHighOrder();
        }

        [Then(@"I want the products to be displayed in a ascending order by price")]
        public async Task ThenIWantTheProductsToBeDisplayedInAAscendingOrderByPrice()
        {
            var products = await _driver.Page
                .Locator(_inventoryPage.GetProductPriceLocator())
                .AllAsync();
            List<double> productPrices = new List<double>();
            foreach (var product in products)
            {
                var productPrice = await product.InnerTextAsync();
                productPrices.Add(Convert.ToDouble(productPrice.Remove(0, 1)));
            }
            var ascending = productPrices.OrderBy(c => c);
            Assert.AreEqual(ascending, productPrices);
        }

        [When(@"I change the product sort order to Name \(A to Z\)")]
        public async Task WhenIChangeTheProductSortOrderToNameAToZ()
        {
            await _inventoryPage.SelectAToZOrder();
        }

        [Then(@"I want the products to be displayed in a ascending order by name")]
        public async Task ThenIWantTheProductsToBeDisplayedInAAscendingOrderByName()
        {
            var products = await _driver.Page
                .Locator(_inventoryPage.GetProductNameLocator())
                .AllAsync();
            List<string> productNames = new List<string>();
            foreach (var product in products)
            {
                var productName = await product.InnerTextAsync();
                productNames.Add(productName);
            }
            var ascending = productNames.OrderBy(c => c);
            Assert.AreEqual(ascending, productNames);
        }

        [When(@"I change the product sort order to Name \(Z to A\)")]
        public async Task WhenIChangeTheProductSortOrderToNameZToA()
        {
            await _inventoryPage.SelectZToAOrder();
        }

        [Then(@"I want the products to be displayed in a descending order by name")]
        public async Task ThenIWantTheProductsToBeDisplayedInADescendingOrderByName()
        {
            var products = await _driver.Page
                .Locator(_inventoryPage.GetProductNameLocator())
                .AllAsync();
            List<string> productNames = new List<string>();
            foreach (var product in products)
            {
                var productName = await product.InnerTextAsync();
                productNames.Add(productName);
            }
            var descending = productNames.OrderByDescending(c => c);
            Assert.AreEqual(descending, productNames);
        }
    }
}
