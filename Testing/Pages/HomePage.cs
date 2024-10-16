using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUP.Pages
{
    public class HomePage : BasePage
    {
        public override string BaseLink { get { return "/"; } }
        public HomePage(IPage page) : base(page) { }

        private ILocator TextDaneŻrodlowe => _page.GetByText("Dane źródłowe");
        private ILocator ComFailedLogin => _page.GetByText("Formularz został nieprawidłowo wypełniony.");
        private ILocator DivFieldInCorrectEmail => _page.GetByText("Niepoprawny format adresu email.Nieprawidłowe poświadczenia.");

        public async Task<bool> CheckLogin(string type="positive")
        {
            if (type == "positive")
            {
                bool TextisEnable = await TextDaneŻrodlowe.IsEnabledAsync();
                if (TextisEnable)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }else if(type=="negative")
            {
                bool ComIsEnabled=await ComFailedLogin.IsEnabledAsync();
                bool DivInCorrectEmailEnabled=await DivFieldInCorrectEmail.IsEnabledAsync();
                if(ComIsEnabled && DivInCorrectEmailEnabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            return false;
           
        }




    }
}
