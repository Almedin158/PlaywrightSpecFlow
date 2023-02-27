using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSpecflow.Pages
{
    internal class LoginPage
    {
        private IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator _txtUsername => _page.Locator("#user-name");
        private ILocator _txtPassword => _page.Locator("#password");
        private ILocator _btnLogin => _page.Locator("#login-button");
        private ILocator _h3LoginErrorMessage => _page.Locator("h3[data-test='error']");

        public async Task EnterUsername(string username)
        {
            await _txtUsername.FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await _txtPassword.FillAsync(password);
        }

        public async Task ClickLogin()
        {
            await _btnLogin.ClickAsync();
        }

        public ILocator GetLoginErrorMessage()
        {
            return _h3LoginErrorMessage;
        }
    }
}
