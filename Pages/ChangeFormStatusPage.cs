
using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;
namespace PlaywrightBDD.Pages
{
    public class ChangeFormStatusPage
    {
        private IPage _page;

        public ChangeFormStatusPage(IPage page)
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
        public string[] changeStatus = new[]{
            ".govuk-button",
            "//div[@class='govuk-grid-column-one-quarter govuk-!-padding-left-0']",
            "//button[text()='Change status']"
        };


        public string[] Confirm_changestatus = new[]
        {
            "//button[text()='Change form status']",
        };

        public string[] Confirm_button_alert = new[]
        {

        "#status-confirm-0",
        "//input[@class='govuk-checkboxes__input']"
        };

        public string[] Confirm_changestatus_Alert = new[]{
            "[name='on-change-status-confirm-submit-button']",
            "//button[text()='Change form status']"
        };

        public async Task UserChangeStatusToAsync(string Status)
        {
            await _page.Locator("//input[@value='" + Status + "']").ClickAsync();
        }
        public async Task ClickChangeStatus()
        {
            await GenericHelper.Click(_page, changeStatus);
        }

        public async Task SelectConfirmCheckBoxOnAlert()
        {
            await GenericHelper.Click(_page, Confirm_button_alert);
        }

        public async Task ClickOnAlert_changestatus()
        {
            await GenericHelper.Click(_page, Confirm_changestatus_Alert);
        }
    }
}
