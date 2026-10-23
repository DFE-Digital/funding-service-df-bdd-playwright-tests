using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class CreateComponentPage
    {
        private IPage _page;

        public CreateComponentPage(IPage page)
        {
            _page = page;
        }

        public string[] SummaryPageEdit = new[]
        {
            "//button[text()='Edit page']/ancestor::div[@id='/summary']//button[@title='Edit page']"
        };
        public string[] saveButton = new[]
        {
            "//button[.='Save page']"
        };
        public string[] CreateComponent_button = new[]
        {
            "(//button[@title='Create component'])[2]"
        };
        private bool flag;

        public async Task<bool> CheckComponent(string component)
        {
            ILocator elements = _page.Locator("//li/a");

            int count = await elements.CountAsync();
            flag = false;
            for (int i = 1; i <= count; i++)
            {
                string element = _page.Locator("(//li/a)[" + i + "]").TextContentAsync().Result;

                if (element.Equals(component))
                { flag = true; break; }

            }
            return flag;
        }
        public async Task<bool> CheckComponentlabel(string component)
        {
            ILocator elements = _page.Locator("//div[@class='govuk-hint']");

            int count = await elements.CountAsync();
            flag = false;
            for (int i = 1; i <= count; i++)
            {
                string element = _page.Locator("(//div[@class='govuk-hint'])[" + i + "]").TextContentAsync().Result;

                if (element.Equals(component))
                { flag = true; break; }

            }
            return flag;
        }
        public async Task Click_component(string componentname)
        {

            await _page.Locator("//a[text()='" + componentname + "']").ClickAsync();
        }

        public async Task Create_component()
        {
            await GenericHelper.Click(_page, CreateComponent_button);
        }
        public async Task SummaryPageEditClick()
        {
            await GenericHelper.Click(_page, SummaryPageEdit);
        }
        public async Task SelectPageTypeDropDown(String dropdown)
        {

            await _page.Locator("//select[@id='page-type']").SelectOptionAsync(
                    new SelectOptionValue { Label = dropdown }
                );
        }

        public async Task ClickSaveButton()
        {
            await GenericHelper.Click(_page, saveButton);
        }
    }
}
