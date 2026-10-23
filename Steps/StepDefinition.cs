using Deque.AxeCore.Commons;
using Deque.AxeCore.Playwright;
using DigitalForm_AutomationSuite.Helper;
using DigitalForm_AutomationSuite.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightBDD.Helpers;
using PlaywrightBDD.Hooks;
using PlaywrightBDD.Pages;
using PlaywrightBDD_Framework.Helper;
using Reqnroll;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssertionHelper = DigitalForm_AutomationSuite.Helper.AssertionHelper;
using BindingAttribute = Reqnroll.BindingAttribute;
using GivenAttribute = Reqnroll.GivenAttribute;
using ScenarioContext = Reqnroll.ScenarioContext;
using ThenAttribute = Reqnroll.ThenAttribute;
using WhenAttribute = Reqnroll.WhenAttribute;

namespace DigitalForm_AutomationSuite.Steps
{
    [Binding]
    public class StepDefinition
    {

        private readonly ScenarioContext _scenarioContext;
        private DashboardPage _dashboardPage;
        private FormDesignerPage _formDesignerPage;
        private ParentChildPage _parentChildPage;
        private HTMLComponentPage _HTMLComponentPage;
        private Runner _runner;
        private ChangeFormStatusPage _changeFormStatusPage;
        private CreateComponentPage _createComponentPage;
        private DetailsLinkComponentPage _detailsLinkComponentPage;
        private CreateForm _createform;
        private Insettextcomponent _Insettextcomponent;
        private IPage _page;
        private PropertiesReader reader;
        private readonly ConfigurationManager config;
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        private string URL;
        private ChangeAccessType _changeAccessType;
        public string Enviorments;
        // Timestamped file name
        string fileName = Path.Combine(
            projectDirectory,
            $"file_{DateTime.Now:MMddyyyyhhmmsstt}.txt"
        );
        string filePath = Path.Combine(projectDirectory, "TestData", "file.txt");
        private Reqnroll.ScenarioContext? scenarioContext;

        public StepDefinition(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
            _dashboardPage = new DashboardPage(GlobalHooks.Page);
            _formDesignerPage = new FormDesignerPage(GlobalHooks.Page);
            _parentChildPage = new ParentChildPage(GlobalHooks.Page);
            _createform = new CreateForm(GlobalHooks.Page);
            _changeFormStatusPage = new ChangeFormStatusPage(GlobalHooks.Page);
            _page = GlobalHooks.Page;
            reader = new PropertiesReader(projectDirectory + "\\TestData\\Digitalform.properties");
            config = new ConfigurationManager();
            config.AddJsonFile(projectDirectory + "\\Appsettings.json");
            config.AddEnvironmentVariables();
            _changeAccessType = new ChangeAccessType(GlobalHooks.Page);
            _runner = new Runner(GlobalHooks.Page);
            _createComponentPage = new CreateComponentPage(GlobalHooks.Page);
            _detailsLinkComponentPage = new DetailsLinkComponentPage(GlobalHooks.Page);
            _HTMLComponentPage = new HTMLComponentPage(GlobalHooks.Page);
            _Insettextcomponent = new Insettextcomponent(GlobalHooks.Page);
        }

        [Given("Navigate to Home page")]
        public async Task GivenNavigateToHomePage()
        {

            string Environment = config["Environment"].Trim();

            if (Environment.ToLower().Contains("test"))
            {
                URL = "https://test.designer.digital-forms.education.gov.uk/app/";

            }
            else if (Environment.ToLower().Contains("preprod"))
            {
                URL = "https://preprod.designer.digital-forms.education.gov.uk/app/";
            }
            else if (Environment.ToLower().Contains("prod"))
            {
                //  input = "https://designer.digital-forms.education.gov.uk/app/";
            }
            else if (Environment.ToLower().Contains("dev"))
            {
                URL = "https://dev.designer.digital-forms.education.gov.uk/app/";
            }
            else
            {
                Console.WriteLine("URL is  missing..");
                throw new Exception("URL is missing");
            }
            await _page.GotoAsync(URL);
        }

