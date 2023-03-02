using Microsoft.Playwright;

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
        private ILocator _btnAddToCartSourceLabsBackpack => _page.Locator("#add-to-cart-sauce-labs-backpack");
        private ILocator _spanShoppingCartBadge => _page.Locator(".shopping_cart_badge");
        private ILocator _aResetSidebarLink => _page.Locator("#reset_sidebar_link");
        private ILocator _selectProductSortContainer => _page.Locator(".product_sort_container");
        private ILocator _aAboutSidebarLink => _page.Locator("#about_sidebar_link");

        private string _divInventoryItemPrice = "div[class='inventory_item_price']";

        private string _divInventoryItemName = "div[class='inventory_item_name']";
        private ILocator _divSidebar => _page.Locator(".bm-menu-wrap");
        private ILocator _btnBurgetCrossButton => _page.Locator("#react-burger-cross-btn");






        public async Task OpenSidebar()
        {
            await _btnBurgerMenuButton.ClickAsync();
        }

        public async Task CloseSidebar()
        {
            await _btnBurgetCrossButton.ClickAsync();
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

        public async Task ClickAbout()
        {
            await _aAboutSidebarLink.ClickAsync();
        }

        public async Task AddBackpackToCart()
        {
            await _btnAddToCartSourceLabsBackpack.ClickAsync();
        }

        public ILocator GetAddBackpackToCart()
        {
            return _btnAddToCartSourceLabsBackpack;
        }

        public ILocator GetShoppingCartBadge()
        {
            return _spanShoppingCartBadge;
        }

        public ILocator GetSidebar()
        {
            return _divSidebar;
        }

        public async Task ResetAppState()
        {
            await _aResetSidebarLink.ClickAsync();
        }

        public async Task SelectHighToLowOrder()
        {
            await _selectProductSortContainer.SelectOptionAsync("hilo");
        }

        public async Task SelectLowToHighOrder()
        {
            await _selectProductSortContainer.SelectOptionAsync("lohi");
        }

        public async Task SelectAToZOrder()
        {
            await _selectProductSortContainer.SelectOptionAsync("az");
        }
        public async Task SelectZToAOrder()
        {
            await _selectProductSortContainer.SelectOptionAsync("za");
        }
        public ILocator GetProductSortContainerOrder()
        {
            return _selectProductSortContainer;
        }

        public string GetProductNameLocator()
        {
            return _divInventoryItemName;
        }

        public string GetProductPriceLocator()
        {
            return _divInventoryItemPrice;
        }
    }
}
