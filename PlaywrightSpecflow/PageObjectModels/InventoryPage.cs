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
        private ILocator _liSocialFacebook => _page.Locator(".social_facebook");
        private ILocator _liSocialLinkedIn => _page.Locator(".social_linkedin");
        private ILocator _liSocialTwitter => _page.Locator(".social_twitter");
        private ILocator _divShoppningCartContainer => _page.Locator("#shopping_cart_container");

        public async Task OpenSidebar()
        {
            await _btnBurgerMenuButton.ClickAsync();
        }

        public async Task Logout()
        {
            await _aLogoutSidebarLink.ClickAsync();
        }

        public async Task ClickYourCart()
        {
            await _divShoppningCartContainer.ClickAsync();
        }
        public async Task ClickFacebook()
        {
            await _liSocialFacebook.ClickAsync();
        }
        public async Task ClickTwitter()
        {
            await _liSocialTwitter.ClickAsync();
        }
        public async Task ClickLinkedIn()
        {
            await _liSocialLinkedIn.ClickAsync();
        }
    }
}
