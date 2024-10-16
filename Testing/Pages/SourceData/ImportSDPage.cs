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
    public class ImportSDPage:BasePage
    {
        public override string BaseLink { get { return "/source-data"; } }
        public readonly ImportSDLocator Loc;

        public ImportSDPage(IPage page) : base(page)
        {
            Loc = new ImportSDLocator(page);
        }


    }
}