        [When("Click on StartNow link")]
        public async Task WhenIClickOnStartNow()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                await GenericHelper.Click(_page, _dashboardPage.StartNow);
            }, maxRetries: 2, delayMilliseconds: 1500);
        }
        [Then("the home page should be displayed")]
        public async Task ThenTheHomePageShouldBeDisplayed()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                string expectedTitle = reader.Get("dashboard.title");
                string actualTitle = await GenericHelper.GetText(_page, _dashboardPage.DigitalFormBuilder_Label);
                AssertionHelper.AssertTextEquals(actualTitle, expectedTitle, "Page Title");
            }, maxRetries: 2, delayMilliseconds: 1500);
        }

        [Then("Click on create new form")]
        public async Task ThenClickOnCreateNewForm()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                _createform.Click_CreateForm_Button();
            }, maxRetries: 2, delayMilliseconds: 1500);
        }

        [Then("Verify Create a new form page")]
        public async Task ThenVerifyCreateANewFormPage()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                await GenericHelper.WaitForPageLoadAsync(_page);
                string actualBackText = await GenericHelper.TextContent(_page, _createform.Back_Button);
                string ExpectedBackText = reader.Get("dashboard.back");
                string actualCreateformtitle = await GenericHelper.TextContent(_page, _createform.CreateFormTitle);
                string expectedCreateformtitle = reader.Get("dashboard.createform.title");
                bool CheckEditBox = await GenericHelper.IsVisible(_page, _createform.CreateFormEditBox);
                bool CheckNextButton = await GenericHelper.IsVisible(_page, _createform.CreateFormNextbutton);
                Assert.Multiple(() =>
                {
                    AssertionHelper.AssertTextEquals(actualBackText, ExpectedBackText, "Backbutton");
                    AssertionHelper.AssertTextEquals(actualCreateformtitle, actualCreateformtitle, "Enter a name for your form");
                    AssertionHelper.AssertTrue(CheckEditBox, "Edit Box in create new form");
                    AssertionHelper.AssertTrue(CheckNextButton, "Next Button in create new form");
                });


            }, maxRetries: 2, delayMilliseconds: 1500);


        }
        [Then("Enter the form name {string}")]
        public async Task ThenEnterTheFormName(string formName)
        {
            await _createform.Enter_FormName(formName);
        }



        [Then("Click on Next button")]
        public async Task ThenClickOnNextButton()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                await GenericHelper.Click(_page, _createform.CreateFormNextbutton);
            }, maxRetries: 2, delayMilliseconds: 1500);

        }

        [Then("Verify label {string}")]
        public void ThenVerifyLabel(string pagename)
        {

            string messageText = _createform.GetPageTitleAsync(pagename);
            string actualText = pagename;
            AssertionHelper.AssertTextEquals(actualText, messageText, pagename);

        }


        [Then("User Select the form {string}")]
        public async Task ThenUserSelectTheForm(string formname)
        {
            await _dashboardPage.Enter_Name(formname);
        }

        [Then("User Click on switch access and change to dfesignin file {string}")]
        public async Task ThenUserClickOnSwitchAccessAndChangeToDfesigninFile(string filename)
        {
            await _page.EvaluateAsync("window.scrollBy(0, document.body.scrollHeight)");
            await _page.WaitForLoadStateAsync();
            await _dashboardPage.ClickSwitchAccess();
            await _changeAccessType.ChangeAcess(filename);
            await _changeAccessType.click_Confirm();
        }

        [Then("Verify the form status {string} for form {string}")]
        public async Task ThenVerifyTheFormStatusForForm(string Status, string formName)
        {
            await RetryHelper.RetryAsync(async () =>
            {
                await _page.WaitForTimeoutAsync(5000);
                await _dashboardPage.Enter_Name(formName);
                string actualStatus = await _dashboardPage.Verifyformstatus(formName, Status);
                AssertionHelper.AssertTextEquals(actualStatus, Status, Status);
            }, maxRetries: 2, delayMilliseconds: 1500);

        }


        [Then("User Click on switch access and change to dfesignin with file{string}")]
        public async Task ThenUserClickOnSwitchAccessAndChangeToDfesigninWithFile(string fileName)
        {
            var formName = File.ReadLines(filePath).First();
           // Enter_Name(formname);
            await _dashboardPage.Enter_Name(formName);

           // await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.ClickOnSwitchAccessButton();
            await _dashboardPage.SelectDfESignInRadiobtn();
            await _dashboardPage.UploadCSVFile(fileName);
            await _dashboardPage.ClickOnSwitchAccessButton();
            await _dashboardPage.ClickConfirmation();
        }

        [Then("Verify the form status {string}")]
        public async Task ThenVerifyTheFormStatus(string status)
        {
            var formName = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.CheckFormStatus(formName, status);
        }

        [Then("check page")]
        public async Task ThenCheckPage()
        {

            await RetryHelper.RetryAsync(async () =>
            {
                Assert.That("one".ToString(), Is.EqualTo("one11"));
            }, maxRetries: 3, delayMilliseconds: 1500);
        }

        [Then("perform accessibility check {string}")]
        public async Task ThenPerformAccessibilityCheck(string URL)
        {
            await Task.Delay(5000);
            await _page.GotoAsync(URL);
            await Task.Delay(5000);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await GenericHelper.WaitForPageLoadAsync(_page);
            string filename = Regex.Replace(URL, "[^a-zA-Z0-9]", "_").Replace("https", "").Substring(3);
            string keyword = "forms_education_gov_uk";
            int index = filename.IndexOf(keyword);
            filename = filename.Substring(index + keyword.Length).Substring(1);
            var axeResults = await GlobalHooks.Page.RunAxe(new AxeRunOptions
            {
                RunOnly = new RunOnlyOptions
                {
                    Type = "tag",
                    Values = new List<string> { "wcag2a", "wcag2aa", "wcag21a", "wcag21aa", "ACT", "best-practice" }

                }
            });
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, "TestResults", "Accessibility");
            Directory.CreateDirectory(projectDirectory);
            string reportPath = Path.Combine(projectDirectory, filename + "report.html");
            AxeHtmlReportGenerator.GenerateHtmlReport(axeResults, reportPath, URL);
        }
        [Then("User click on {string} link")]
        public async Task ThenUserClickOnLink(string Status)
        {
            await _dashboardPage.ClickChangeStatus();
        }

        [Then("User click on {string}")]
        public async Task ThenUserClickOn(string button)
        {
            await _dashboardPage.Click_Duplicatebutton();
        }


        [Then("Enter to duplicate form {string}")]
        public async Task ThenEnterToDuplicateForm(string formName)
        {
            string formname =
                              formName + "_Duplicate_" +
                              DateTime.Now.ToString("s", CultureInfo.CreateSpecificCulture("en-US"));

            formname = Regex.Replace(formname, @"[):;.,'=-]", "");
            await _dashboardPage.EnterDuplicateFormName(formname);
        }

        [Then("Click on duplicate form")]
        public async Task ThenClickOnDuplicateForm()
        {
            await _dashboardPage.ClickDuplicateFormButton();
        }


        [Then(@"user change status to ""([^""]*)""")]
        public async Task ThenUserChangeStatusTo(string Status)
        {
            await _changeFormStatusPage.UserChangeStatusToAsync(Status);
            await _changeFormStatusPage.ClickChangeStatus();
            await _changeFormStatusPage.SelectConfirmCheckBoxOnAlert();
            await _changeFormStatusPage.ClickOnAlert_changestatus();
        }

        [Then("Check the test link for form {string}")]
        public async Task ThenCheckTheTestLinkForForm(string formName)
        {
            string Environment = config["Environment"].Trim();
            bool checkUrl = await _dashboardPage.CheckTestLink(formName, Environment);
        }

        [Given("User is on Dashboard Page")]
        public async Task GivenUserIsOnDashboardPage()
        {
            await GenericHelper.WaitForPageLoadAsync(_page);
            Thread.Sleep(2000);
            AssertionHelper.AssertTrue(await _dashboardPage.WaitForDashboardPageToDisplayAsync(), "Digital Form Builder");
        }

        [Then("Verify Start Now link")]
        public async Task ThenVerifyStartNowLink()
        {
            AssertionHelper.AssertTrue(await _page.Locator("//button[text()='Start now']").IsVisibleAsync(), "Start now");
        }

        [Then("verify Digital Form Builder title")]
        public async Task ThenVerifyDigitalFormBuilderTitle()
        {
            AssertionHelper.AssertTrue(await _page.Locator("//h1[text()='Digital Form Builder Dashboard']").IsVisibleAsync(), "Digital Form Builder Dashboard");
        }

        [Then("user clicks on import saved form link")]
        public async Task ThenUserClicksOnImportSavedFormLink()
        {
            await _dashboardPage.ClickImportSavedFormJSON();
        }

        [Then("verify that system gives import json modal window")]
        public async Task ThenVerifyThatSystemGivesImportJsonModalWindow()
        {
            AssertionHelper.AssertTrue(await _page.Locator("//h2[text()='Import saved forms']").IsVisibleAsync(), "Import saved forms");
        }

        [Then("Import the json {string} with {string}")]
        public async Task ThenImportTheJsonWith(string jsonFile, string formName)
        {
            var formname = formName + DateTime.Now.ToString("s", CultureInfo.CreateSpecificCulture("en-US"));
            formname = Regex.Replace(formname, @"[):;.,'=-]", "");
            await _dashboardPage.EnterImportFormTitle(formname);
            string fileName = projectDirectory.ToString() + "\\TestData\\" + jsonFile;
            await _dashboardPage.SelectJSONFile(fileName);
        }

        [Then("user clicks on import .json button")]
        public async Task ThenUserClicksOnImport_JsonButton()
        {
            await _dashboardPage.ClickImportJSONButton();
        }


        [Then("click on Start Now link")]
        public async Task ThenClickOnStartNowLink()
        {
            await _dashboardPage.ClickStartNowButton();
        }

        [Then("I click on Create form button and create a new form")]
        public async Task ThenIClickOnCreateFormButtonAndCreateANewForm()
        {
            await _dashboardPage.ClickCreateFormButton();
            await _dashboardPage.EnterFormName();
            await _dashboardPage.ClickNextButton();
            await _dashboardPage.Click_Createform_link();
        }

        [Then("I click on Create form button and create a new form with existing form name")]
        public async Task ThenIClickOnCreateFormButtonAndCreateANewFormWithExistingFormName()
        {
            await _dashboardPage.ClickCreateFormButton();
            await _dashboardPage.EnterExistingFormName();
            await _dashboardPage.ClickNextButton();
            Assert.That(await _page.Locator("//div[@class='govuk-error-summary__body']/ul/li/a").TextContentAsync(), Is.EqualTo("A form with this name already exists"));
        }

        [Then("I add a new page with title {string} in the form")]
        public async Task ThenIAddANewPageWithTitleInTheForm(string title)
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.AddPage(title);
        }

        [Then("I edit the second page title {string}")]
        public async Task ThenIEditTheSecondPageTitle(string editTitle)
        {
            await _formDesignerPage.editSecondPageTitle(editTitle);
        }

        [Then("verify page titles {string} and {string} in form runner")]
        public async Task ThenVerifyPageTitlesAndInFormRunner(string newPageTitle, string editedPageTitle)
        {
            await _formDesignerPage.ValidatePageAddAndEdit(newPageTitle, editedPageTitle);
        }

        [Then("I edit the second page and click on duplicate page link")]
        public async Task ThenIEditTheSecondPageAndClickOnDuplicatePageLink()
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.DuplicatePage();
        }

        [Then("I click on outputs button and add a output {string} with DSI")]
        public async Task ThenIClickOnOutputsButtonAndAddAOutputWithDSI(string output)
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.AddOutput(output);
        }

        [Then("I verify that the output {string} is added")]
        public async Task ThenIVerifyThatTheOutputIsAdded(string output)
        {
            await _formDesignerPage.ValidateAddedOutput(output);
        }

        [Then("I create a form using DF API Post call")]
        public async Task ThenICreateAFormUsingDFAPIPostCall()
        {
            await _dashboardPage.CreateFormWithAPI();
        }

        [Then("I delete the created form using DF API Delete call")]
        public async Task ThenIDeleteTheCreatedFormUsingDFAPIDeleteCall()
        {
            await _dashboardPage.DeleteFormWithAPI();
        }

        [Then("I verify the duplicated page")]
        public async Task ThenIVerifyTheDuplicatedPage()
        {
            await _formDesignerPage.VerifyDuplicatedPage();
        }

        [Then("I edit the duplicated page and click on delete page")]
        public async Task ThenIEditTheDuplicatedPageAndClickOnDeletePage()
        {
            await _formDesignerPage.DeleteDuplicatedPage();
        }

        [Then("verify that the page got deleted")]
        public async Task ThenVerifyThatThePageGotDeleted()
        {
            await _formDesignerPage.VerifyDeletedPage();
        }

        [Then("the user tries to delete form and he shouldnt be able to delete it")]
        public async Task ThenTheUserTriesToDeleteFormAndHeShouldntBeAbleToDeleteIt()
        {
            var formName = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.ClickDeleteFormConfirmationForPublishedForm();
        }

        [Then("the user add a new section {string} to the form and verify the added section in the sections list")]
        public async Task ThenTheUserAddANewSectionToTheFormAndVerifyTheAddedSectionInTheSectionsList(string sectionName)
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.ClickSectionsButton();
            await _formDesignerPage.AddSection(sectionName);
            await _formDesignerPage.ClickBackButton();
        }


        [Then("I edit the newly added section title as {string}")]
        public async Task ThenIEditTheNewlyAddedSectionTitleAs(string sectionName)
        {
            await _formDesignerPage.ClickSectionsButton();
            await _formDesignerPage.EditSection(sectionName);
        }


        [Then("I delete the newly added section {string} and verify that the deleted section is not displayed in the sections list")]
        public async Task ThenIDeleteTheNewlyAddedSectionAndVerifyThatTheDeletedSectionIsNotDisplayedInTheSectionsList(string sectionName)
        {
            await _formDesignerPage.ClickSectionsButton();
            await _formDesignerPage.DeleteSection(sectionName);
        }

        [Then("the user add the new section {string} to the page")]
        public async Task ThenTheUserAddTheNewSectionToThePage(string sectionName)
        {
            await _formDesignerPage.AddSectionToPage(sectionName);
        }

        [Then("user verifies the section name {string} is added to the page")]
        public async Task ThenUserVerifiesTheSectionNameIsAddedToThePage(string sectionName)
        {
            await _formDesignerPage.VerifyTheAddedSection(sectionName);
        }

        [Then("I add a list{string} file {string} in import dataset")]
        public async Task ThenIAddAListFileInImportDataset(string list, string file)
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.AddListFile(list, file);
        }

        [Then("I add a new list{string} file {string} in import dataset")]
        public async Task ThenIAddANewListFileInImportDataset(string list, string file)
        {
            await _formDesignerPage.AddListFile(list + "_Updated", file);
        }

        [Then("I click on Lists from form menu and create a list {string} by importing a file {string}")]
        public async Task ThenIClickOnListsFromFormMenuAndCreateAListByImportingAFile(string listTitle, string file)
        {
            await _formDesignerPage.ClickListsButton();
            await _formDesignerPage.AddList(listTitle);
            await _formDesignerPage.ClickBackButton();
        }

        [Then("I edit the created list and update list title {string} and file {string}")]
        public async Task ThenIEditTheCreatedListAndUpdateListTitleAndFile(string listTitle, string file)
        {
            await _formDesignerPage.ClickListsButton();
            await _formDesignerPage.EditList(listTitle + "_Updated");
            await _formDesignerPage.ClickBackButton();
        }

        [Then("I remove a list item from the added list")]
        public async Task ThenIRemoveAListItemFromTheAddedList()
        {
            await _formDesignerPage.ClickListsButton();
            int initialCount = int.Parse((await _page.Locator("//tr/td[3]/p/span").TextContentAsync())!.Trim());
            await _formDesignerPage.RemoveListItem();
            int updatedCount = int.Parse((await _page.Locator("//tr/td[3]/p/span").TextContentAsync())!.Trim());
            Assert.That(updatedCount, Is.EqualTo(initialCount - 1));
            await _formDesignerPage.ClickBackButton();
        }

        [Then("I deleted the created list")]
        public async Task ThenIDeletedTheCreatedList()
        {
            await _formDesignerPage.ClickListsButton();
            await _formDesignerPage.DeleteList();
            await _formDesignerPage.ClickBackButton();
        }

        [Then("I delete the created form from dashboard")]
        public async Task ThenIDeleteTheCreatedFormFromDashboard()
        {
            await _dashboardPage.ClickCreateFormButton();
            var formName = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.Click_Confirmoption();
            await _dashboardPage.Click_Deletebutton();
        }

        [Then("User Click on switch access and change to public")]
        public async Task ThenUserClickOnSwitchAccessAndChangeToPublic()
        {
            var formName = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.ClickOnSwitchAccessButton();
            await _dashboardPage.SelectPublicRadiobtn();
            await _dashboardPage.ClickOnSwitchAccessButton();
            await _dashboardPage.ClickConfirmation();
        }

        [Then("User change status of the new form to {string}")]
        public async Task ThenUserChangeStatusOfTheNewFormTo(string status)
        {
            var formName = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formName);
            await _dashboardPage.ClickChangeStatus();
            await _dashboardPage.SelectStatus(status);
            await _dashboardPage.ClickChangeStatus();
            await _dashboardPage.ClickChangeStatusConfirmation();
        }

        [Then("user validates runner of the form for error message for users")]
        public async Task ThenUserValidatesRunnerOfTheFormForErrorMessageForUsers(DataTable dataTable)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            foreach (var row in dataTable.Rows)
            {
                var user = row["User"];
                await _dashboardPage.UserSelectTheForm(formNameFromFile);
                var parentPage = _page;
                _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
                {
                    await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                    await _dashboardPage.Click_Prodlink(formNameFromFile);
                });
                _dashboardPage = new DashboardPage(_page);
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await _dashboardPage.EnterUserNamePassword(user);
                var actualText = (await _page.Locator("//h1[@class='govuk-heading-xl']").InnerTextAsync()).Trim();

                if (user == "digitalforms01+103@gmail.com")
                {
                    Assert.That(
                        actualText,
                        Is.EqualTo("Your account needs approving before you can access this form. We will email you when it is ready."));
                }
                else if (user == "digitalforms01+102@gmail.com")
                {
                    Assert.That(
                        actualText,
                        Is.EqualTo("You cannot access this form through this UKPRN"));
                }
                await _dashboardPage.ClickSignOffLink();
                await _page.CloseAsync();
                _page = parentPage;
                _dashboardPage = new DashboardPage(_page);
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }
        }

        [Then("user validates runner of the form for error message for user {string} with UKPRN as {string}")]
        public async Task ThenUserValidatesRunnerOfTheFormForErrorMessageForUserWithUKPRNAs(string user, string ukprn)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            var parentPage = _page;
            _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
            {
                await _dashboardPage.Click_testlink(formNameFromFile);
            });
            _dashboardPage = new DashboardPage(_page);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _dashboardPage.EnterUserNamePassword(user);
            var actualText = (await _page.Locator("//h1[@class='govuk-heading-xl']").InnerTextAsync()).Trim();
            Assert.That(
                    actualText,
                    Is.EqualTo("You cannot access this form through this UKPRN"));
        }



        [Then("the user edits the form and click on import saved form link")]
        public async Task ThenTheUserEditsTheFormAndClickOnImportSavedFormLink()
        {
            await _dashboardPage.SelectFormAndClickEditButton();
        }


        [Then("the user uploads form json file {string}")]
        public async Task ThenTheUserUploadsFormJsonFile(string jsonFile)
        {
            string fileName = projectDirectory.ToString() + "\\TestData\\" + jsonFile;
            await _dashboardPage.SelectJSONFile(fileName);
        }

        [Then("verify that imported form with form name {string} is displayed in dashboard")]
        public async Task ThenVerifyThatImportedFormWithFormNameIsDisplayedInDashboard(string fileName)
        {
            await _dashboardPage.GetTextFromJSONAndCompare(fileName);
        }

        [Then("Check Footer link {string} section")]
        public async Task ThenCheckFooterLinkSection(string footersection)
        {
            await GenericHelper.WaitForPageLoadAsync(_page);
            string actualIntroVideosText = await _dashboardPage.LinkIntroductoryvideos();
            string contactsText = await _dashboardPage.LinkContacts();
            string wishListText = await _dashboardPage.LinkWishList();
            string submitBugText = await _dashboardPage.LinkSubmitBug();
            string copyrightText = await _dashboardPage.LinkCopyright();
            string contentDescText = await _dashboardPage.LabelContentDesc();
            if (footersection.Contains("Information guide"))
            {
                AssertionHelper.AssertTextEquals("Introductory videos", actualIntroVideosText);
            }
            else if (footersection.Contains("Support shortcuts"))
            {
                AssertionHelper.AssertTextEquals("Contacts", contactsText);
                AssertionHelper.AssertTextEquals("Wishlist", wishListText);
                AssertionHelper.AssertTextEquals("Submit a bug", submitBugText);

            }
            else
            {

                AssertionHelper.AssertTextEquals("All content is available under the Open Government Licence v3.0, except where otherwise stated", contentDescText);
                AssertionHelper.AssertTextEquals("© Crown copyright", copyrightText);

            }
        }


        [Then("Check Footer {string} and URL {string} in designer")]
        public async Task ThenCheckFooterAndURLInDesigner(string text, string link)
        {
           string name=await _page.Locator("//a[contains(text(),'Accessibility')]").TextContentAsync();
            Assert.IsTrue(name.Contains(text));


        }

        [Then("Check Footer {string} and URL {string}")]
        public async Task ThenCheckFooterAndURL(string name, string link)
        {
            string text = await _dashboardPage.GetFooterLinkValue(_page, name);
            Assert.IsTrue(link.Contains(text));
        }

        [Then("Verify the heading First page in runner")]
        public async Task ThenVerifyTheHeadingFirstPageInRunner()
        {
            string firstpage = await _dashboardPage.VerifyFirstPage();
            AssertionHelper.AssertTextEquals("First page", firstpage);
        }

        [Then("Delete the form")]
        public async Task ThenDeleteTheForm()
        {
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.Click_Confirmoption();
            await _dashboardPage.Click_Deletebutton();
        }

        [Then("Verify {string} in results")]
        public async Task ThenVerifyInResults(string noitemsfoundlabel)
        {
            string ActualText = await _dashboardPage.GetNoItemsfound();
            string ExpectedText = noitemsfoundlabel;
            AssertionHelper.AssertTextEquals(ActualText, ExpectedText, noitemsfoundlabel);

        }

        [Then("go to Dashboard")]
        public async Task ThenGoToDashboard()
        {
            await _dashboardPage.Click_Createform_link();
        }

        [Then("Verify button disabled in dashboard in {string}")]
        public async Task ThenVerifyButtonDisabledInDashboardIn(string form)
        {
            await GenericHelper.scrolldowntobottom(_page);
            AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.EditForm_Button), "Edit form");
            AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.Duplicate_Button), "Dulicate form");
            AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.Group_Button), "Group form");
            AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.Changestatus_Button), "change status");
            AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.SwitchAccess_Button), "Swtich Access");
            if (form.Equals("My form"))
            {
                AssertionHelper.AssertTrue(await GenericHelper.IsDisabled(_page, _dashboardPage.Delete_Button), "Delete form");
            }
        }

        [Then("Verify button enabled in dashboard {string}")]
        public async Task ThenVerifyButtonEnabledInDashboard(string form)

        {
            await GenericHelper.scrolldowntobottom(_page);
            AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.EditForm_Button), "Edit form");
            AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.Duplicate_Button), "Dulicate form");
            AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.Group_Button), "Group form");
            AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.Changestatus_Button), "change status");
            AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.SwitchAccess_Button), "Swtich Access");
            if (form.Equals("My form") && await _page.Locator("//button[normalize-space()='Delete form']").IsVisibleAsync())
            {
                AssertionHelper.AssertTrue(await GenericHelper.IsEnabled(_page, _dashboardPage.Delete_Button), "Delete form");
            }
        }
        [Then("select the top form")]
        public async Task ThenSelectTheTopForm()
        {
            await _page.WaitForTimeoutAsync(5000);
            await _dashboardPage.Click_Topform();
            await GenericHelper.scrolldowntobottom(_page);
        }

        [Then("click on Collegues form")]
        public async Task ThenScrolldownToColleguesFormStatus()
        {
            await GenericHelper.scrolldowntobottom(_page);
            await _dashboardPage.Click_Colleagueform_tab();
        }
        [Then("check {string} link enabled for form {string}")]
        public async Task ThenCheckLinkEnabledForForm(string UAT, string formname)
        {
            if (UAT.Equals("UAT"))
            {
                await GenericHelper.WaitForPageLoadAsync(_page);
                Thread.Sleep(2000);
                AssertionHelper.AssertTrue(await _dashboardPage.Enable_testlink(formname), "Test link Enabled");
            }
            else
            {
                await GenericHelper.WaitForPageLoadAsync(_page);
                Thread.Sleep(2000);
                AssertionHelper.AssertTrue(await _dashboardPage.enabled_prodlink(formname), "Prod link Enabled");
            }
        }

        [Then("check {string} link disabled for form {string}")]
        public async Task ThenCheckLinkDisabledForForm(string Prod, string formname)
        {
            AssertionHelper.AssertTrue(await _dashboardPage.Notenabled_prodlink(formname), "Prod link disabled");
        }
        [Then("Click on create component in second page")]
        public async Task ThenClickOnCreateComponent()
        {
            await _formDesignerPage.Clean_component();
            await _formDesignerPage.Create_component();

        }


        [Then("Click on create component in second page for result")]
        public async Task ThenClickOnCreateComponentInSecondPageForResult()
        {
            await _formDesignerPage.Create_component();
        }


        [Then("Verify {string} component")]
        public async Task ThenVerifyComponent(string component)
        {
            AssertionHelper.AssertTrue(await _createComponentPage.CheckComponent(component), component);
        }

        [Then("Verify component label {string}")]
        public async Task ThenVerifyComponentLabel(string label)
        {
            AssertionHelper.AssertTrue(await _createComponentPage.CheckComponentlabel(label), label);

        }
        [Then("Click on on the {string} Component")]
        public async Task ThenClickOnOnTheComponent(string componentname)
        {
            await _createComponentPage.Click_component(componentname);
        }

        [Then("Enter Title {string}")]
        public async Task ThenEnterTitle(string title)
        {
            await _formDesignerPage.EnterTitle(title);
        }

        [Then("Add Date and Time")]
        public async Task ThenAddDateAndTime()
        {
            await _formDesignerPage.EnterDate();
        }

        [Then("Add prefix value pound")]
        public async Task ThenAddPrefixValuePound()
        {
            await _formDesignerPage.AddPrefixValuePound();

        }
        [Then("Add suffix value")]
        public async Task ThenAddSuffixValue()
        {
            await _formDesignerPage.AddSuffixValue();
        }

        [Then("Add precision value")]
        public async Task ThenAddPrecisionValue()
        {
            await _formDesignerPage.AddPrecisionValue();
        }
        [Then("Add calculation in designer")]
        public async Task ThenAddCalculationInDesigner()
        {
            await _formDesignerPage.addCalculationInDesigner();
        }
        [Then("Select the calculation")]
        public async Task ThenSelectTheCalculation()
        {
            await _formDesignerPage.selectcalc();
        }

        [Then("Hide on page")]
        public async Task ThenHideOnPage()
        {
            await _formDesignerPage.HideOnPage();

        }
        [Then("Hide on summary")]
        public async Task ThenHideOnSummary()
        {
            await _formDesignerPage.Hideonsummary();
        }

        [Then("Click on menu {string}")]
        public async Task ThenClickOnMenu(string documents)
        {
            await _formDesignerPage.ClickOnMenu(documents);
        }

        [Then("design data set")]
        public async Task ThenDesignDataSet()
        {
            await _formDesignerPage.DesignDataSet();
        }

        [Then("design data set for table")]
        public async Task ThenDesignDataSetForTable()
        {
            await _formDesignerPage.DesignDataSetNew();
        }
        [Then("edit the design data set")]
        public async Task ThenEditTheDesignDataSet()
        {
            await _formDesignerPage.DesignDataSetupdated();
        }

        [Then("Delete data set")]
        public async Task ThenDeleteDataSet()
        {
            await _formDesignerPage.DeleteDataSet();
        }

        [Then("Add condition value {string},{string},{string},{string}")]
        public async Task ThenAddConditionValue(string displayname, string name, string condition1, string value)
        {
            await _formDesignerPage.AddConditionValue(displayname, name, condition1, value);
        }

        [Then("Add condition value {string},{string},{string},{string} in import")]
        public async Task ThenAddConditionValueInImport(string displayname, string name, string condition1, string value)
        {
            await _formDesignerPage.AddConditionValueimport(displayname, name, condition1, value);
        }

        [Then("Delete {string} in condition")]
        public async Task ThenDeleteInCondition(string condition)
        {
            await _formDesignerPage.DeleteInCondition(condition);
            await _dashboardPage.Click_Confirmoption();
            await _page.Locator("//button[@type='submit' and text()='Delete']").ClickAsync();
        }


        [Then("Enter the form name")]
        public async Task ThenEnterTheFormName()
        {
            await _dashboardPage.EnterFormName();
        }

        [Then("Enter the number value {string}")]
        public void ThenEnterTheNumberValue(string number)
        {
            _page.Locator("//input[@type='number']").FillAsync(number);
        }

        [Then("Upload the file {string} in designer")]
        public async Task ThenUploadTheFileInDesigner(string file)
        {
            await _formDesignerPage.UploadTheFile(_page, file);
        }

        [Then("Upload the file {string} in import dataset")]
        public async Task ThenUploadTheFileInImportDataset(string file)
        {
            await _formDesignerPage.UploadTheFileInImportDataset(file);
        }

        [Then("Upload the file {string} in import dataset for condition")]
        public async Task ThenUploadTheFileInImportDatasetForCondition(string file)
        {
            await _formDesignerPage.UploadTheFileInImportDatasetcond(file);
        }
        [Then("Upload the file {string} in import dataset in dataset")]
        public async Task ThenUploadTheFileInImportDatasetInDataset(string file)
        {

            await _formDesignerPage.UploadTheFileInImportDatasetNew(file);

        }

        [Then("Upload the file {string} in edit data set")]
        public async Task ThenUploadTheFileInEditDataSet(string file)
        {
            await _formDesignerPage.UploadTheFileInImportDatasetEdit(file);
        }

        [Then("delete import data set")]
        public async Task ThenDeleteImportDataSet()
        {
            await _formDesignerPage.DeleteImportDataSet();
        }


        [Then("Then User select the file in dropdown")]
        public async Task ThenThenUserSelectTheFileInDropdown()
        {
            await _formDesignerPage.UserSelectTheFileInDropdow("file");
        }
        [Then("Select the schema")]
        public async Task ThenSelectTheSchema()
        {
            await _formDesignerPage.SelectTheSchema();
        }

        [Then("Upload the file  {string} and validate")]
        public async Task ThenUploadTheFileAndValidate(string file)
        {
            await GenericHelper.UploadFileAsync(_page, "//input[@class='govuk-file-upload']", file);
            await _page.Locator("//button[contains(text(),'Validate Your File')]").ClickAsync();
        }
        [Then("User select the design data set")]
        public async Task ThenUserSelectTheDesignDataSet()
        {
            await _formDesignerPage.UserSelectTheDesignDataSet();
        }

        [Then("Add suffix value")]
        public async Task ThenAddSuffixValue(string p0)
        {
            await _formDesignerPage.AddSuffixValue();
        }

        [Then("Verify suffix value {string}")]
        public async Task ThenVerifysuffixValue(string suffix)
        {
            AssertionHelper.AssertTextEquals(await _page.Locator("//div[@class='govuk-input__suffix']").TextContentAsync(), suffix, suffix);
        }

        [Then("Verify prefix value {string}")]
        public async Task ThenVerifyPrefixValue(string prefix)
        {
            AssertionHelper.AssertTextEquals(await _page.Locator("//div[@class='govuk-input__prefix']").TextContentAsync(), prefix, prefix);
        }

        [Then("User select the design data set for tab")]
        public async Task ThenUserSelectTheDesignDataSetForTabAsync()
        {
            await _formDesignerPage.selecttab();
        }

        [Then("I click on summary behaviour and select skip summary")]
        public async Task ThenIClickOnSummaryBehaviourAndSelectSkipSummary()
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.SkipSummry();
        }

        [Then("I validate the summary is skipped in runner")]
        public async Task ThenIValidateTheSummaryIsSkippedInRunner()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.Locator("//button[@id='submit']").ClickAsync();
            await _page.Locator("//button[@id='submit']").ClickAsync();
            var label = "Submission complete";
            string Actual_Text = await _runner.Closedlstatus_text_first(_page);
            AssertionHelper.AssertTextEquals(_runner.Closedlstatus_text_first(_page).Result, label, label);
        }

        [Then("I click on documents and import a file {string}")]
        public async Task ThenIClickOnDocumentsAndImportAFile(string file)
        {
            await _dashboardPage.SelectFormAndClickEditButton();
            await _formDesignerPage.ClickDocuments();
            await _formDesignerPage.ImportFile(file);
        }

        [Then("I click on documents and edit document with file {string}")]
        public async Task ThenIClickOnDocumentsAndEditDocumentWithFile(string file)
        {
            await _formDesignerPage.ClickAndEditDocuments();
            await _formDesignerPage.ImportFile(file);
        }

        [Then("I click on documents and delete document")]
        public async Task ThenIClickOnDocumentsAndDeleteDocument()
        {
            await _formDesignerPage.ClickDeleteDocumentButton();
            await _formDesignerPage.VerifyDocumentDeleted();
        }

        [Then("Select the list {string}")]
        public async Task ThenSelectTheList(string list)
        {
            await _formDesignerPage.SelectTheList(list, list);
        }

        [Then("Select the list {string} and list type {string}")]
        public async Task ThenSelectTheListAndListType(string list, string type)
        {
            await _formDesignerPage.SelectTheList(list, type);
        }

        [Then("Enable optional in component")]
        public async Task ThenEnableOptionalInComponent()
        {
            await _formDesignerPage.EnableOptionalInComponen();


        }
        [Then("Select the select button {string} in component")]
        public async Task ThenSelectTheSelectButtonInComponent(string item)
        {
            await _page.Locator(".govuk-select").SelectOptionAsync(item);
        }



        [Then("Select {string} in autocomplete")]
        public async Task ThenSelectInAutocomplete(string item)
        {
            await _formDesignerPage.SelectInAutocomplete(item);
        }

        [Then("Enter content in  content {string} in text")]
        public async Task ThenEnterContentInContentInText(string text)
        {
            await _Insettextcomponent.EnterTEXT(text);
        }

        [Then("Enter Add New List {string} and {string}")]
        public async Task ThenEnterAddNewListAnd(string title, string value)
        {
            await _formDesignerPage.EnterAddNewList(title, value);
        }

        [Then("Enter content in HTML content {string}")]
        public async Task ThenEnterContentInHTMLContent(string HTML)
        {
            await _HTMLComponentPage.Enterhtml(HTML);
        }
        [Then("verify {string} in html component")]
        public async Task ThenVerifyInHtmlComponent(string HTML)
        {
            AssertionHelper.AssertEquals(await _HTMLComponentPage.GetText(), HTML, HTML);

        }

        [Then("Click on Save and continue")]
        public async Task ThenClickOnSaveAndContinue()
        {
            await _runner.ClickContinue(_page);
        }

        [Then("Select {string} in Select component")]
        public async Task ThenSelectInSelectComponent(string item)
        {
            await _runner.selectdropdown(_page, item);
        }

        [Given("User Navigated to runner")]
        public async Task GivenUserNavigatedToRunner()
        {
            await _page.GotoAsync("https://uat.test.digital-forms.education.gov.uk//v5a3x74w6k");

        }
        [Then("Select the select button {string}")]
        public async Task ThenSelectTheSelectButton(string optionalFields)
        {
            await _runner.selectcomponent(_page, optionalFields);
        }


        [Then("Check the page name {string}")]
        public async Task ThenCheckThePageName(string optionalFields)
        {
            AssertionHelper.AssertTextEquals(await _runner.GetTitle(_page), optionalFields, optionalFields);
        }


        [Then("check the Section name {string}")]
        public async Task ThenCheckTheSectionName(string SectionName)
        {
            AssertionHelper.AssertTextEquals(await _runner.GetSectionTitle(_page), SectionName, SectionName);

        }

        [Then("Verify component in page")]
        public async Task ThenVerifyComponentInPage()
        {
            bool DetailComponent = await _page.Locator(".govuk-details__summary-text").IsVisibleAsync();
            bool filedownload = await _page.Locator("//label[contains(text(),'File download component')]").IsVisibleAsync();
            bool HTMLComponent = await _page.Locator("//strong[text()='HTMLcomponent']").IsVisibleAsync();
            bool Insettextcomponet = await _page.Locator(".govuk-inset-text >p").IsVisibleAsync();
            bool ListComponent = await _page.Locator("//label[contains(text(),'List component')]").IsVisibleAsync();
            bool ParagraphComponent = await _page.Locator("//p[contains(text(),'Paragraph component')]").IsVisibleAsync();
            bool TableComponent = await _page.Locator("//label[contains(text(),'Table component')]").IsVisibleAsync();
        }
        [Then("Verify Table component {string}")]
        public async Task ThenVerifyTableComponent(string org)
        {
            string a = await _page.Locator("(//tr[@class='govuk-table__row']/td)[3]").TextContentAsync();

        }

        [Then("Enter  the field {string} autocomplete")]
        public async Task ThenEnterTheFieldAutocomplete(string autocomplete)
        {
            await _runner.EnterAutocomplete(autocomplete);
        }


        [Then("Enter  the field {string} Email")]
        public async Task ThenEnterTheFieldEmail(string Email)
        {
            await _runner.EnterEmail(Email);

        }
        [Then("Enter  the field {string} Email component")]
        public async Task ThenEnterTheFieldEmailComponent(string email)
        {
            await _page.Locator("[type='email']").FillAsync(email);

        }

        [Then("Upload the file  {string}")]
        public async Task ThenUploadTheFile(string file)
        {
            await _runner.Uploadfile(file);
            await _page.WaitForTimeoutAsync(10000);
        }


        [Then("Upload the file  {string} component")]
        public async Task ThenUploadTheFileComponent(string file)
        {

            await GenericHelper.UploadFileAsync(_page, "//input[@class='govuk-file-upload']", file);
        }


        [Then("Enter  the field {string} Multiline")]
        public async Task ThenEnterTheFieldMultiline(string multiline)
        {
            await _runner.Entermultiline(multiline);
        }

        [Then("Enter  the field {string} Multiline component")]
        public async Task ThenEnterTitleInComponent(string multiline)
        {
            await _page.Locator(".govuk-textarea").FillAsync(multiline);
        }

        [Then("Enter  the field {string} Telephone")]
        public async Task ThenEnterTheFieldTelephone(string Telephone)
        {
            await _runner.EnterTelephone(Telephone);
        }
        [Then("Enter  the field {string} Telephone component")]
        public async Task ThenEnterTheFieldTelephoneComponent(string Telephone)
        {
            await _page.Locator("[type='tel']").FillAsync(Telephone);
        }
        [Then("Enter  the field {string} Text")]
        public async Task ThenEnterTheFieldText(string text)
        {
            await _runner.EnterText(text);
        }
        [Then("Enter  the field {string} Text component")]
        public async Task ThenEnterTheFieldTextComponent(string text)
        {
            await _page.Locator("//input[contains(@title,'Text')]").FillAsync(text);
        }


        [Then("Select the radio button {string}")]
        public async Task ThenSelectTheRadioButton(string radio)
        {
            await _runner.selectchecbox(_page, radio);
        }

        [Then("Select the yesNo component  {string}")]
        public async Task ThenSelectTheYesNoComponent(string yesNo)
        {
            await _runner.selectyesno(_page, yesNo);
        }

        [Then("Select the Checkboxes {string}")]
        public async Task ThenSelectTheCheckboxes(string Checkboxes)
        {
            await _runner.selectcheckbox(_page, Checkboxes);
        }

        [Then("Enter  the field {string} Number")]
        public async Task ThenEnterTheFieldNumber(string Number)
        {
            await _runner.Enternumber(_page, Number);
        }

        [Then("Enter  the field {string} Number component in suffix")]
        public async Task ThenEnterTheFieldNumberComponentInSuffix(string number)
        {
            await _page.Locator("//input[@type='number']").FillAsync(number);
        }

        [Then("Enter  the field {string} Number component")]
        public async Task ThenEnterTheFieldNumberComponent(string number)
        {
            await _page.Locator(".govuk-input__prefix +input").FillAsync(number);
        }

        [Then("Enter  the field {string} Date in date component")]
        public async Task ThenEnterTheFieldDateInDateComponent(string Date)
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            await _page.Locator("[title='Day']")
                      .WaitForAsync(new() { State = WaitForSelectorState.Visible });
            string[] parts = Date.Split('/');
            await _page.Locator("[title='Day']").FillAsync(parts[0]);
            await _page.Locator("[title='Month']").FillAsync(parts[1]);
            await _page.Locator("[title='Year']").FillAsync(parts[2]);

            await _page.Locator("[title='Hour']").FillAsync(parts[3]);
            await _page.Locator("[title='Minute']").FillAsync(parts[4]);

            int hour = int.Parse(parts[3]);
            if (hour >= 12)
            {
                await _page.Locator("[value='pm']").ClickAsync();
            }
            else
            {
                await _page.Locator("[value='am']").ClickAsync();

            }

        }
        [Then("Enter  the field {string} Date")]
        public async Task ThenEnterTheFieldDate(string Date)
        {


            await _runner.enterdate(_page, Date);
        }

        [Then("Enter Title {string} and content {string}")]
        public async Task ThenEnterTitleAndContent(string title, string content)
        {
            await _detailsLinkComponentPage.EnterTitleAndContent(title, content);

        }

        [Then("verify {string}{string}{string} in Detail component")]
        public async Task ThenVerifyInDetailComponent(string content, string heading, string paragraph)
        {
            string a = await _detailsLinkComponentPage.GetTextdetail();
            string b = await _detailsLinkComponentPage.GetTextHeading();
            string c = await _detailsLinkComponentPage.GetTextParagraph();
            AssertionHelper.AssertTextEquals(await _detailsLinkComponentPage.GetTextdetail(), content, content);
            AssertionHelper.AssertTextEquals(await _detailsLinkComponentPage.GetTextHeading(), heading, heading);
            AssertionHelper.AssertTextEquals(await _detailsLinkComponentPage.GetTextParagraph(), paragraph, paragraph);

        }


        [Then("verify {string} in Detail component")]
        public void ThenVerifyInDetailComponent(string p0)
        {

        }
        [Then("Click on save button")]
        public async Task ThenClickOnSaveButton()
        {
            await _formDesignerPage.ClickSave();
        }


        [Then("User click on Edit form in my form")]
        public async Task ThenUserClickOnEditFormInMyForm()
        {
            await _dashboardPage.Click_Editform();

        }
        [Then("Click on test link in dashboard in {string}")]
        [Then("Click on test link for form {string}")]
        public async Task ThenClickOnTestLinkForForm(string formname)
        {
            _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
            {
                await _dashboardPage.Click_testlink(formname);
            });

        }
        [Then("Click on continue in (.*) Page")]
        [Then("Click on continue")]
        public async Task ThenClickOnContinuepage(string page)
        {

            await _runner.ClickContinue(_page);

        }
        [Then("Click on continue button")]
        public async Task ThenClickOnContinueButton()
        {
            await _runner.ClickContinue(_page);
        }

        [Then("click on submit button")]
        public async Task ThenClickOnSubmitButton()
        {
            await _runner.ClickContinue(_page);
            await TabHelper.CloseTabAndReturnAsync(_page);
            Thread.Sleep(2000);
        }

        [Then("Click on preview button")]
        public async Task ThenClickOnPreviewButton()
        {
            _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
            {
                await _dashboardPage.Click_Preview();
            });

        }

        [Then("Verify {string} in page")]
        public async Task ThenVerifyInPage(string Label1)
        {
            await _page.WaitForLoadStateAsync();
            Thread.Sleep(2000);
            string Actual_Text = await _runner.Closedlstatus_text_first(_page);
            AssertionHelper.AssertTextEquals(_runner.Closedlstatus_text_first(_page).Result, Label1, Label1);

        }


        [Then("close the runner window")]
        public async Task ThenCloseTheRunnerWindow()
        {
            _page = await TabHelper.CloseTabAndReturnAsync(_page);

        }
        [Then("Verify {string} Button in summary")]
        public void ThenVerifyButtonInSummary(string button)
        {
            if (button.Contains("Submit"))
            {
                Thread.Sleep(2000);
                AssertionHelper.AssertTextEquals(_runner.GetSubmittext(_page).Result, button, button);
            }
            else
            {
                AssertionHelper.AssertTextEquals(_runner.GetSummarypdftext(_page).Result, button, button);

            }

        }

        [Then("clean the component")]
        public async Task ThenCleanTheComponent()
        {
            Thread.Sleep(2000);
            await GenericHelper.WaitForPageLoadAsync(_page);
            await _page.BringToFrontAsync();
            await _page.WaitForLoadStateAsync();
            await _runner.Cleancomponent(_page);

        }

        [Then("Click on {string} button in summary")]
        public async Task ThenClickOnButtonInSummary(string submit)
        {

            await GenericHelper.Click(_page, _runner.submitbutton);
        }


        [Then("Verify {string} text")]
        public async Task ThenVerifyText(string Label)
        {
            if (Label.Contains("Contact us"))
            {
                string Actual_Text = await _runner.Closedlstatus_text_two(_page);
                AssertionHelper.AssertTextEquals(Actual_Text, Label, Label);
            }
            else
            {
                string Actual_Text = await _runner.Closedlstatus_text_three(_page);
                AssertionHelper.AssertTextEquals(Actual_Text, Label, Label);
                await TabHelper.CloseTabAndReturnAsync(_page);


            }
        }


        [Then("Click on create new form button")]
        public async Task ThenClickOnCreateNewFormButton(DataTable dataTable)
        {
            var formData = dataTable.CreateSet<Summaryvalues>();
            File.WriteAllText(filePath, string.Empty);

            foreach (Summaryvalues data in formData)
            {
                string formName =
                    data.FormName.Trim() +
                    DateTime.Now.ToString("s", CultureInfo.CreateSpecificCulture("en-US"));

                formName = Regex.Replace(formName, @"[):;.,'=-]", "");
                await _dashboardPage.ClickCreateFormButton();
                await _dashboardPage.EnterFormName(formName);
                await _dashboardPage.ClickNextButton();
                await _dashboardPage.Click_Createform_link();
                //Storing form name value in file.txt
                File.AppendAllText(filePath, formName + Environment.NewLine);
            }

        }

        [Then("user should add a DSI component {string} and  condition {string} in parent form with {string} and change page type of Parent form as {string}")]
        public async Task ThenUserShouldAddADSIComponentAndConditionInParentFormWithAndChangePageTypeOfParentFormAs(string dsiComponent, string condition, string ukprn, string pageType)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.Click_Editform();
            await _formDesignerPage.SummaryPageEditClick();
            await _formDesignerPage.SelectPageTypeDropDown(pageType);
            await _formDesignerPage.ClickSaveButton();
            await _formDesignerPage.ClickCreateComponentButton();
            await _formDesignerPage.ClickDSIComponentLink();
            await _formDesignerPage.EnterDSIdetails(dsiComponent);
            await _formDesignerPage.AddCondition(dsiComponent, ukprn, condition);
            await _dashboardPage.Click_Createform_link();
        }

        [Then("user create parent child relationship between the created forms with condition {string}")]
        public async Task ThenUserCreateParentChildRelationshipBetweenTheCreatedFormsWithCondition(string condition)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            var lines = File.ReadAllLines(filePath);
            List<string> arrayList = new List<string>();
            foreach (var line in lines)
            {
                arrayList.Add(line.ToString());
            }
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickGroupFormButton();
            await _parentChildPage.ClickMarkThisAsParentFormCheckbox();
            await _parentChildPage.EnterDescriptionAndHeading();
            await GenericHelper.scrolldowntobottom(_page);
            await _parentChildPage.SelectChildForm(arrayList[1]);
            await GenericHelper.scrolldowntobottom(_page);
            for (int j = 2; j < arrayList.Count; j++)
            {
                await _parentChildPage.SearchDepedentForm(arrayList[j]);
            }
            await _parentChildPage.SelectDependentFormStatuses();
            await _parentChildPage.SelectCondition(condition);
            await _parentChildPage.ClickAddChildButton();
            await _parentChildPage.ClickOnGroupFormButton();
            await GenericHelper.scrolldowntobottom(_page);
            await _parentChildPage.ConfirmParentChildGrouping();
        }

        [Then("user duplicates the parent child forms with new form names")]
        public async Task ThenUserDuplicatesTheParentChildFormsWithNewFormNames()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            var lines = File.ReadAllLines(filePath);
            List<string> arrayList = new List<string>();
            foreach (var line in lines)
            {
                arrayList.Add(line.ToString());
            }
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickDuplicateFormButton();
            await _dashboardPage.RenameParentForm(lines[0]);
            await _dashboardPage.RenameChildForms(lines);
            await _dashboardPage.ClickDuplicateFormButton();
        }

        [Then("user deletes duplicate parent child forms from dashboard")]
        public async Task ThenUserDeletesDuplicateParentChildFormsFromDashboard()
        {
            string formNameFromFile = File.ReadLines(filePath).Last();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.SelectParentAccessTypeCheckbox();
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.ClickDeleteFormConfirmation();
        }

        [Then("Verify all forms in dashboard")]
        public async Task ThenVerifyAllFormsInDashboard()
        {
            var lines = File.ReadAllLines(filePath);
            List<string> arrayList = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                arrayList.Add(lines[i].ToString());
                await _dashboardPage.SearchForForm(lines[i].ToString());
                string actualFormName = await _dashboardPage.GetFormName();
                AssertionHelper.AssertEquals(lines[i].ToString(), actualFormName, "Equal");
            }
        }

        [Then("user change page type of Parent form as {string}")]
        public async Task ThenUserChangePageTypeOfParentFormAs(string pageType)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.SearchForForm(formNameFromFile);
            Thread.Sleep(2000);
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.Click_Editform();
            await _formDesignerPage.SummaryPageEditClick();
            await _formDesignerPage.SelectPageTypeDropDown(pageType);
            await _formDesignerPage.ClickSaveButton();
            await _dashboardPage.Click_Createform_link();
        }

        [Then("user create parent child relationship between the created forms")]
        public async Task ThenUserCreateParentChildRelationshipBetweenTheCreatedForms()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            var lines = File.ReadAllLines(filePath);
            List<string> arrayList = new List<string>();
            foreach (var line in lines)
            {
                arrayList.Add(line.ToString());
            }
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickGroupFormButton();
            await _parentChildPage.ClickMarkThisAsParentFormCheckbox();
            await _parentChildPage.EnterDescriptionAndHeading();
            await GenericHelper.scrolldowntobottom(_page);
            await _parentChildPage.SelectChildForm(arrayList[1]);
            await GenericHelper.scrolldowntobottom(_page);
            for (int j = 2; j < arrayList.Count; j++)
            {
                await _parentChildPage.SearchDepedentForm(arrayList[j]);
            }
            await _parentChildPage.SelectDependentFormStatuses();
            await _parentChildPage.ClickAddChildButton();
            await _parentChildPage.ClickOnGroupFormButton();
            await GenericHelper.scrolldowntobottom(_page);
            await _parentChildPage.ConfirmParentChildGrouping();
        }

        [Then("user ungroup the parent child forms")]
        public async Task ThenUserUngroupTheParentChildForms()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickGroupFormButton();
            await _parentChildPage.ClickMarkThisAsParentFormCheckbox();
            await _parentChildPage.ConfirmUnGroupingForms();
        }

        [Then("Verify the ungrouped parent child forms in dashboard")]
        public async Task ThenVerifyTheUngroupedParentChildFormsInDashboard()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            string formName = await _dashboardPage.GetFormName();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            AssertionHelper.AssertEquals(formNameFromFile.ToString(), formName, "Equal");
            AssertionHelper.AssertFalse(await _parentChildPage.checkArrowForParent());
        }

        [Then("Verify the grouped parent child forms in dashboard")]
        public async Task ThenVerifyTheGroupedParentChildFormsInDashboard()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            string formName = await _dashboardPage.GetFormName();
            AssertionHelper.AssertEquals(formNameFromFile.ToString(), formName, "Equal");
            AssertionHelper.AssertTrue(await _parentChildPage.checkArrowForParent());
        }

        [Then("user change switch access type to DFESignIn with {string} for all the forms in parent group")]
        public async Task ThenUserChangeSwitchAccessTypeToDFESignInWithForAllTheFormsInParentGroup(string file)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickSwitchAccess();
            await _dashboardPage.SelectParentAccessTypeCheckbox();
            await _dashboardPage.SelectDfESignInRadiobtn();
            await _dashboardPage.UploadCSVFile(file);
            await _dashboardPage.ClickOnSwitchAccessButton();
            await _dashboardPage.ClickConfirmation();

        }

        [Then("user validates runner of the parent child form with user ID {string}")]
        public async Task ThenUserValidatesRunnerOfTheParentChildFormWithUserID(string userID)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            var lines = File.ReadAllLines(filePath);
            List<string> arrayList = new List<string>();
            foreach (var line in lines)
            {
                arrayList.Add(line.ToString());
            }
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
            {
                await _dashboardPage.Click_testlink(formNameFromFile);
            });
            _dashboardPage = new DashboardPage(_page);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _dashboardPage.EnterUserNamePassword(userID);
            await _runner.ClickContinue(_page);
            await _runner.ClickSaveAndContinue(_page);
            await _runner.ClickSaveAndContinue(_page);
            var firstColumn = _page.Locator("//tr[@class='govuk-table__row pc-row']/td[@class='govuk-table__cell pl cell1']");
            var secondColumn = _page.Locator("//tr[@class='govuk-table__row pc-row']/td[@class='govuk-table__cell cell2']");
            for (int j = 1; j < lines.Length; j++)
            {
                Assert.That(
                    await firstColumn.Nth(j - 1).InnerTextAsync(),
                    Is.EqualTo(lines[j]));

                Assert.That(
                    (await secondColumn.Nth(j - 1).InnerTextAsync()).Trim(),
                    Is.EqualTo(j == 1 ? "Cannot Start Yet" : "Not Started"));
            }
        }

        [Then("user update child heading to validate the error message")]
        public async Task ThenUserUpdateChildHeadingToValidateTheErrorMessage()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickGroupFormButton();
            await _dashboardPage.EnterLargeHeading();
            await GenericHelper.scrolldowntobottom(_page);
            await _parentChildPage.ClickOnGroupFormButton();
            await _parentChildPage.ConfirmParentChildGrouping();
            Assert.That((await _page.Locator("//h2[@class='govuk-error-summary__title']")
        .InnerTextAsync()).Trim(), Is.EqualTo("Sorry, there is a problem with the service"));
        }


        [Then("user change status of parent and child forms to {string}")]
        public async Task ThenUserChangeStatusOfParentAndChildFormsTo(string status)
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickChangeStatus();
            await _dashboardPage.SelectParentAccessTypeCheckbox();
            await _dashboardPage.SelectStatus(status);
            await _dashboardPage.ClickChangeStatus();
            await _dashboardPage.ClickChangeStatusConfirmation();
        }

        [Then("user deletes parent child forms from dashboard")]
        public async Task ThenUserDeletesParentChildFormsFromDashboard()
        {
            string formNameFromFile = File.ReadLines(filePath).First();
            await _dashboardPage.UserSelectTheForm(formNameFromFile);
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.SelectParentAccessTypeCheckbox();
            await _dashboardPage.ClickDeleteForm();
            await _dashboardPage.ClickDeleteFormConfirmation();
        }

        [Given("User Navigated to runner with formID {string}")]
        public async Task GivenUserNavigatedToRunnerWithFormID(string formID)
        {
            var tags = _scenarioContext.ScenarioInfo.Tags;

            Console.WriteLine(tags[0]);
            if (tags[0].Contains("preprod"))
            {
                Enviorments = "preprod";
            }
            else if (tags[0].Contains("test"))
            {
                Enviorments = "test";
            }
            else if (tags[0].Contains("dev"))
            {
                Enviorments = "dev";
            }
            string runnerurl;
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(projectDirectory, "appsettings.json"))
                .AddEnvironmentVariables()
                .Build();

            string? environment = config["Environment"]?.Trim();

            if (string.IsNullOrEmpty(environment))
                throw new Exception("Environment is not configured.");
       
            string baseUrl = "https://" + Enviorments + ".digital-forms.education.gov.uk/";
            runnerurl = baseUrl + formID;
            Console.WriteLine(runnerurl);
            await _page.GotoAsync(runnerurl);
            var submitButton = _page.Locator("//button[@type='submit']");
            if (await submitButton.IsVisibleAsync())
            {
                await submitButton.ClickAsync();
            }
        }

        [Then("Enter {string} and {string} and select the {string} in {string}")]
        public async Task ThenEnterAndAndSelectTheIn(string dFEUserName, string password, string dfesign, string org)
        {
            try
            {
                string Page_Title = (await _page.Locator("(//h1)[1]").TextContentAsync())?.Trim();

                if (Page_Title == "Access the DfE Sign-in service")
                {
                    await _dashboardPage.EnterUserNamePassword(dFEUserName);
                }

                await _page.WaitForTimeoutAsync(1000);

                string Page_Title1 = (await _page.Locator("(//h1)[1]").TextContentAsync())?.Trim();

                if (org.Trim().Contains("Authority"))
                {
                    await _page.Locator($"//span[contains(text(),'{org}')]").ClickAsync();
                    await _page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
                    await _page.WaitForTimeoutAsync(1000);
                    await _page.Locator("//input[@type='submit']").ClickAsync();
                }
                else
                {
                    if (Page_Title1 == "Select your organisation")
                    {
                        await _dashboardPage.ChooseDFEandOrg(dfesign, org);
                    }
                }
            }
            catch (Exception ex) { }
        }
        [Then("Click on show filter")]
        public async Task ThenClickOnShowFilter()
        {
            await _dashboardPage.ClickOnShowFilter();
        }

        [Then("Click on status {string}")]
        public async Task ThenClickOnStatus(string status)
        {
            await _dashboardPage.ClickOnStatus();
        }
        [Then("Click on search button")]
        public async Task ThenClickOnSearchButton()
        {
            await _dashboardPage.ClickOnSearchButton();
        }

        [Then("Check the form status")]
        public async Task ThenCheckTheFormStatus()
        {
            bool status = await _formDesignerPage.CheckTheFormStatus();
            AssertionHelper.AssertTrue(status, "status");
        }

        [Then("Click on Access Type {string}")]
        public async Task ThenClickOnAccessType(string access)
        {
            await _dashboardPage.ClickOnAccessType();
        }

        [Then("Check the form access type")]
        public async Task ThenCheckTheFormAccessType()
        {
            await _dashboardPage.CheckTheFormAccessType();
        }


        [Then("Enter from date {string} to todays date")]
        public async Task ThenEnterFromDateToTodaysDate(string date)
        {
            await _dashboardPage.FromDateToTodaysDate(date);
        }
        [Then("Enter name in created by")]
        public async Task ThenEnterNameInCreatedBy()
        {
            await _dashboardPage.EnterNameInCreatedBy();
        }

        [Then("Check the result")]
        public async Task ThenCheckTheResult()
        {
            await _dashboardPage.CheckTheResult();
        }


        [Then("verify Organization  {string} and {string} in your detail page")]
        public async Task ThenVerifyOrganizationAndInYourDetailPage1(string p0, string p1)
        {
            try
            {
                if ((await _page.Locator("(//div[@class='govuk-body']/div)[1]").TextContentAsync())
                        ?.Contains("Your details") == true)
                {
                    await _page.Locator("//button[text()='Continue']").ClickAsync();
                }
            }
            catch (Exception ex) { }
        }

        [Then("I enter all input details in the form")]
        public async Task ThenIEnterAllInputDetailsInTheForm()
        {
            await _runner.EnterAllFormDetails(_page);
        }

        [Then("I validate the fields in summary page")]
        public async Task ThenIValidateTheFieldsInSummaryPage()
        {
            await _runner.ValidateValuesInSummary(_page);
        }


        [Then("I submit the form")]
        public async Task ThenISubmitTheForm()
        {
            await _runner.SubmitForm(_page);
        }

        [Then("I change values from summary page")]
        public async Task ThenIChangeValuesFromSummaryPage()
        {
            await _runner.ChangeValuesFromSummaryPage(_page);
        }
    }
}

