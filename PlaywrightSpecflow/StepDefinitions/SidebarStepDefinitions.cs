using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.PageObjectModels;
using System;
using TechTalk.SpecFlow;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    public class SidebarStepDefinitions
    {
        public Driver _driver;
        private InventoryPage _inventoryPage;

        public SidebarStepDefinitions(Driver driver)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(_driver.Page);
        }

        [When(@"I click the burget button")]
        public async Task WhenIClickTheBurgetButton()
        {
            await _inventoryPage.OpenSidebar();
        }

        [Then(@"The sidebar should open")]
        public async Task ThenTheSidebarShouldOpen()
        {
            Assert.IsTrue(await _inventoryPage.GetSidebar().IsVisibleAsync());
        }

        [When(@"I click the burget cross button")]
        public async Task WhenIClickTheBurgetCrossButton()
        {
            await _inventoryPage.CloseSidebar();
        }

        [Then(@"The sidebar should close")]
        public async Task ThenTheSidebarShouldClose()
        {
            await _inventoryPage
                .GetSidebar()
                .WaitForAsync(new Microsoft.Playwright.LocatorWaitForOptions { State = Microsoft.Playwright.WaitForSelectorState.Hidden, Timeout = 1000 });
            Assert.IsTrue(await _inventoryPage.GetSidebar().IsHiddenAsync());
        }
    }
}
