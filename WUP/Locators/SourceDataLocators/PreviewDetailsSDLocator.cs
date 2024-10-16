using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUP.Pages;

namespace WUP.Locators.SourceDataLocators
{
    public class PreviewDetailsSDLocator:BasePage
    {
        public override string BaseLink { get { return "/source-data-details"; } }
        public PreviewDetailsSDLocator(IPage page) : base(page) { }
    }
}
