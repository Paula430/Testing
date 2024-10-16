using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUP.Pages;

namespace WUP.Locators
{
    public class MapLocator:BasePage
    {
        public override string BaseLink { get { return "/mapping"; } }
        public MapLocator(IPage page) : base(page){}

        public ILocator BtnAddMap => _page.GetByRole(AriaRole.Button, new() { Name = "Dodaj" });
        public ILocator InputNameForm => _page.GetByLabel("Nazwa *");
        public ILocator BtnSaveAddMap => _page.GetByRole(AriaRole.Button, new() { Name = "Zapisz" });
        public ILocator InputFilterMapByName => _page.GetByLabel("Nazwa Filter Input");
        public ILocator BtnDeleteMap => _page.GetByRole(AriaRole.Button, new() { Name = "Usuń" });
        public ILocator BtnAcceptDeleteMap => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });

        public ILocator CellImportedValue => _page.Locator("textarea");
        public ILocator BtnEdit => _page.GetByRole(AriaRole.Button, new() { Name = "Edytuj" });

        public ILocator BtnImport => _page.GetByRole(AriaRole.Button, new() { Name = "Importuj" });
        public ILocator InputFile => _page.Locator("//input[@type='file']");
        public ILocator BtnClose => _page.GetByRole(AriaRole.Button).First;



    }
}
