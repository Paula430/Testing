using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUP.Pages;

namespace WUP.Locators.SourceDataLocators
{
    public class ImportSDLocator : BasePage
    {
        public override string BaseLink { get { return "/import-data"; } }
        public ImportSDLocator(IPage page) : base(page) { }

    }
}
