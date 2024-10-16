using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WUP.Locators;

namespace WUP.Pages
{
    public class TagPage : BasePage
    {
        public override string BaseLink { get { return "/tags"; } }
        public readonly TagLocator TagLoc;

        public TagPage(IPage page) : base(page)
        {
            TagLoc = new TagLocator(page);
        }

        public async Task AddTag(string name)
        {
            await TagLoc.BtnAddTag.ClickAsync();
            await TagLoc.InputAddFormName.FillAsync(name);
            await TagLoc.BtnAcceptForm.ClickAsync();
        }

        public async Task CleanUpTag(string name)
        {
            await TagLoc.InputFilterTagByName.FillAsync(name);
            await _page.WaitForRequestFinishedAsync();
            foreach (var item in await _page.GetByText(name).AllAsync())
            {
                if (await _page.GetByText(name).First.IsEnabledAsync())
                {
                    await _page.GetByText(name).First.ClickAsync();
                    await TagLoc.BtnDeleteTag.ClickAsync();
                    await TagLoc.BtnAcceptDeleteTag.ClickAsync();
                    await _page.WaitForRequestFinishedAsync();
                }
            }
        }

        public async Task<bool> ChooseTag(string name)
        {
            await TagLoc.InputFilterTagByName.FillAsync(name);
            await _page.WaitForRequestFinishedAsync();

            if(await _page.GetByText(name).IsEnabledAsync())
            {
                await _page.GetByText(name).ClickAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task EditTag(string tagToEdit, string newTag)
        {
            await ChooseTag(tagToEdit);
            await TagLoc.BtnEdit.ClickAsync();
            await TagLoc.InputAddFormName.FillAsync(newTag);
            await TagLoc.BtnAcceptForm.ClickAsync();
        }

        public async Task DeleteTag(string name)
        {
            await ChooseTag(name);
            await TagLoc.BtnDelete.ClickAsync();
            await TagLoc.BtnAcceptDelete.ClickAsync();
        }

        public async Task<bool> CheckTagPageUI()
        {

            ILocator[] TagUITab = {
                TagLoc.TextHeadingTag,
                TagLoc.TextFilterName,
                TagLoc.TextFilterCreateDate,
                TagLoc.TextFilterCreateBy,
                TagLoc.TextFilterDateModi,
                TagLoc.TextFilterModiBy,
                TagLoc.InputFilterTagByDateModi,
                TagLoc.InputFilterTagByCreateBy,
                TagLoc.InputFilterTagModiBy,
                TagLoc.InputFilterTagByDateCreate,
                TagLoc.InputFilterTagByName,
                TagLoc.BtnAddTag,
                TagLoc.BtnOpenFilterFirst,
                TagLoc.BtnOpenFilterSecond,
                TagLoc.BtnOpenFilterThird,
                TagLoc.BtnOpenFilterFourth,
                TagLoc.BtnOpenFilterFifth
            };

            if (await CheckUI(TagUITab))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckAddTagFormUI()
        {
            await TagLoc.BtnAddTag.ClickAsync();

            ILocator[] FormAddUI = {
                TagLoc.TextAddTag,
                TagLoc.TextName,
                TagLoc.BtnClose,
                TagLoc.BtnAcceptForm,
                TagLoc.InputAddFormName};

            return await CheckUI(FormAddUI);

        }

        public async Task<bool> CheckEditTagFormUI(string name)
        {
            await ChooseTag(name);
            await TagLoc.BtnEdit.ClickAsync();

            ILocator[] EditFormUI = { 
                TagLoc.TextEditTag,
                TagLoc.TextName,
                TagLoc.BtnClose,
                TagLoc.BtnAcceptForm,
                TagLoc.InputAddFormName
            };

            string textName = await TagLoc.InputAddFormName.InputValueAsync();
            Console.WriteLine(textName);

            //sprawdza czy istnieja odpowiednie elementy oraz czy są wypełnione pola
            if (await CheckUI(EditFormUI))
            {
                if (textName == name)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> CheckDeletePopUp(string name)
        {
            await ChooseTag(name);
            await TagLoc.BtnDelete.ClickAsync();

            ILocator[] EditFormUI = { 
                TagLoc.LabelDelete, 
                TagLoc.BtnCancel, 
                TagLoc.AskDeleteSureText, 
                TagLoc.HeadingDeleteTagText, 
                TagLoc.BtnAcceptForm, 
                TagLoc.BtnClose 
            };

            var result = await CheckUI(EditFormUI);

            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
