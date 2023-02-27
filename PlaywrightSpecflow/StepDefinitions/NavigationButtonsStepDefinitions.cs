using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.PageObjectModels;
using System;
using TechTalk.SpecFlow;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    public class NavigationButtonsStepDefinitions
    {
        public Driver _driver;
        private InventoryPage _inventoryPage;
        private IPage newPage;
        public NavigationButtonsStepDefinitions(Driver driver)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(_driver.Page);
        }


        [When(@"I click the your cart button")]
        public async Task WhenIClickTheYourCartButton()
        {
            await _inventoryPage.ClickYourCart();
        }

        [Then(@"I should be redirected to the cart page")]
        public async Task ThenIShouldBeRedirectedToTheCartPage()
        {
            Assert.AreEqual("https://www.saucedemo.com/cart.html", _driver.Page.Url);
        }
        [When(@"I click the Facebook button")]
        public async Task WhenIClickTheFacebookButton()
        {
            newPage = await _driver.context.RunAndWaitForPageAsync(async () =>
            {
                await _inventoryPage.ClickFacebook();
            });

            await newPage.WaitForLoadStateAsync();
        }

        [Then(@"I should be redirected to the Facebook page")]
        public async Task ThenIShouldBeRedirectedToTheFacebookPage()
        {
            Assert.AreEqual("https://www.facebook.com/saucelabs", newPage.Url);
        }

        [When(@"I click the Twitter button")]
        public async Task WhenIClickTheTwitterButton()
        {
            newPage = await _driver.context.RunAndWaitForPageAsync(async () =>
            {
                await _inventoryPage.ClickTwitter();
            });

            await newPage.WaitForLoadStateAsync();

        }

        [Then(@"I should be redirected to the Twitter page")]
        public async Task ThenIShouldBeRedirectedToTheTwitterPage()
        {
            Assert.AreEqual("https://twitter.com/saucelabs", newPage.Url);
        }

        [When(@"I click the LinkedIn button")]
        public async Task WhenIClickTheLinkedInButton()
        {
            newPage = await _driver.context.RunAndWaitForPageAsync(async () =>
            {
                await _inventoryPage.ClickLinkedIn();
            });

            await newPage.WaitForLoadStateAsync();
        }

        [Then(@"I should be redirected to the LinkedIn page")]
        public async Task ThenIShouldBeRedirectedToTheLinkedInPage()
        {
            StringAssert.Contains("https://www.linkedin.com/company/sauce-labs/", newPage.Url);
        }

    }
}
