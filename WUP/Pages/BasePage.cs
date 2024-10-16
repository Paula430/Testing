using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WUP.Tests;
using static System.Net.Mime.MediaTypeNames;

namespace WUP.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage _page;
        public abstract string BaseLink { get; }

        protected BasePage(IPage page)
        {
            _page = page;
            _page.SetViewportSizeAsync(1440, 810);
        }

        private string CreateUrl()
        {
            return TestConstants.baseUrl + BaseLink;
        }

        public async Task GoTo()
        {
            await _page.GotoAsync(CreateUrl());
        }

        public async Task<bool> IsAnnouncement(string name)
        {
            ILocator communicate = _page.GetByText(name);

            if (await communicate.IsEnabledAsync())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> CheckUI(ILocator[] tab)
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            int number = tab.Length;
            int ok = 0;

            foreach (var element in tab)
            {
                if (await element.IsEnabledAsync())
                {
                    ok++;
                }
            }

            //sprawdzenie czy wszystkie elementy w tablicy sa widoczne i zabezpieczenie przed pusta tablica
            if (ok == number && number != 0)
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
