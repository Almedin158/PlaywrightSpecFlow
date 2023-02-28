using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.PageObjectModels;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    public class ResetAppStateStepDefinitions
    {
        private Driver _driver;
        private InventoryPage _inventoryPage;

        public ResetAppStateStepDefinitions(Driver driver)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(_driver.Page);
        }


        [When(@"I add a product to the cart")]
        public async Task WhenIAddAProductToTheCart()
        {
            await _inventoryPage.AddBackpackToCart();
        }

        [When(@"I click the ResetAppState button")]
        public async Task WhenIClickTheResetAppStateButton()
        {
            _inventoryPage.ResetAppState();
        }

        [Then(@"Cart should be emptied")]
        public async Task ThenCartShouldBeEmptied()
        {

            //Waits for up to 1 seconds to check if the element is hidden, earlier had an issue where the test would fail since it would check too fast and the actual DOM would not change in time
            await _inventoryPage.GetShoppingCartBadge().WaitForAsync(new Microsoft.Playwright.LocatorWaitForOptions { State = Microsoft.Playwright.WaitForSelectorState.Hidden, Timeout=1000 });
            Assert.IsFalse(await _inventoryPage.GetShoppingCartBadge().IsVisibleAsync());
        }

        [Then(@"Product Remove button should be change back to Add To Cart")]
        public async Task ThenProductRemoveButtonShouldBeChangeBackToAddToCart()
        {
            Assert.IsTrue(await _inventoryPage.GetAddBackpackToCart().IsVisibleAsync());
        }

        [When(@"I change the product sort order")]
        public async Task WhenIChangeTheProductSortOrder()
        {
            await _inventoryPage.SelectHighToLowOrder();
        }

        [Then(@"Product sort order should be changed back to the default order")]
        public async Task ThenProductSortOrderShouldBeChangedBackToTheDefaultOrder()
        {
            Assert.AreEqual("az", await _inventoryPage.GetProductSortContainerOrder().InputValueAsync());
        }

    }
}