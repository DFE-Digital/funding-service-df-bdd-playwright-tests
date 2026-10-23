using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;
namespace PlaywrightBDD.Pages
{
    public class CreateForm
    {
        private IPage _page;

        public CreateForm(IPage page)
        {
            _page = page;
        }

        public string[] CreateForm_Button = new[]{
             ".govuk-button[type='button']",
             "[title='Create form']",
             "//button[text()='Create new form']"
        };
        public string[] Back_Button = new[]
        {
             ".govuk-back-link",
              "[href='#0']",
              "//a[text()='Back']"
          };
        public string[] CreateFormTitle = new[]{
             ".govuk-heading-l",
              "h1.govuk-heading-l",
          };
        public string[] CreateFormEditBox = new[]{
             ".govuk-input.govuk-input--width-10",
              "input.govuk-input.govuk-input--width-10",
              "//input"
          };
        public string[] CreateFormNextbutton = new[]{
             ".govuk-button.govuk-button--start",
              "//button"
          };
        public string[] FirstPage = new[]{
             "//h3[text()='First page']"

          };

        public async Task Enter_FormName(string formname)
        {
            await GenericHelper.Fill(_page, CreateFormEditBox, formname);
        }

        public async Task Click_CreateForm_Button()
        {
            await GenericHelper.Click(_page, CreateForm_Button);
        }

        public string GetPageTitleAsync(string pagename)
        {
            string? text = _page.Locator("//h3[text()='" + pagename + "']").TextContentAsync().GetAwaiter().GetResult(); // Await the Task
            return text ?? string.Empty; // Handle null by returning empty string
        }
    }
}
