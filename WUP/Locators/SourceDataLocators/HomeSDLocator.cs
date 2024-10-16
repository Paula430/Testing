using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUP.Pages;

namespace WUP.Locators.SourceDataLocators
{
    public class HomeSDLocator:BasePage
    {
        public override string BaseLink { get { return "/source-data"; } }
        public HomeSDLocator(IPage page) : base(page) { }

        public ILocator InputFilterFoldersByName => _page.GetByLabel("Nazwa Filter Input").First;
        public ILocator BtnPreview => _page.GetByRole(AriaRole.Button, new() { Name = "Podgląd" });
    }
}
