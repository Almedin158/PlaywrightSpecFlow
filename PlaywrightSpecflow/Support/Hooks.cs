using Microsoft.Playwright;

namespace PlaywrightSpecflow.Support
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            var playwright = await Playwright.CreateAsync();
            //Browser
            IBrowser _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var context = await _browser.NewContextAsync();
            //Page
            var Page = await context.NewPageAsync();

            await Page.GotoAsync("https://www.saucedemo.com/");

            await Page.Locator("#user-name").FillAsync("standard_user");
            await Page.Locator("#password").FillAsync("secret_sauce");
            await Page.Locator("#login-button").ClickAsync();

            await context.StorageStateAsync(new()
            {
                Path = "state.json"
            });

            await context.DisposeAsync();
        }
    }
}