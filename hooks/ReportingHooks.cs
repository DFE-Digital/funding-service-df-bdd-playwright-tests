using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using Microsoft.Playwright;
using PlaywrightBDD.Hooks;
using Reqnroll;

[Binding]
public sealed class ReportingHooks
{
    private static readonly object _lock = new();
    private static ExtentReports _extent;
    private static ExtentSparkReporter _sparkReporter;
    private ExtentTest _feature;
    private ExtentTest _scenario;
    private readonly ScenarioContext _scenarioContext;
    public ReportingHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        lock (_lock)
        {
            string workingdirectory = Environment.CurrentDirectory;
            string projectdirectory = Directory.GetParent(workingdirectory).Parent.Parent.FullName + "\\TestResults";
            string reportPath = projectdirectory + "\\Report.html";
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            _sparkReporter = new ExtentSparkReporter(reportPath);
            _sparkReporter.Config.Theme = Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(_sparkReporter);
        }
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        lock (_lock)
        {
            var feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            featureContext.FeatureContainer.RegisterInstanceAs(feature);
        }
    }

    [BeforeScenario]
    public void BeforeScenario(FeatureContext featureContext)
    {
        _feature = featureContext.FeatureContainer.Resolve<ExtentTest>();
        _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        _scenarioContext.Set(_scenario);
    }

    [AfterStep]
    public async Task AfterStep(FeatureContext featureContext)
    {
        var featureinfo = featureContext.FeatureInfo;
        var _scenarioTitle = _scenarioContext.ScenarioInfo.Title;
        var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        var stepText = _scenarioContext.StepContext.StepInfo.Text;
        var keyword = new GherkinKeyword(stepType);

        if (_scenarioContext.TestError == null)
        {
            _scenario.CreateNode(keyword, stepText).Pass("Passed");
        }
        else
        {
            IPage page = GlobalHooks.Page;
            var screenshotBytes = await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Type = ScreenshotType.Png,
                FullPage = true
            });
            string base64Screenshot = Convert.ToBase64String(screenshotBytes);
            if (featureinfo.Title.ToLower().Contains("api"))
            {
                _scenario.CreateNode(keyword, stepText).Fail(_scenarioContext.TestError.Message);
            }
            else
            {
                _scenario.CreateNode(keyword, stepText).Fail(_scenarioContext.TestError.Message).AddScreenCaptureFromBase64String(base64Screenshot);
            }
        }
    }

    [AfterScenario]
    public async Task AfterScenarioAsync()
    {
        IPage page = GlobalHooks.Page;
        if (page != null)
        {
            if (_scenarioContext.TestError != null)
            {
                //var b = _scenarioContext.ScenarioInfo.Title;
                //string workingdirectory1 = Environment.CurrentDirectory;
                //var projectdirectory1 = Directory.GetParent(workingdirectory1).Parent.Parent.FullName + "\\TestResults\\Screenshot";
                //var name = Regex.Replace(_scenarioContext.ScenarioInfo.Title, @"\s+", "");
                //var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                //var screenshotPath = Path.Combine(projectdirectory1, $"{name}_{timestamp}.png");
                //Directory.CreateDirectory(Directory.GetParent(workingdirectory1).Parent.Parent.FullName + "\\TestResults\\Screenshot");
                //page.ScreenshotAsync(new() { Path = screenshotPath });
                //_scenario.AddScreenCaptureFromPath(screenshotPath);
            }
        }
        else
        {
            _scenario?.Warning("Page object was null; screenshot skipped.");
        }
        if (_scenarioContext.ContainsKey("AccessibilityReportPath"))
        {
            var path = _scenarioContext["AccessibilityReportPath"] as string;
            _scenario.Info("Accessibility report generated.");
            _scenario.AddScreenCaptureFromPath(path);
        }
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        lock (_lock)
        {
            _extent.Flush();
        }
    }
}
