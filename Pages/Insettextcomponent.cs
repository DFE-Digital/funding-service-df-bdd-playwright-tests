using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class Insettextcomponent
    {
        private IPage _page;

        public Insettextcomponent(IPage page)
        {
            _page = page;
        }

        public string[] EditBox = new[] { "#field-content" };


        public string[] save = new[]
      {
            "[type='submit']"
        };

        public async Task EnterTEXT(string title)
        {
            await GenericHelper.Fill(_page, EditBox, title);
            await GenericHelper.Click(_page, save);
        }
    }
}
