using Microsoft.Playwright;
using Microsoft.Playwright.TestAdapter;
using NUnit.Framework;

namespace PlaywrightSpecflow.Drivers
{
    public class Driver:IDisposable
    {
        private readonly Task<IPage> _page;
        public IBrowserContext context;
        public Driver()
        {
            _page = Task.Run(InitializePlaywright);
        }

        public IPage Page => _page.Result;
        //Vidi da dodas playwright expect assertione
        public async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
            IBrowser _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            context = await _browser.NewContextAsync(new() { StorageStatePath = "state.json" });
            //Page
            return await context.NewPageAsync();
        }

        public void Dispose()
        {
            context?.CloseAsync();
        }
    }
}
