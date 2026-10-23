using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class DetailsLinkComponentPage
    {
        private IPage _page;

        public DetailsLinkComponentPage(IPage page)
        {
            _page = page;
        }

        public string[] TitleEditBox = new[]
        {
            "[name='title']"
        };
        public string[] contentEditBox = new[]{
            ".govuk-textarea"
        };
        public string[] detailtext = new[]{
            ".govuk-details__summary-text"
        };
        public string[] detailtextheading = new[]{
            ".govuk-details__text >h1"
        };
        public string[] detailtextparagraph = new[]{
            ".govuk-details__text >p"
        };

        public async Task<string> GetTextdetail()
        {
            bool a = await _page.Locator(".govuk-details__summary").IsDisabledAsync();

            return await GenericHelper.GetText(_page, detailtext);
        }
        public async Task<string> GetTextHeading()
        {
            return await GenericHelper.TextContent(_page, detailtextheading);
        }
        public async Task<string> GetTextParagraph()
        {
            return await GenericHelper.GetText(_page, detailtextparagraph);
        }

        public async Task EnterTitleAndContent(string title, string content)
        {
            await GenericHelper.Fill(_page, TitleEditBox, title);
            await GenericHelper.Fill(_page, contentEditBox, content);
        }
    }
}
