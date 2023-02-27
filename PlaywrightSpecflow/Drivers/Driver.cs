using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
