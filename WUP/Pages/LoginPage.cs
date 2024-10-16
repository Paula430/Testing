using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Playwright;

namespace WUP.Pages
{
    public class LoginPage : BasePage
    {
        public override string BaseLink { get { return "/login"; } }
        public LoginPage(IPage page) : base(page) { }

        private ILocator InputEmail => _page.GetByPlaceholder("Wprowadź email...");
        private ILocator InputPassword => _page.GetByPlaceholder("Wprowadź hasło...");
        private ILocator BtnLogin => _page.GetByRole(AriaRole.Button, new() { Name = "Zaloguj" });

        private readonly string Password = "Test123$";
        private readonly string Email = "p.kawalec@infomex.pl";

        public async Task SignIn()
        {
            await InputEmail.FillAsync(Email);
            await InputPassword.FillAsync(Password);
            await BtnLogin.ClickAsync();
            await _page.WaitForRequestFinishedAsync();
        }

        public async Task SignInInCorrectEmail(string email, string pass)
        {
            await InputEmail.FillAsync(email);
            await InputPassword.FillAsync(pass);
            await BtnLogin.ClickAsync();
        }

    }
}
