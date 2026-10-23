using Bogus;
using DigitalForm_AutomationSuite.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using PlaywrightBDD_Framework.Helper;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PlaywrightBDD.Pages
{
    public class DashboardPage
    {
        private IPage _page;
        private PropertiesReader reader;
        private readonly ConfigurationManager config;
        public DashboardPage(IPage page)
        {
            _page = page;
            reader = new PropertiesReader(projectDirectory + "\\TestData\\Digitalform.properties");
            config = new ConfigurationManager();
            config.AddJsonFile(projectDirectory + "\\Appsettings.json");
            config.AddEnvironmentVariables();
        }
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        private string URL;
        private ChangeAccessType _changeAccessType;
        // Timestamped file name
        string fileName = Path.Combine(
            projectDirectory,
            $"file_{DateTime.Now:MMddyyyyhhmmsstt}.txt"
        );
        string filePath = Path.Combine(projectDirectory, "TestData", "file.txt");

        public string[] StartNow = new[]
        {
            ".govuk-button.govuk-button--start",
            "//button[text()='Start']",
            "button:has-text('Start')"
        };

        public string[] DigitalFormBuilder_Label = new[]
        {
             ".govuk-heading-xl",
             ".dashboard-container>h1",
             "[data-testid='dashboard-container']>h1"
        };
        public string[] Search_Editbox = new[]
  {
             ".govuk-input.govuk-input--width-20",
             "#width-20",
             "[type='search']",
             "(//input)[1]"
        };
        public string[] Search_Icon = new[]
    {
             ".searchBox",
             "//*[@height='1em']",
             "[width='1em']"
        };

        public string[] search = new[] { "input govuk-input" };
        public string[] CreateFormButton = new[]
    {
             "//button[@title='Create form']",
             "//input[@type='text']",
             "//button[contains(text(),'Create new form')]",
             "//a[contains(text(),'Create new form')]"
        };
        public string[] clickNextButton = new[]
    {
             "//button[contains(text(),'Next')]",
             "//button"
        };
        public string[] enterFormName = new[]
    {
             "//input[@name='formName']",
             "//button[@type='button']",
             "//input"
        };
        public string[] Colleagueform_tab = new[]
         {
             ".govuk-tabs__tab[href = '#colleague_forms']",
             "//a[contains(text(),'Colleagues')]",
             "[href = '#colleague_forms']"
        };

        public string[] SwitchAccess_Button = new[]
           {
            "//button[text()='Switch access']",
             ".table-actions-container>:nth-of-type(5)",
             "//button[text()='Switch access']"
        };
        public string[] Changestatus_Button = new[]
        {
            "//button[normalize-space()='Change status']",
             ".table-actions-container>:nth-of-type(4)",
             "//button[normalize-space()='Change status']"
        };
        public string[] Status_label = new[]
{
            "#add-child-forms-my-forms-table-td-cell-0-3>div",
             ".table-actions-container>:nth-of-type(4)",
             "//button[normalize-space()='Change status']"
        };
        public string[] Delete_Button = new[]
{
           "//button[normalize-space()='Delete form']",
             ".table-actions-container>:nth-of-type(6)",
             "//button[normalize-space()='Delete form']"
        };
        public string[] GroupForm_Button = new[]
{
           "//button[text()='Group form']",
             ".table-actions-container>:nth-of-type(3)",
             "//button[text()='Group form']"
        };
        public string[] StartNow_Button = new[] {
         "//button[text()='Start now']",
             "//button[@class='govuk-button govuk-button--start']",
             "//button[text()='Start now']"
        };
        public string[] importSaveFormButton = new[] {
         "//a[text()='Import saved form']"
        };
        public string[] importFormTitle = new[] { "//input[@name='import-form-title']" };
        public string[] clickImportJSONButton = new[] { "//button[text()='Import .json']" };
        public string[] formDetailsButton = new[] { "//button[text()='Form details']" };
        public string getFormName = "//input[@name='title']";
        public string[] Introductoryvideos = new[] {
         "//a[@href='https://www.youtube.com/channel/UCROOCs9OvIwqFOy5_E0Jtfg']"
        };
        public string[] Contacts = new[] {
         "//a[@href='https://www.gov.uk/contact-dfe'][1]"
        };
        public string[] WishList = new[] {
         "//div[@class='shortcuts']/a[3]"
        };
        public string[] SubmitBug = new[] {
         "//a[@href='https://www.gov.uk/help/report-vulnerability']"
        };
        public string[] Copyright = new[] {
         "//a[contains(text(),'Crown')]"
        };
        public string[] ContentDesc = new[] {
         "//span[@class='govuk-footer__licence-description']"
        };
        public string[] clickSearch = new[] {
         "//input[@type='search']"
        };
        public string[] Confirm_option = new[]
{
            ".govuk-checkboxes__input",
             "[name='delete-confirm']",
             "#delete-confirm-0"
        };

        public string[] Delete_Button_popup = new[]
{
            "[name='on-form-delete-confirm-submit-button']",
             "(//button[text()='Delete form'])[2]"
        };
        public string[] Create_form_link = new[]
{
            "a.govuk-link.submenu__link",
             "[href='/app/dashboard']",
             "//a[text()='Create new form']"
        };
        public string[] Noitemsfound_Label = new[]
  {
            "#spacing-RByY1+p",
             "//p[@class='govuk-body   govuk-!-text-align-centre govuk-!-margin-0 ']",
             "//a[text()='Create new form']"
        };
        public string[] EditForm_Button = new[]
  {
            ".table-actions-container >button:nth-child(1)",
            "//button[text()='Edit form']"
        };
        public string[] Duplicate_Button = new[]
  {
            ".table-actions-container >button:nth-child(2)",
            "//button[text()='Duplicate form']"
        };
        public string[] Group_Button = new[]
  {
            ".table-actions-container >button:nth-child(3)",
            "//button[text()='Group form']"
        };
        public string[] Top_form = new[]
   {
            "(//input[@id='select-form'])[1]",
            "//button[text()='Group form']"
        };

        public string[] Preview_link = new[]
   {
            "(//a[text()='Preview'])[1]",
            ""
        };
        public string[] selectParentCheckbox = new[]
  {
            "//div[@class='govuk-checkboxes__item']/input[1]"
        };
        public string[] selectDfESigninRadioButton = new[]
  {
            "//label[text()='DFE SignIn']/preceding-sibling::input"
        };
        public string[] selectPublicRadioButton = new[]
 {
            "//label[text()='Public']/preceding-sibling::input"
        };
        public string[] uploadCSVFile = new[]
   {
            "//input[@type='file']"
        };
        public string[] clickSwitchAccessButton = new[]
   {
            "//button[text()='Switch access']"
        };
        public string[] clickConfirmationCheckbox = new[]
   {
            "//input[@name='check01']", "//input[@name='check1']"
        };
        public string[] clickChangeStatusConfirmation = new[]
   {
            "//input[@name='status-confirm']"
        };
        public string[] clickDeleteFormConfirmation = new[]
   {
            "//input[@name='delete-confirm']"
        };
        public string[] clickSwitchAccessConfirmationButton = new[]
  {
            "(//button[text()='Switch access'])[2]"
        };
        public string[] clickChangeFormStatusButton = new[]
  {
            "//button[text()='Change form status']"
        };
        public string[] clickDeleteFormButton = new[]
 {
            "(//button[contains(text(),'Delete form')])[2]"
        };
        public string[] DFESigninCheckbox = new[]
{
            "//input[@value='DFE SignIn']"
        };
        public string[] renameParentForm = new[]
{
            "//input[@name='rename-parent-form']"
        };
        public string[] checkForDuplicateButton = new[]
{
            "//button[contains(text(),'Check for duplicate')]"
        };
        public string[] UserNameEditBox = new[]
{
            "//input[@id='username']"
        };
        public string[] nextButton = new[]
{
            "//button[contains(text(),'Next')]"
        };
        public string[] PasswordEditBox = new[]
{
            "//input[@id='password']"
        };
        public string[] Signinbutton = new[]
{
            "//button[@type='submit']"
        };
        public string[] SignOutbutton = new[]
{
            "//span[@id='dfe-designer-signout']"
        };
        public string[] SignOutConfirmation = new[]
{
            "//input[@id='confirmcheckbox']"
        };
        public string[] SignOutConfirmationButton = new[]
{
            "//button[text()='Sign out']"
        };
        public string[] headingText = new[]
{
            "//input[@name='add-child-list-heading']"
        };
        public string[] duplicateFormName = new[] { "[name=\"rename-parent-form\"]" };

        public async Task Click_Preview()
        {
            await GenericHelper.Click(_page, Preview_link);
        }

        public async Task Click_Editform()
        {
            await GenericHelper.Click(_page, EditForm_Button);
        }

        public async Task Click_Topform()
        {
            await GenericHelper.Click(_page, Top_form);
        }

        public async Task Click_Createform_link()
        {
            await GenericHelper.Click(_page, Create_form_link);
        }

        public async Task Click_Confirmoption()
        {
            await GenericHelper.Click(_page, Confirm_option);
        }
        public async Task Click_Duplicatebutton()
        {
            await GenericHelper.Click(_page, Duplicate_Button);
        }
        public async Task Click_Deletebutton()
        {
            await GenericHelper.Click(_page, Delete_Button_popup);
        }

        public async Task Click_Colleagueform_tab()
        {
            await GenericHelper.Click(_page, Colleagueform_tab);
        }
        public async Task ClickOnShowFilter()
        {
            await _page.Locator("//button[text()='Show filters']").ClickAsync();
        }
        public async Task ClickOnStatus()
        {
            await _page.Locator("//input[@id='form-status-1']").ClickAsync();
        }
        public async Task ClickChangeStatus()
        {
            await GenericHelper.Click(_page, Changestatus_Button);
        }
        public async Task ClickSwitchAccess()
        {
            await GenericHelper.Click(_page, SwitchAccess_Button);
        }
        public async Task ClickDeleteForm()
        {
            await GenericHelper.ScrollToElementAsync(_page, Delete_Button);
            await GenericHelper.Click(_page, Delete_Button);
        }

        public async Task ClickDuplicateFormButton()
        {
            await GenericHelper.Click(_page, Duplicate_Button);
        }

        public async Task EnterDuplicateFormName(string formName)
        {
            await GenericHelper.Fill(_page, duplicateFormName, formName);
        }

        public async Task RenameParentForm(string parentName)
        {
            string newFormName = parentName + "_Duplicate";
            //Storing form name value in file.txt
            File.AppendAllText(filePath, newFormName + Environment.NewLine);
            await GenericHelper.Fill(_page, renameParentForm, newFormName);
            await CheckForDuplicate();
        }

        public async Task RenameChildForms(string[] forms)
        {
            for (int i = 1; i < forms.Length; i++)
            {
                await _page.Locator("//tr[@class='govuk-table__row'][" + i + "]//input[@class='govuk-checkboxes__input']").ClickAsync();
                await enterChildFormName(forms[i] + "_Duplicate", i);
                await CheckForChildDuplicate(i);
                await CheckForChildDuplicate(i);
            }
        }

        public async Task enterChildFormName(String childForm, int childNumber)
        {
            await _page.Locator("//tr[@class='govuk-table__row'][" + childNumber + "]//input[@class='govuk-input  ']").FillAsync(childForm);
        }

        public async Task CheckForDuplicate()
        {
            await GenericHelper.Click(_page, checkForDuplicateButton);
        }
        public async Task CheckForChildDuplicate(int number)
        {
            await _page.Locator("//tr[@class='govuk-table__row'][" + number + "]//button[contains(text(),'Check for duplicate')][1]").ClickAsync();
        }
        public async Task EnterLargeHeading()
        {
            string headingTextValue =
                string.Join(" ", Enumerable.Repeat(
                    "This is displayed as a heading for the child form list.", 30));

            await _page.Locator("//input[@name='add-child-list-heading']").FillAsync(headingTextValue);
        }

        public async Task ClickGroupFormButton()
        {
            await GenericHelper.Click(_page, GroupForm_Button);
        }
        public async Task<Boolean> WaitForDashboardPageToDisplayAsync()
        {
            return await _page.Locator("//h1[contains(text(),'Digital Form Builder')]").IsVisibleAsync();
        }

        public async Task ClickStartNowButton()
        {
            await GenericHelper.Click(_page, StartNow_Button);
        }

        public async Task ClickImportSavedFormJSON()
        {
            await GenericHelper.Click(_page, importSaveFormButton);
        }

        public async Task EnterImportFormTitle(string formName)
        {
            await GenericHelper.Fill(_page, importFormTitle, formName);
        }

        public async Task SelectJSONFile(string jsonFileName)
        {
            await _page.Locator("//input[@type='file']").SetInputFilesAsync(jsonFileName);
        }

        public async Task GetTextFromJSONAndCompare(string fileName)
        {
            string filePath = Path.Combine(projectDirectory, "TestData", fileName);
            var jsonContent = File.ReadAllText(filePath);
            dynamic payload = JsonConvert.DeserializeObject(jsonContent);
            string expectedFormName = payload.displayName?.ToString();
            var actualFormName = await GetFormNameFromFormDetails();
            Assert.That(actualFormName.Trim(), Is.EqualTo(expectedFormName));
        }

        public async Task<string> GetFormNameFromFormDetails()
        {
            await GenericHelper.Click(_page, formDetailsButton);
            var formName = await _page.Locator(getFormName).InputValueAsync();
            return formName;
        }
        public async Task ClickImportJSONButton()
        {
            await GenericHelper.Click(_page, clickImportJSONButton);
        }

        public async Task<string> LinkIntroductoryvideos()
        {
            return await GenericHelper.GetText(_page, Introductoryvideos);
        }

        public async Task<string> LinkContacts()
        {
            return await GenericHelper.GetText(_page, Contacts);
        }

        public async Task<string> LinkWishList()
        {
            return await GenericHelper.GetText(_page, WishList);
        }

        public async Task<string> LinkSubmitBug()
        {
            return await GenericHelper.GetText(_page, SubmitBug);
        }

        public async Task<string> LinkCopyright()
        {
            return await GenericHelper.GetText(_page, Copyright);
        }

        public async Task<string> LabelContentDesc()
        {
            return await GenericHelper.GetText(_page, ContentDesc);
        }

        public async Task<string?> GetFooterLinkValue(IPage page, string name)
        {
            await GenericHelper.WaitForPageLoadAsync(page, LoadState.DOMContentLoaded, 3000);
            string attributevalue = await page.Locator("//a[contains(text(),'" + name + "')]").GetAttributeAsync("href") ?? "";
            await TabHelper.CloseTabAndReturnAsync(_page);
            return attributevalue;
        }

        public async Task SearchForForm(string formName)
        {
            await _page.Mouse.WheelAsync(0, 4000);
            await GenericHelper.Clear(_page, clickSearch);
            await GenericHelper.Fill(_page, clickSearch, formName);
            var searchInput = _page.Locator("//input[@type='search']");
            await searchInput.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await searchInput.ClickAsync();
            await _page.Keyboard.PressAsync("Enter");
        }

        public async Task SelectParentAccessTypeCheckbox()
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//div[@class='govuk-checkboxes__item']/input[1]").First);
            await _page.Locator("//div[@class='govuk-checkboxes__item']/input[1]").First.ClickAsync();
        }

        public async Task SelectDfESignInRadiobtn()
        {
            await GenericHelper.Click(_page, selectDfESigninRadioButton);
        }

        public async Task ClickSignOffLink()
        {
            await GenericHelper.Click(_page, SignOutbutton);
            await GenericHelper.Click(_page, SignOutConfirmation);
            await GenericHelper.Click(_page, SignOutConfirmationButton);
        }
        public async Task SelectPublicRadiobtn()
        {
            await GenericHelper.Click(_page, selectPublicRadioButton);
        }
        public async Task UploadCSVFile(string fileName)
        {
            string filePath = Path.Combine(projectDirectory, "TestData", fileName);
            await GenericHelper.ScrollToElementAsync(_page.Locator("//button[text()='Switch access']"));
            await _page.Locator("//input[@type='file']").SetInputFilesAsync(filePath);
        }

        public async Task ClickDeleteButton()
        {
            await GenericHelper.ScrollToElementAsync(_page, clickSwitchAccessButton);
            await GenericHelper.Click(_page, clickDeleteFormButton);
        }
        public async Task ClickOnSwitchAccessButton()
        {
            await GenericHelper.ScrollToElementAsync(_page, clickSwitchAccessButton);
            await GenericHelper.Click(_page, clickSwitchAccessButton);
        }

        public async Task ClickOnAccessType()
        {
            await _page.Locator("//input[@id='access-type-2']").ClickAsync();
        }

        public async Task FromDateToTodaysDate(string date)
        {
            string[] dat = date.Split("/");
            await _page.Locator("#modified-on-from-day").FillAsync(dat[0]);
            await _page.Locator("#modified-on-from-month").FillAsync(dat[1]);
            await _page.Locator("#modified-on-from-year").FillAsync(dat[2]);

            string todaysdate = DateTime.Now.ToString("d/M/yyyy");
            string[] Todays = todaysdate.Split("/");
            await _page.Locator("#modified-on-till-day").FillAsync(Todays[0]);
            await _page.Locator("#modified-on-till-month").FillAsync(Todays[1]);
            await _page.Locator("#modified-on-till-year").FillAsync(Todays[2]);
        }

        public async Task CheckTheResult()
        {
            await Click_Colleagueform_tab();
        }
        public async Task EnterNameInCreatedBy()
        {
            await _page.Locator("#created-by").FillAsync("joe");
            await _page.WaitForTimeoutAsync(2000);
            await _page.Locator("#created-by-0").ClickAsync();

        }
        public async Task<bool> CheckTheFormAccessType()
        {
            List<string> formstatus = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                formstatus.Add(await _page.Locator("//td[@id='add-child-forms-my-forms-table-td-cell-" + i + "-4']").TextContentAsync());
            }
            bool status = formstatus.All(x => x == "DFE SignIn");
            return status;
        }
        public async Task SelectStatus(string status)
        {
            await GenericHelper.ScrollToElementAsync(_page, Changestatus_Button);
            await _page.Locator("//input[@class='govuk-radios__input'][@value='" + status + "']").ClickAsync();
        }
        public async Task ClickConfirmation()
        {
            var checkbox = _page.Locator("//input[@name='check01']");
            var checkbox_pnc = _page.Locator("//input[@name='check1']");
            if (await checkbox.IsVisibleAsync() || await checkbox_pnc.IsVisibleAsync())
            {
                await GenericHelper.Click(_page, clickConfirmationCheckbox);
                await GenericHelper.Click(_page, clickSwitchAccessConfirmationButton);
            }
            else
            {
                await GenericHelper.Click(_page, clickSwitchAccessButton);
            }
        }

        public async Task ClickChangeStatusConfirmation()
        {
            await GenericHelper.Click(_page, clickChangeStatusConfirmation);
            await GenericHelper.Click(_page, clickChangeFormStatusButton);
        }

        public async Task ClickDeleteFormConfirmation()
        {
            await GenericHelper.Click(_page, clickDeleteFormConfirmation);
            await GenericHelper.Click(_page, clickDeleteFormButton);
        }

        public async Task ClickDeleteFormConfirmationForPublishedForm()
        {
            await GenericHelper.Click(_page, clickDeleteFormConfirmation);
            Assert.That(await _page.Locator("(//button[contains(text(),'Delete form')])[2]").IsDisabledAsync(), Is.True, "Delete form button should be disabled after selecting the confirmation checkbox.");
        }

        public async Task DFESigninCheckboxClick()
        {
            await GenericHelper.Click(_page, DFESigninCheckbox);
        }

        public async Task UserSelectTheForm(string formName)
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var element = _page.Locator("//tr[td[3]/div/span[contains(text(),'" + formName + "')]]//td[2]");
            Thread.Sleep(3000);
            await element.ClickAsync();
        }

        public async Task<string> GetFormName()
        {
            string formname = await _page.Locator("//tr[@class='govuk-table__row']/td[3]").First.InnerTextAsync();
            return formname;
        }

        public async Task<string> VerifyFirstPage()
        {
            return await GenericHelper.GetText(_page, "//h1[contains(text(),'First page')]");
        }
        public async Task<string?> Verifyformstatus(string formName, string formStatus)
        {

            return await _page.Locator("//span[@title='" + formName + "']/following::td[@id='add-child-forms-my-forms-table-td-cell-0-3']/div").TextContentAsync();
        }

        public async Task<Boolean> Enable_testlink(string formName)
        {
            return await _page.Locator("((//span[text()='" + formName + "'])[1]/following::a[text()='Test'])[1]").IsVisibleAsync();
        }
        public async Task Click_testlink(string formName)
        {
            await _page.Locator("((//span[text()='" + formName + "'])[1]/following::a[text()='Test'])[1]").ClickAsync();
        }

        public async Task Click_Prodlink(string formName)
        {
            await _page.Locator("((//span[text()='" + formName + "'])[1]/following::a[text()='Prod'])[1]").ClickAsync();
        }

        public async Task<Boolean> enabled_prodlink(string formName)
        {
            return await _page.Locator("(//div[@class='table-cell'])[7]/a[2]").IsVisibleAsync();
        }

        public async Task<Boolean> Notenabled_prodlink(string formName)
        {
            return await _page.Locator("(//div[@class='table-cell'])[7]/a[2]").IsHiddenAsync();
        }
        public async Task<Boolean> CheckTestLink(string formName, string Environment)
        {
            Boolean flag;
            string url = await _page.Locator("((//span[text()='" + formName + "'])[1]/following::a[text()='Test'])[1]").GetAttributeAsync("href");
            if (url.Contains("https://uat." + Environment + ".digital-forms.education.gov.u"))
            {
                return true;
            }
            else { return false; }
        }
        public async Task EnterUserNamePassword(string dFEUserName)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(projectDirectory, "appsettings.json"))
                .AddEnvironmentVariables()
                .Build();
            var base64Bytes = System.Convert.FromBase64String(config["PWD"].Trim());
            string pwd = System.Text.Encoding.UTF8.GetString(base64Bytes);
            await GenericHelper.Fill(_page, UserNameEditBox, dFEUserName);
            await GenericHelper.Click(_page, nextButton);
            await GenericHelper.Fill(_page, PasswordEditBox, pwd);
            await GenericHelper.Click(_page, Signinbutton);
        }

        public async Task ChooseDFEandOrg(string dfesign, string org)
        {
            if (dfesign.Trim().Equals("UKPRN"))
            {
                await EnterCode(org);
            }
            else
            {
                await _page.Locator("//span[contains(text(),'\" + org + \"')]/parent::label/parent::div/input").ClickAsync();
            }
            await GenericHelper.scrolldowntobottom(_page);
            await _page.Locator("//input[@type='submit']").ClickAsync();

        }
        public async Task EnterCode(string code)
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("(//span[contains(text(),'" + code + "')]/parent::label)[1]/parent::div/input"));
            await _page.Locator("(//span[contains(text(),'" + code + "')]/parent::label)[1]/parent::div/input").ClickAsync();
        }


        public async Task<string> GetNoItemsfound()
        {
            return await GenericHelper.GetText(_page, Noitemsfound_Label);
        }

        public async Task ClickSearchIcon(string formName)
        {
            await _page.Locator("((//span[text()='" + formName + "'])[1]/following::a[text()='Test'])[1]").ClickAsync();
        }

        public async Task ClickSearchIcon()
        {
            var element = _page.Locator("[data-testid='dashboard-show-filters']");
            await element.ScrollIntoViewIfNeededAsync();
            await GenericHelper.Click(_page, Search_Icon);
            await GenericHelper.Click(_page, search);
        }

        public async Task ClickCreateFormButton()
        {
            await GenericHelper.Click(_page, CreateFormButton);
        }

        public async Task EnterFormName(string formName)
        {
            await GenericHelper.Fill(_page, enterFormName, formName);
        }

        public async Task EnterFormName()
        {
            var formName = "TestForm" + DateTime.Now.ToString("s", CultureInfo.CreateSpecificCulture("en-US"));
            formName = Regex.Replace(formName, @"[):;.,'=-]", "");
            await GenericHelper.Fill(_page, enterFormName, formName);
            //Storing form name value in file.txt
            string filePath = projectDirectory.ToString() + "\\TestData\\file.txt";
            File.WriteAllText(filePath, formName);
        }

        public async Task EnterExistingFormName()
        {
            var formName = File.ReadLines(filePath).First();
            await GenericHelper.Fill(_page, enterFormName, formName);
        }
        public async Task SelectFormAndClickEditButton()
        {
            var formName = File.ReadLines(filePath).First();
            //await UserSelectTheForm(formName);
            await Enter_Name(formName);

            await Click_Editform();
        }
        public async Task CreateFormWithAPI()
        {
            string Environment = config["Environment"].Trim();

            var faker = new Faker();
            string id = faker.Random.AlphaNumeric(10);
            var formName = "TestForm" + DateTime.Now.ToString("s", CultureInfo.CreateSpecificCulture("en-US"));
            formName = Regex.Replace(formName, @"[):;.,'=-]", "");
            string dateTime = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
            // Create Playwright
            using var playwright = await Playwright.CreateAsync();

            // Create API Context
            var apiContext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://"+ Environment+".externalapi.digital-forms.education.gov.uk"
                });
            // Read JSON template
            string projectRoot = Path.GetFullPath(
Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            string jsonPath = Path.Combine(
                projectRoot,
                "TestData",
                "PostAPIAddConfigurationBody.json");

            Console.WriteLine($"JSON Path = {jsonPath}");
            string requestBody = File.ReadAllText(jsonPath);

            requestBody = requestBody
                .Replace("$ID$", id)
                .Replace("$ID$", id)
                .Replace("$FORMNAME$", formName)
                .Replace("$FORMNAME$", formName)
                .Replace("$DATETIME$", dateTime);
            // POST API
            var response = await apiContext.PostAsync(
                "https://"+ Environment+".externalapi.digital-forms.education.gov.uk/api/addConfiguration",
                new APIRequestContextOptions
                {
                    Data = requestBody,
                    Headers = new Dictionary<string, string>
                    {
                        ["Content-Type"] = "application/json"
                    }
                });
            string responseText = await response.TextAsync();
            Assert.That(response.Status, Is.EqualTo(200));
            string responseBody = await response.TextAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
            string formname = jsonResponse.displayName;
            string filePath = projectDirectory.ToString() + "\\TestData\\file.txt";
            File.WriteAllLines(filePath, new[] { formName, id });
            await _page.ReloadAsync();
        }
        public async Task DeleteFormWithAPI()
        {
            string Environment = config["Environment"].Trim();

            var id = File.ReadLines(filePath).Last();
            using var playwright = await Playwright.CreateAsync();
            var apiContext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://"+ Environment+".externalapi.digital-forms.education.gov.uk"
                });

            var response = await apiContext.DeleteAsync(
                $"/api/deleteConfiguration/{id}");

            Assert.That(response.Status, Is.EqualTo(200));
        }
        public async Task ClickNextButton()
        {
            await GenericHelper.Click(_page, clickNextButton);
        }
        public async Task ClickOnSearchButton()
        {
            await GenericHelper.Click(_page, Search_Icon);
            await _page.Locator("//a[@id='filter-close-link']").ClickAsync();

        }
        public async Task CheckFormStatus(string formName, string status)
        {
            var formStatus = await _page.Locator("//tr[td[3][contains(., '" + formName + "')]]//td[5]//div").First.TextContentAsync();
            Assert.That(formStatus.Trim(), Is.EqualTo(status));
        }
        public async Task Enter_Name(string formname)
        {
            await GenericHelper.WaitForPageLoadAsync(_page);
            await GenericHelper.ScrollToElementAsync(_page, Search_Editbox);
            await GenericHelper.Fill(_page, Search_Editbox, formname);
            await _page.WaitForTimeoutAsync(5000);
            await GenericHelper.Click(_page, Search_Icon);
            await _page.WaitForTimeoutAsync(2000);
            await _page.EvaluateAsync("window.scrollBy(0, document.body.scrollHeight)");
            bool isVisible = await _page.Locator("//span[@title='" + formname + "']/preceding::input[@name='select-form']").IsVisibleAsync();
            if (isVisible)
            {
                await _page.ClickAsync("//span[@title='" + formname + "']/preceding::input[@name='select-form']");
            }
            else
            {
                await GenericHelper.Click(_page, Colleagueform_tab);
                if (await _page.Locator("//span[@title='" + formname + "']/preceding::input[@name='select-form']").IsVisibleAsync())
                {
                    await _page.ClickAsync("//span[@title='" + formname + "']/preceding::input[@name='select-form']");
                }
                else if (await _page.Locator("//p[text()='No items found']").IsVisibleAsync())
                {
                }
            }
        }
    }
}
