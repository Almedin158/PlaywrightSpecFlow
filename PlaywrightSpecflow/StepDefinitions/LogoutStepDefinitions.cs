using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.PageObjectModels;
using PlaywrightSpecflow.Pages;
using System;
using TechTalk.SpecFlow;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {
        private Driver _driver;
        private LoginPage _loginPage;
        private InventoryPage _inventoryPage;
        public LogoutStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
            _inventoryPage= new InventoryPage(_driver.Page);
        }

        [Given(@"I am logged in to SourceLabs")]
        public async Task GivenIAmLoggedInToSourceLabs()
        {
            await _driver.Page.GotoAsync("https://www.saucedemo.com/inventory.html");
        }

        [When(@"I open the side menu")]
        public async Task WhenIOpenTheSideMenu()
        {
            await _inventoryPage.OpenSidebar();
        }

        [When(@"I click the logout button")]
        public async Task WhenIClickTheLogoutButton()
        {
            await _inventoryPage.Logout();
        }

        [Then(@"I should be redirected to the login page")]
        public async Task ThenIShouldBeRedirectedToTheLoginPage()
        {
            Assert.AreEqual("https://www.saucedemo.com/", _driver.Page.Url);
        }

        [When(@"I try to access a protected page")]
        public async Task WhenITryToAccessAProtectedPage()
        {
            await _driver.Page.GotoAsync("https://www.saucedemo.com/inventory.html");
        }

        [Then(@"I should see a error message")]
        public async Task ThenIShouldSeeAErrorMessage()
        {
            Assert.IsTrue(await _loginPage.GetLoginErrorMessage().IsVisibleAsync());
        }
    }
}
