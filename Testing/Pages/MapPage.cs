using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WUP.Locators;

namespace WUP.Pages
{
    public class MapPage:BasePage
    {
        public override string BaseLink { get { return "/mapping"; } }
        public readonly MapLocator MapLoc;

        public MapPage(IPage page) : base(page)
        {
            MapLoc = new MapLocator(page);
        }

        public async Task CleanUpMap(string name)
        {
            await MapLoc.InputFilterMapByName.FillAsync(name);
            await _page.WaitForRequestFinishedAsync();
            foreach (var item in await _page.GetByText(name).AllAsync())
            {
                if (await _page.GetByText(name).First.IsEnabledAsync())
                {
                    await _page.GetByText(name).First.ClickAsync();
                    await MapLoc.BtnDeleteMap.ClickAsync();
                    await MapLoc.BtnAcceptDeleteMap.ClickAsync();
                    await _page.WaitForRequestFinishedAsync();
                }
            }
        }

        public async Task<bool> ChooseMap(string name)
        {

            await MapLoc.InputFilterMapByName.FillAsync(name);
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

        public async Task FillMappingForm(string name, string firstCell,string secondCell)
        {
            await MapLoc.InputNameForm.FillAsync(name);
            await _page.Mouse.DblClickAsync(850, 260);
            await MapLoc.CellImportedValue.FillAsync(firstCell);
            await _page.Mouse.DblClickAsync(1113, 260);
            await MapLoc.CellImportedValue.FillAsync(secondCell);
            await MapLoc.BtnSaveAddMap.ClickAsync();
            await _page.WaitForRequestFinishedAsync();
        }

        public async Task AddMap(string name, string firstCell, string secondCell)
        {
            await MapLoc.BtnAddMap.ClickAsync();
            await FillMappingForm(name,firstCell,secondCell);   
            
        }
        public async Task AddMapByImportFile(string name,string path)
        {
            await MapLoc.BtnAddMap.ClickAsync();
            await MapLoc.InputNameForm.FillAsync(name);
            await MapLoc.InputFile.SetInputFilesAsync(path);
            await MapLoc.BtnSaveAddMap.ClickAsync();
            await _page.WaitForRequestFinishedAsync();
        }

        public async Task EditMap(string name, string newName)
        {
            await ChooseMap(name);
            await MapLoc.BtnEdit.ClickAsync();
            await FillMappingForm(newName, "2", "3");

        }

    }
}
