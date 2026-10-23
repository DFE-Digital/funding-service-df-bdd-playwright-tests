
using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;
namespace PlaywrightBDD.Pages
{
    public class ChangeAccessType
    {
        private IPage _page;

        public ChangeAccessType(IPage page)
        {
            _page = page;
        }

        public string[] DFESignin_Radiobox = new[]
        {
            "#DFESignIn",
            "[value='DFE SignIn']"
        };
        public string UploadFile = "#file-upload-1";
        public string[] SwitchAccess_button = new[]{
            "[type='submit']",
            "//button[text()='Switch access']"
        };

        public string[] Confirm_button = new[]{
            ".govuk-checkboxes__input",
            "#confirm1"
        };
        public string[] SwitchAccess_confirmbutton = new[]{
            "(//button[text()='Switch access'])[2]",
            "//button[text()='Switch access']"
        };

        public async Task ChangeAcess(string filename)
        {

            await GenericHelper.Click(_page, DFESignin_Radiobox);
            await GenericHelper.UploadFileAsync(_page, UploadFile, filename);
            await GenericHelper.Click(_page, SwitchAccess_button);
        }
        public async Task click_Confirm()
        {
            await GenericHelper.Click(_page, Confirm_button);
            await GenericHelper.Click(_page, SwitchAccess_confirmbutton);

        }
    }
}
