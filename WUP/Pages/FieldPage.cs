using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WUP.Locators;

//weryfikacja pól w formularzu
//sprawdzenie czy rzeczywiscie cos zostalo dodane lub edytowane lub usuniete


namespace WUP.Pages
{
    public class FieldPage:BasePage
    {
        public override string BaseLink { get { return "/fields"; } }
        public readonly FieldLocator FieldLoc;
        

        public FieldPage(IPage page) : base(page) 
        {
            FieldLoc = new FieldLocator(page);
        }
        
         public async Task<bool> ChooseField(string name)
        {

            await FieldLoc.InputFilterName.FillAsync(name);
            await _page.WaitForRequestFinishedAsync();

            if (await _page.GetByText(name).IsEnabledAsync())
            {
                await _page.GetByText(name).ClickAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddField(string name="Testowe paula",string type="liczba")
        {
            await FieldLoc.BtnAddPola.ClickAsync();
            await FieldLoc.InputName.FillAsync(name);
            await FieldLoc.InputType.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = type, Exact = true }).ClickAsync();
            await FieldLoc.BtnAccept.ClickAsync();
            
        }

        public async Task CleanUpField(string name)
        {
            await FieldLoc.InputFilterName.FillAsync(name);
            await _page.WaitForRequestFinishedAsync();
            foreach (var item in await _page.GetByText(name).AllAsync())
            {
                if(await _page.GetByText(name).First.IsEnabledAsync())
                {
                    await _page.GetByText(name).First.ClickAsync();
                    await FieldLoc.BtnDelete.ClickAsync();
                    await FieldLoc.BtnAcceptDelete.ClickAsync();
                    await _page.WaitForRequestFinishedAsync();
                }
            }       
              
        }

        public async Task AddFieldWithoutType(string name)
        {
            await FieldLoc.BtnAddPola.ClickAsync();
            await FieldLoc.InputName.FillAsync(name);
            await FieldLoc.BtnAccept.ClickAsync();
            
        }
        
        public async Task CloseFormAddField()
        {
            await FieldLoc.BtnCloseFormAdd.ClickAsync();
        }

        public async Task DeleteField(string name)
        {
            await ChooseField(name);
            await FieldLoc.BtnDelete.ClickAsync();
            await FieldLoc.BtnAcceptDelete.ClickAsync();
        }

        public async Task EditField(string fieldToEdit, string newName,string newtype="liczba")
        {
            await ChooseField(fieldToEdit);
            await FieldLoc.BtnEdit.ClickAsync();
            await FieldLoc.InputName.FillAsync(newName);
            await FieldLoc.BtnAccept.ClickAsync();
                
        }

        public async Task<bool> CheckFieldPageUI()
        {
            ILocator[] FieldGUITab = { FieldLoc.HeadingFieldText, FieldLoc.FilterNameText, FieldLoc.FilterTypeText, FieldLoc.FilterCreateDateText, FieldLoc.FilterModifText, FieldLoc.BtnPageFirst, FieldLoc.BtnLeftArrow, FieldLoc.BtnAddPola, FieldLoc.InputFilterType, FieldLoc.InputFilterDateCreate };
            var result = await CheckUI(FieldGUITab);
            return result;

        }        

        public async Task<bool> CheckAddFormUI()
        {
            await FieldLoc.BtnAddPola.ClickAsync();
            ILocator[] AddFormUI = { FieldLoc.HeadingAddFieldText, FieldLoc.NameFieldText, FieldLoc.TypeFieldText,FieldLoc.BtnCloseFormAdd,FieldLoc.InputName,FieldLoc.InputType,FieldLoc.BtnAccept};
            var result = await CheckUI(AddFormUI);
            return result;
        }

        public async Task<bool> CheckEditFormUI(string name)
        {            
            await ChooseField(name);
            await FieldLoc.BtnEdit.ClickAsync();

            ILocator[] EditFormUI = { FieldLoc.HeadingEditFieldText, FieldLoc.NameFieldText, FieldLoc.TypeFieldText, FieldLoc.BtnCloseFormAdd, FieldLoc.InputName, FieldLoc.InputType, FieldLoc.BtnAccept }; 
            var result=await CheckUI(EditFormUI);

            string textName=await FieldLoc.InputName.InputValueAsync();
            string textType = await FieldLoc.InputType.InputValueAsync();

            //sprawdza czy istnieja odpowiednie elementy oraz czy są wypełnione pola
            if (result)
            {
                if(textName==name && textType == "kwota")
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
            await ChooseField(name);
            await FieldLoc.BtnDelete.ClickAsync();
            ILocator[] EditFormUI = { FieldLoc.LabelDelete, FieldLoc.BtnCancel, FieldLoc.AskDeleteSureText, FieldLoc.HeadingDeleteFieldText, FieldLoc.BtnAccept, FieldLoc.BtnCloseFormAdd };
            var result = await CheckUI(EditFormUI);
            await FieldLoc.BtnAcceptDelete.ClickAsync();

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
