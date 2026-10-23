using Microsoft.Playwright;
using PlaywrightBDD.Helpers;

namespace PlaywrightBDD_Framework.Helper
{
    public class GenericHelper
    {
        public static async Task Click(IPage page, params string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    await locator.ClickAsync();
                    Console.WriteLine($"Clicked on element with selector: {selector}");
                    return;
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }

        public static async Task Clear(IPage page, string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    await locator.ClearAsync();
                    Console.WriteLine($"Cleared element with selector: {selector}");
                    return;
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }

        public static async Task<string> GetText(IPage page, params string[] selectors)
        {
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.InnerTextAsync();
                    Console.WriteLine($"Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }

        public static async Task<string> GetAttribute(IPage page, params string[] selectors)
        {
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.InnerTextAsync();
                    Console.WriteLine($"Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }
        public static async Task<string> TextContent(IPage page, params string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.TextContentAsync();
                    Console.WriteLine("Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }
        public static async Task<Boolean> IsVisible(IPage page, string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.IsVisibleAsync();
                    Console.WriteLine($"Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }
        public static async Task<Boolean> IsEnabled(IPage page, string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.IsEnabledAsync();
                    Console.WriteLine($"Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }
        public static async Task<Boolean> IsDisabled(IPage page, string[] selectors)
        {
            await WaitForPageLoadAsync(page);
            foreach (var selector in selectors)
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    return await locator.IsDisabledAsync();
                    Console.WriteLine($"Used on element with selector: {selector}");
                }
            }
            throw new Exception("None of the provided selectors were found or visible.");
        }
        public static async Task Fill(IPage page, string[] selectors, string value)
        {
            try
            {
                await WaitForPageLoadAsync(page);
                foreach (var selector in selectors)
                {
                    var locator = page.Locator(selector);
                    if (await locator.IsVisibleAsync())
                    {
                        await locator.FillAsync(value);
                        Console.WriteLine($"Used on element with selector: {selector}");
                        return;
                    }
                }
            }
            catch (Exception ex) { }
            throw new Exception("None of the provided selectors were found or visible.");
        }

        public static async Task SelectByText(IPage page, string[] selectors, string text)
        {
            try
            {
                await WaitForPageLoadAsync(page);
                foreach (var selector in selectors)
                {
                    var locator = page.Locator(selector);

                    if (await locator.IsVisibleAsync())
                    {
                        await locator.SelectOptionAsync(new SelectOptionValue
                        {
                            Label = text
                        });
                        Console.WriteLine($"Dropdown selection used on element with selector: {selector}");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting dropdown value: {ex.Message}");
            }
            throw new Exception("None of the provided selectors were found or visible for dropdown selection.");
        }

        public static async Task WaitForPageLoadAsync(IPage page, LoadState state = LoadState.DOMContentLoaded, int timeoutMs = 10000)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForLoadStateAsync(state, new PageWaitForLoadStateOptions
            {
                Timeout = timeoutMs
            });
        }

        public static async Task SafeClickAsync(IPage page, string selector, int maxRetries = 3, int delayMs = 1500)
        {
            await RetryHelper.RetryAsync(async () =>
            {
                var locator = page.Locator(selector);
                if (await locator.IsVisibleAsync())
                {
                    await locator.ClickAsync();
                    Console.WriteLine($"Clicked element: {selector}");
                }
                else
                {
                    throw new Exception($"Element '{selector}' not visible yet.");
                }
            }, maxRetries, delayMs);
        }

        public static async Task UploadFileAsync(IPage page, string selector, string fileName)
        {
            string workingdirectory = Environment.CurrentDirectory;
            var projectdirectory = Directory.GetParent(workingdirectory).Parent.Parent.FullName + "\\TestData\\" + fileName;
            if (!File.Exists(projectdirectory))
                throw new FileNotFoundException($"File not found: {projectdirectory}");
            await page.SetInputFilesAsync(selector, projectdirectory);
        }

        public static async Task scrolldowntobottom(IPage page)
        {
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static async Task ScrollToElementAsync(ILocator locator)
        {
            await locator.ScrollIntoViewIfNeededAsync();
        }

        public static async Task ScrollToElementAsync(IPage page, string[] selectors)
        {
            try
            {
                await WaitForPageLoadAsync(page);
                foreach (var selector in selectors)
                {
                    var locator = page.Locator(selector);
                    if (await locator.IsVisibleAsync())
                    {
                        await locator.ScrollIntoViewIfNeededAsync();
                        Console.WriteLine($"Used on element with selector: {selector}");
                        return;
                    }
                }
            }
            catch (Exception ex) { }
            throw new Exception("None of the provided selectors were found or visible.");
        }

        public static async Task scrolldowntoTop(IPage page)
        {
            await page.EvaluateAsync("window.scrollTo(0, 0)");
        }
    }
}
