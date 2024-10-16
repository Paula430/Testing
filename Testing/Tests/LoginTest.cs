using Microsoft.Playwright.NUnit;
using WUP.Pages;

namespace WUP.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTest : PageTest
    {
        LoginPage loginPage;
        HomePage homePage;      

        [SetUp]
        public async Task Setup()
        {
            loginPage = new LoginPage(Page);
            homePage = new HomePage(Page);
            await loginPage.GoTo();
        }

        [Test]
        public async Task SignInPositiveTest()
        { 
            await loginPage.SignIn();
            await homePage.GoTo();
            await homePage.CheckLogin();
        }

        [Test]
        public async Task InCorrectEmailTest()
        {
            string password = "Test123$";
            string email = "p.kawalecinfomex.pl";
            await loginPage.SignInInCorrectEmail(email, password);
            await homePage.CheckLogin("negative");
        }
    }
}
