using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSpecflow.PageObjectModels
{
    internal class InventoryPage
    {
        private IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        private ILocator _btnBurgerMenuButton => _page.Locator("#react-burger-menu-btn");
        private ILocator _aLogoutSidebarLink => _page.Locator("#logout_sidebar_link");

        public async Task OpenSidebar()
        {
            await _btnBurgerMenuButton.ClickAsync();
        }

        public async Task Logout()
        {
            await _aLogoutSidebarLink.ClickAsync();
        }
    }
}
