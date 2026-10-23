
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Reqnroll;

namespace PlaywrightBDD.Hooks
{
    [Binding]
    public sealed class GlobalHooks
    {
        public static IBrowserContext? Context;
        public static IPage? Page;
        public static IPlaywright? Playwright;
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        [BeforeTestRun(Order = 0)]
        public static async Task BeforeTestRun()
        {
            var config = new ConfigurationManager();
            config.AddJsonFile(projectDirectory + "\\Appsettings.json");
            config.AddEnvironmentVariables();
            string Browser = config["Browser"].Trim();
            if (Browser.ToLower().Contains("edge"))
            { Browser = "msedge"; }
            else if (Browser.ToLower().Contains("chrom"))
            { Browser = "chrome"; }
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Context = await Playwright.Chromium.LaunchPersistentContextAsync(
               userDataDir: "./user_data",
               new BrowserTypeLaunchPersistentContextOptions
               {
                   Channel = Browser,
                   Headless = false,
                   ViewportSize = new ViewportSize
                   {
                       Width = 1920,
                       Height = 1080
                   },
                   SlowMo = 2000,
               });
            Page = Context.Pages[0];
        }

        [AfterTestRun]
        public static async Task AfterTestRun()
        {
            await Context.CloseAsync();
            Playwright.Dispose();
        }
    }
}

