using Microsoft.Playwright;

namespace DigitalForm_AutomationSuite.Helper
{
    public static class TabHelper
    {
        private static IPage _page;
        public static async Task<IPage> SwitchToNewTabAsync(
            IPage page,
            Func<Task> action)
        {
            var context = page.Context;
            var newPageTask = context.WaitForPageAsync(new()
            {
                Timeout = 3000
            });
            await action();
            var newTab = await newPageTask;
            await newTab.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            return newTab;
        }
        public static async Task<IPage> CloseTabAndReturnAsync(IPage newTab)
        {
            var pages = newTab.Context.Pages;
            await pages[1].CloseAsync();
            // RETURN to old tab
            _page = pages[0];
            await _page.BringToFrontAsync();
            return _page; // caller will reassign _page
        }
    }
}
