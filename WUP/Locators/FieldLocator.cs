using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WUP.Pages;

namespace WUP.Locators
{
    public class FieldLocator:BasePage
    {
        public override string BaseLink { get { return "/fields"; } }
        public FieldLocator(IPage page) : base(page) { }
        public ILocator BtnAdministration => _page.GetByRole(AriaRole.Button, new() { Name = "Administracja" });
        public ILocator BtnPola => _page.GetByRole(AriaRole.Button, new() { Name = "Pola" });
        public ILocator BtnAddPola => _page.GetByRole(AriaRole.Button, new() { Name = "Dodaj" });
        public ILocator InputName => _page.GetByLabel("Nazwa *");
        public ILocator InputType => _page.GetByLabel("Typ *");
        public ILocator BtnAccept => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });
        public ILocator BtnDelete => _page.GetByRole(AriaRole.Button, new() { Name = "Usuń" });
        public ILocator BtnAcceptDelete => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });
        public ILocator BtnEdit => _page.GetByRole(AriaRole.Button, new() { Name = "Edytuj" });
        public ILocator InputFilterName => _page.GetByLabel("Nazwa Filter Input");
        public ILocator FirstFieldAfterFilter => _page.Locator("//div[@row-index='0']").Nth(1);
        public ILocator BtnCloseFormAdd => _page.GetByRole(AriaRole.Button).First;


        //FieldUI:
        public ILocator HeadingFieldText => _page.GetByRole(AriaRole.Heading, new() { Name = "Pola" });
        public ILocator FilterNameText => _page.GetByText("Nazwa");
        public ILocator FilterTypeText => _page.GetByText("Typ");
        public ILocator FilterCreateDateText => _page.GetByText("Data utworzenia");
        public ILocator FilterModifText => _page.GetByText("Modyfikował");
        public ILocator InputFilterType => _page.Locator("//input").Nth(6);
        public ILocator InputFilterDateCreate => _page.Locator("//input").Nth(8);
        public ILocator BtnPageFirst => _page.GetByRole(AriaRole.Button, new() { Name = "1" });
        public ILocator  BtnLeftArrow=> _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^123$") }).GetByRole(AriaRole.Button).First;


        //AddFormUI:
        public ILocator HeadingAddFieldText => _page.GetByText("Dodaj pole");
        public ILocator NameFieldText => _page.GetByText("Nazwa *");
        public ILocator TypeFieldText => _page.GetByText("Typ *");

        //EditFormUI
        public ILocator HeadingEditFieldText => _page.GetByText("Edytuj pole");

        //DeleteFieldUI
        public ILocator HeadingDeleteFieldText => _page.GetByText("Usunąć?");
        public ILocator AskDeleteSureText => _page.GetByText("Czy na pewno chcesz usunąć \"Testowe paula\"?");
        public ILocator BtnCancel => _page.GetByRole(AriaRole.Button, new() { Name = "Anuluj" });
        public ILocator LabelDelete => _page.GetByLabel("Usunąć?");







    }
}
