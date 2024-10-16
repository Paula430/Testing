using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WUP.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace WUP.Locators
{
    public class TagLocator:BasePage
    {
        public override string BaseLink { get { return "/tags"; } }
        public TagLocator(IPage page) : base(page) { 
            
        }

        public ILocator BtnAddTag => _page.GetByRole(AriaRole.Button, new() { Name = "Dodaj" });
        public ILocator InputAddFormName => _page.GetByLabel("Nazwa *");
        public ILocator BtnAcceptForm => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });
        public ILocator InputFilterTagByName => _page.GetByLabel("Nazwa Filter Input");
        public ILocator BtnDeleteTag => _page.GetByRole(AriaRole.Button, new() { Name = "Usuń" });
        public ILocator BtnAcceptDeleteTag => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });

        public ILocator FirstTagAfterFilter => _page.Locator("//div[@row-index='0']").Nth(1);
        public ILocator BtnEdit => _page.GetByRole(AriaRole.Button, new() { Name = "Edytuj" });
        public ILocator BtnDelete => _page.GetByRole(AriaRole.Button, new() { Name = "Usuń" });
        public ILocator BtnAcceptDelete => _page.GetByRole(AriaRole.Button, new() { Name = "Potwierdź" });


        //TagUI
        public ILocator TextHeadingTag => _page.GetByRole(AriaRole.Heading, new() { Name = "Tagi" });
        public ILocator TextFilterName => _page.GetByText("Nazwa");
        public ILocator TextFilterCreateDate => _page.GetByText("Data utworzenia");
        public ILocator TextFilterCreateBy => _page.GetByText("Utworzył");
        public ILocator TextFilterDateModi => _page.GetByText("Data modyfikacji");
        public ILocator TextFilterModiBy => _page.GetByText("Modyfikował");
        public ILocator InputFilterTagByDateCreate => _page.Locator("//input").Nth(7);
        public ILocator InputFilterTagByDateModi => _page.Locator("//input").Nth(10);
        public ILocator InputFilterTagByCreateBy => _page.GetByLabel("Utworzył Filter Input");
        public ILocator InputFilterTagModiBy => _page.GetByLabel("Modyfikował Filter Input");
        public ILocator BtnOpenFilter => _page.GetByRole(AriaRole.Gridcell, new() { Name = "Nazwa Filter Input Open Filter Menu" }).GetByLabel("Open Filter Menu");
        public ILocator BtnOpenFilterFirst=>_page.GetByLabel("Open Filter Menu").First;
        public ILocator BtnOpenFilterSecond => _page.GetByLabel("Open Filter Menu").Nth(1);
        public ILocator BtnOpenFilterThird => _page.GetByLabel("Open Filter Menu").Nth(2);
        public ILocator BtnOpenFilterFourth => _page.GetByLabel("Open Filter Menu").Nth(3);
        public ILocator BtnOpenFilterFifth => _page.GetByLabel("Open Filter Menu").Last;


        //AddTagUI
        public ILocator TextAddTag => _page.GetByText("Dodaj tag");
        public ILocator TextName => _page.GetByText("Nazwa *");
        public ILocator BtnClose => _page.GetByRole(AriaRole.Button).First;

        //EditTagUI
        public ILocator TextEditTag => _page.GetByText("Edytuj tag");

        //DeleteTagUI:
        public ILocator HeadingDeleteTagText => _page.GetByText("Usunąć?");
        public ILocator AskDeleteSureText => _page.GetByText("Czy na pewno chcesz usunąć \"Testowy paula tag\"?");
        public ILocator BtnCancel => _page.GetByRole(AriaRole.Button, new() { Name = "Anuluj" });
        public ILocator LabelDelete => _page.GetByLabel("Usunąć?");

    }
}
