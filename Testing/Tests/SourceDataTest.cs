using Microsoft.Playwright.NUnit;
using WUP.Pages;
using WUP.Pages.SourceData;

namespace WUP.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SourceDataTest:PageTest
    {
        LoginPage LoginPage;
        HomeSDPage HomeSDPage;
        ImportSDPage ImportSDPage;
        PreviewDetailsSDPage PreviewDetailsSDPage;

        [SetUp]
        public async Task Setup()
        {
            LoginPage = new LoginPage(Page);
            ImportSDPage = new ImportSDPage(Page);
            PreviewDetailsSDPage = new PreviewDetailsSDPage(Page);
            HomeSDPage = new HomeSDPage(Page);
            await LoginPage.GoTo();
            await LoginPage.SignIn();
            await HomeSDPage.GoTo();
        }

        [Test]
        public async Task PreviewTest()
        {
            await PreviewDetailsSDPage.GoTo();
        }


    }
}
