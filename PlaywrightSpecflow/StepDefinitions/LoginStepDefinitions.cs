using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.Pages;
using System;
using System.Data.SqlTypes;
using TechTalk.SpecFlow;

namespace PlaywrightSpecflow.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Login")]
    public class LoginStepDefinitions
    {
        private Driver _driver;
        private LoginPage _loginPage;
        public LoginStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
        }

        [Given(@"I am on the Sauce Demo login page")]
        public async Task GivenIAmOnTheSauceDemoLoginPage()
        {
            await _driver.Page.GotoAsync("https://www.saucedemo.com");
        }

        [When(@"I enter valid username ""([^""]*)"" and password ""([^""]*)""")]
        public async Task WhenIEnterValidUsernameAndPassword(string p0, string p1)
        {
            await _loginPage.EnterUsername(p0);
            await _loginPage.EnterPassword(p1);
        }

        [When(@"I click the login button")]
        public async Task WhenIClickTheLoginButton()
        {
            await _loginPage.ClickLogin();
            var storageState = await _driver.context.StorageStateAsync();
            await File.WriteAllTextAsync("storage-state.json", JsonConvert.SerializeObject(storageState));
        }

        [Then(@"I should be redirected to the Sauce Demo products page")]
        public async Task ThenIShouldBeRedirectedToTheSauceDemoProductsPage()
        {
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", _driver.Page.Url);
        }

        [When(@"I enter invalid username ""([^""]*)"" and password ""([^""]*)""")]
        public async Task WhenIEnterInvalidUsernameAndPassword(string p0, string p1)
        {
            await _loginPage.EnterUsername(p0);
            await _loginPage.EnterPassword(p1);
        }

        [Then(@"I should see an error message ""([^""]*)""")]
        public async Task ThenIShouldSeeAnErrorMessage(string p0)
        {
            Assert.AreEqual(p0, await _loginPage.GetLoginErrorMessage().InnerTextAsync());
        }

        [When(@"I enter password ""([^""]*)""")]
        public async Task WhenIEnterPassword(string p0)
        {
            await _loginPage.EnterPassword(p0);
        }

        [When(@"I enter username ""([^""]*)""")]
        public async Task WhenIEnterUsername(string p0)
        {
            await _loginPage.EnterUsername(p0);
        }

        [When(@"I enter username ""([^""]*)"" and invalid password ""([^""]*)""")]
        public async Task WhenIEnterUsernameAndInvalidPassword(string p0, string p1)
        {
            await _loginPage.EnterUsername(p0);
            await _loginPage.EnterPassword(p1);
        }
    }
}
