using Microsoft.Playwright;

namespace PlaywrightSpecflow.Drivers
{
    //Since this is a custom implementation of Playwright, you are not able to use Playwrights "Expect" Assertions until a nugat package for it is released.
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
            //You can change LaunchAsync to LaunchPersistentContextAsync, but in this case you can not import cookies/state from another browser.
            IBrowser _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Starts the browser in incognito mode and imports cookies/state
            context = await _browser.NewContextAsync(new() { StorageStatePath = "state.json" });
            //Page
            return await context.NewPageAsync();
        }
        //Provjeri treba li ti dispose, vjerujem da playwright sam odradi dispose.
        public void Dispose()
        {
            context?.CloseAsync();
        }
    }
}
