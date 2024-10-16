using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUP.Locators;
using WUP.Locators.SourceDataLocators;

namespace WUP.Pages.SourceData
{
    public class PreviewDetailsSDPage:BasePage
    {
        public override string BaseLink { get { return "/source-data-details/64aff0b3e35674db810bb397"; } }
        public readonly PreviewDetailsSDLocator Loc;
        public HomeSDPage homePage;

        public PreviewDetailsSDPage(IPage page) : base(page)
        {
            Loc = new PreviewDetailsSDLocator(page);
            homePage = new HomeSDPage(page);
        }

        //public async Task PreviewData()
        //{
        //    await homePage.GoToPreviewPage();
        //}




    }
}
