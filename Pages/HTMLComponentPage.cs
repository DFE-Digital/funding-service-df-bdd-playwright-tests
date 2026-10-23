using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class HTMLComponentPage
    {
        private IPage _page;

        public HTMLComponentPage(IPage page)
        {
            _page = page;
        }

        public string[] HtmlEditBox = new[]
        {
            "//textarea"
        };
        public string[] saveButton = new[]
         {
            "//button[.='Save']"
        };
        public string[] htmltext = new[]{
            "(//P)[3]"
        };

        public async Task<string> GetText()
        {
            string aa = await _page.Locator("[name='crumb'] +p").TextContentAsync();
            return await GenericHelper.GetText(_page, htmltext);
        }

        public async Task Enterhtml(string title)
        {
            await GenericHelper.Fill(_page, HtmlEditBox, title);
            await GenericHelper.Click(_page, saveButton);
        }
    }
}
