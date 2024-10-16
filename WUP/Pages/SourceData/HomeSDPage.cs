using Microsoft.Playwright;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WUP.Locators;
using WUP.Locators.SourceDataLocators;

namespace WUP.Pages.SourceData
{
    public class HomeSDPage:BasePage
    {
        public override string BaseLink { get { return "/source-data"; } }
        public readonly HomeSDLocator Loc;
        public PreviewDetailsSDPage PrievPage;
        const string nameFolder = "test2";
        const string nameFile = "test paula";

        public HomeSDPage(IPage page) : base(page)
        {
            Loc = new HomeSDLocator(page);
            PrievPage = new PreviewDetailsSDPage(page);
        }

        //public async Task GoToPreviewPage()
        //{
        //    await PrievPage.GoTo();
            
        //    //await Loc.InputFilterFoldersByName.FillAsync(nameFolder);

        //    //if (await _page.GetByText(nameFolder).IsEnabledAsync())
        //    //{
        //    //    await _page.GetByText(nameFolder).ClickAsync();
        //    //    await _page.WaitForRequestFinishedAsync();

        //    //    if (await _page.GetByText(nameFile).IsEnabledAsync())
        //    //    {
        //    //        await _page.GetByText(nameFile).ClickAsync();
        //    //        await Loc.BtnPreview.ClickAsync();
        //    //        await _page.WaitForRequestFinishedAsync();

        //    //    }
        //    //}

        //}

       




    }
}
