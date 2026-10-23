
using Newtonsoft.Json.Linq;
using DigitalForm_AutomationSuite.Helper;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class FormDesignerPage
    {
        private IPage _page;
        private readonly GenericHelper _GenericHelper;
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public FormDesignerPage(IPage page)
        {
            _page = page;
        }

        public string[] SummaryPageEdit = new[]
        {
            "//button[text()='Edit page']/ancestor::div[@id='/summary']//button[@title='Edit page']"
        };
        public string[] savePageButton = new[]
        {
            "//button[.='Save page']"
        };
        public string[] dsiComponentLink = new[]
        {
            "//a[.='DSI data access']"
        };
        public string[] enterTitle = new[]
        {
            "//input[@name='title']"
        };
        public string[] saveButton = new[]
        {
            "//button[.='Save']"
        };
        public string[] menuConditionsButton = new[]
        {
            "//button[.='Conditions']"
        };
        public string[] addConditionButton = new[]
        {
            "//a[.='Add condition']"
        };
        public string[] conditionName = new[]
        {
            "//input[@name='cond-name']"
        };
        public string[] selectComponent = new[]
        {
            "//select[@name='cond-field']"
        };
        public string[] selectConditionOperator = new[]
        {
            "//select[@name='cond-operator']"
        };
        public string[] selectCustomTextRadiobutton = new[]{
            "//input[@id='custom-prefix']"
        };
        public string[] enterCustomTextValue = new[]{
            "//input[@id='cond-value']"
        };
        public string[] addLink = new[]{
            "//button[@id='save-condition']"
        };
        public string[] saveConditionButton = new[]{
            "//button[@id='save-inline-conditions']"
        };
        public string[] closeLink = new[]{
            "//a[@title='Close']"
        };
        public string[] prefix = new[]{
            "//div[@class='govuk-input__prefix']"
        };
        public string[] import = new[] { "[title='Add data set']" };
        public string[] sectionsButton = new[] { "//button[@data-testid='menu-sections']" };
        public string[] listsButton = new[] { "//button[@data-testid='menu-lists']" };
        public string[] outputsButton = new[] { "//button[@data-testid='menu-outputs']" };
        public string[] outputtitle = new[] { "//input[@name='output-title']" };
        public string[] outputTemplate = new[] { "//input[@name='template-id']" };
        public string[] outputAPIKey = new[] { "//input[@name='api-key']" };
        public string[] addOutputLink = new[] { "//a[text()='Add output']" };
        public string[] addPageButton = new[] { "//button[@data-testid='menu-page']" };
        public string[] addLinkButton = new[] { "//button[@data-testid='menu-links']" };
        public string[] pageTitle = new[] { "//input[@name='title']" };
        public string[] saveAndContinueButton = new[] { "//button[@id='submit']" };
        public string[] pageHeading = new[] { "//div/h1[@class='govuk-heading-xl']" };
        public string[] deleteButton = new[] { "//button[text()='Delete']" };
        public string[] importDatasetButton = new[] { "//button[@data-testid='menu-import-data']" };
        public string[] importDataset = new[] { "//button[@id='add-data-set']" };
        public string[] importDataFileTitle = new[] { "//input[@id='file-title']" };
        public string[] summaryBehaviourButton = new[] { "//button[@data-testid='menu-summary-behaviour']" };
        public string[] documentsButton = new[] { "//button[@data-testid='menu-document']" };
        public string[] clickImportDocument = new[] { "//button[@title='Add data set']" };
        public string[] editDocument = new[] { "//button[@id='edit-data-set']" };
        public string[] deleteDocument = new[] { "//button[@id='delete-data set']" };
        public string[] deleteConfirmCheckBox = new[] { "//input[@name='delete-confirm']" };
        public string[] documentTitle = new[] { "//input[@id='document-title']" };
        public string[] skipSummaryCheckbox = new[] { "//input[@type='checkbox']" };
        public string[] addSectionButton = new[] { "//button[@name='add-section-button']" };
        public string[] addListButton = new[] { "//button[text()='Add List']" };
        public string[] addlistButton = new[] { "//button[text()='Add list']" };
        public string[] saveListButton = new[] { "//button[text()='Save list']" };
        public string[] editListButton = new[] { "//button[text()='Edit list']" };
        public string[] deleteListButton = new[] { "//button[text()='Delete list']" };
        public string[] addSectionTitle = new[] { "//input[@name='section-title']" };
        public string[] listTitle = new[] { "//input[@id='list-title']" };
        public string[] backButton = new[] { "//a[text()='Back']" };
        public string[] secondPageEditPageLink = new[] { "//h3[text()='Second page']/ancestor::div[1]/following-sibling::div[2]/button[1]" };
        public string[] clickDuplicatePageButton = new[] { "//button[text()='Duplicate page']" };
        public string[] deletePageButton = new[] { "//button[text()='Delete page']" };
        public string selectSectionDropDown = "//select[@id='page-section']";
        public string listDropDown = "//select[@id='list-datasets']";
        public string sectionNameOnPage = "//div[@class='page__heading']/h3/span";
        public string[] radioSelect = new[] { "//input[@type='radio']" };
        public string[] editSectionButton = new[] { "//button[text()='Edit section']" };
        public string[] deleteSectionButton = new[] { "//button[text()='Delete section']" };
        public string[] deleteSectionConfirmation = new[] { "//input[@type='checkbox']" };
        public string[] deleteSectionConfirmationButton = new[] { "//button[text()='Delete Section']" };
        public string[] CreateComponent_button = new[]
        {
            "(//button[@title='Create component'])[2]"
        };
        public string[] save = new[]{
            "//button[text()='Save']"
        };
        public string[] row = new[]{
            "govuk-select dataset-dropdown"
        };
        public string[] col = new[]{
            "design-data-set-dropdown-row"
        };
        public string[] design = new[]{
            "[id='imported-dataset-select']"
        };
        public string[] identifier = new[]{
            "[id='key-identifier-select']"
        };
        public string[] header_value = new[]{
            "#design-table-input-select-radio-select"
        };
        public string[] table_design = new[]{
            "[id='table-dropdown-dataset']"
        };

        public string[] tab_select = new[] {
        "[id='tab-dropdown-section']" };

        public async Task UploadTheFileInImportDataset(string file)
        {
            await _page.GetByTestId("add-data-set").ClickAsync();
            await _page.Locator("[id='file-title']").FillAsync("table");
            await GenericHelper.UploadFileAsync(_page, "//input[@id='file-upload-1']", file);
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task UploadTheFileInImportDatasetcond(string file)
        {
            await _page.GetByTestId("add-data-set").ClickAsync();
            await _page.Locator("[id='file-title']").FillAsync("condition1");
            await GenericHelper.UploadFileAsync(_page, "//input[@id='file-upload-1']", file);
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task DeleteInCondition(string condition)
        {
            await _page.Locator("//a[text()='Condition1']").ClickAsync();
        }

        public async Task UploadTheFileInImportDatasetNew(string file)
        {
            await _page.GetByTestId("add-data-set").ClickAsync();
            await _page.Locator("[id='file-title']").FillAsync("table2");
            await GenericHelper.UploadFileAsync(_page, "//input[@id='file-upload-1']", file);
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }


        public async Task UploadTheFileInImportDatasetEdit(string file)
        {
            await _page.Locator("(//input[@type='radio'])[2]").ClickAsync();
            await _page.Locator("//button[text()='Edit data set']").ClickAsync();
            await _page.Locator("//input[@id='file-title']").ClearAsync();
            await _page.Locator("//input[@id='file-title']").FillAsync("editednew");
            await _page.Locator("//input[@id='delete-confirm-0']").ClickAsync();
            await _page.Locator("//button[@type='submit']").ClickAsync();
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task AddConditionValueimport(string displayname, string name, string condition1, string value)
        {
            await _page.GetByTestId("add-condition-link").ClickAsync();
            await _page.Locator("//input[@id='cond-name']").FillAsync(displayname);
            await _page.Locator("//select[@id='cond-field']").SelectOptionAsync("Number Component");
            await _page.Locator("//select[@id='cond-operator']").SelectOptionAsync("is");
            await _page.Locator("//input[@id='select-prefix']").ClickAsync();
            await _page.Locator("//select[@id='cond-value']").SelectOptionAsync("condition1");
            await _page.Locator("//button[@id='save-condition']").ClickAsync();
            await _page.Locator("//button[text()='Save']").ClickAsync();
            await _page.WaitForTimeoutAsync(20000);
            await GenericHelper.Click(_page, closeLink);
        }


        public async Task AddConditionValue(string displayname, string name, string condition1, string value)
        {
            await _page.GetByTestId("add-condition-link").ClickAsync();
            await _page.Locator("//input[@id='cond-name']").FillAsync(displayname);
            await _page.Locator("//select[@id='cond-field']").SelectOptionAsync("Number Component");
            await _page.Locator("//select[@id='cond-operator']").SelectOptionAsync("is");
            await _page.Locator("//input[@id='cond-value']").FillAsync("100");
            await _page.Locator("//button[@id='save-condition']").ClickAsync();
            await _page.Locator("//button[text()='Save']").ClickAsync();
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task Deleteimportdataset(string file)
        {
            await _page.Locator("(//input[@type='radio'])[2]").ClickAsync();
            await _page.Locator("//input[@id='delete-confirm-0']").ClickAsync();
            await _page.Locator("//button[@type='submit']").ClickAsync();
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task DesignDataSet()
        {
            await _page.GetByTestId("add-data-set").ClickAsync();
            await _page.Locator("[id='design-data-set-name']").FillAsync("table");
            await _page.Locator("//select[@class='govuk-select dataset-dropdown']").SelectOptionAsync("2");
            await _page.Locator("//input[@id='design-data-set-dropdown-row']").FillAsync("2");
            await _page.Locator("//button[text()='Generate structure']").ClickAsync();
            await GenericHelper.SelectByText(_page, design, "table");
            for (int i = 1; i < 5; i++)
            {
                await _page.Locator("(//div[@data-testid='design-dynamic-table-cell'])[" + i + "]").ClickAsync();
                await _page.Locator("[id='design-table-input-select-radio']").ClickAsync();
                await _page.Locator("#design-table-input-select-radio-select").SelectOptionAsync(new SelectOptionValue { Index = i });
            }
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }

        public async Task DesignDataSetNew()
        {
            await _page.GetByTestId("add-data-set").ClickAsync();
            await _page.Locator("[id='design-data-set-name']").FillAsync("table2");
            await _page.Locator("//select[@class='govuk-select dataset-dropdown']").SelectOptionAsync("2");
            await _page.Locator("//input[@id='design-data-set-dropdown-row']").FillAsync("2");
            await _page.Locator("//button[text()='Generate structure']").ClickAsync();
            await GenericHelper.SelectByText(_page, design, "table");
            await GenericHelper.SelectByText(_page, identifier, "UKPRN");
            for (int i = 1; i < 5; i++)
            {
                await _page.Locator("(//div[@data-testid='design-dynamic-table-cell'])[" + i + "]").ClickAsync();
                await _page.Locator("[id='design-table-input-select-radio']").ClickAsync();
                await _page.Locator("#design-table-input-select-radio-select").SelectOptionAsync(new SelectOptionValue { Index = i });
            }
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task DesignDataSetupdated()
        {
            await _page.Locator("(//input[@type='radio'])[1]").ClickAsync();
            await _page.Locator("//button[text()='Edit data set']").ClickAsync();
            await _page.Locator("[id='design-data-set-name']").FillAsync("tableedited");
            await _page.Locator("//select[@class='govuk-select dataset-dropdown']").SelectOptionAsync("2");
            await _page.Locator("//input[@id='design-data-set-dropdown-row']").FillAsync("2");
            await GenericHelper.SelectByText(_page, design, "table");
            await GenericHelper.SelectByText(_page, identifier, "UKPRN");
            for (int i = 1; i < 5; i++)
            {
                await _page.Locator("(//div[@data-testid='design-dynamic-table-cell'])[" + i + "]").ClickAsync();
                await _page.Locator("[id='design-table-input-select-radio']").ClickAsync();
                await _page.Locator("#design-table-input-select-radio-select").SelectOptionAsync
                        (new SelectOptionValue { Index = i });

            }
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task ClickCloseLink()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await GenericHelper.Click(_page, closeLink);
        }
        public async Task DeleteDataSet()
        {
            await _page.Locator("(//input[@type='radio'])[1]").ClickAsync();
            await _page.Locator("//input[@id='delete-confirm-0']").ClickAsync();
            await _page.Locator("//button[@id='delete-data set']").ClickAsync();


        }
        public async Task selecttab()
        {
            await GenericHelper.SelectByText(_page, tab_select, "1");
            await _page.Locator("//button[text()='Generate structure']").ClickAsync();
            await _page.Locator("[data-testid='design-dynamic-table-cell']").ClickAsync();
            await _page.Locator("[data-testid='input-tab-label']").FillAsync("label");
            await _page.Locator("[data-testid='input-tab-header']").FillAsync("header");
            await _page.Locator("//select[@name='imported-dataset-select']").SelectOptionAsync("table");

        }
    
        public async Task SkipSummry()
        {
            await GenericHelper.Click(_page, summaryBehaviourButton);
            await GenericHelper.Click(_page, skipSummaryCheckbox);
            await GenericHelper.Click(_page, saveButton);
        }

        public async Task ClickDocuments()
        {
            await GenericHelper.Click(_page, documentsButton);
            await GenericHelper.Click(_page, clickImportDocument);
            await GenericHelper.Fill(_page, documentTitle, "Document");
        }

        public async Task ClickAndEditDocuments()
        {
            await GenericHelper.Click(_page, documentsButton);
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, editDocument);
        }

        public async Task ClickDeleteDocumentButton()
        {
            await GenericHelper.Click(_page, documentsButton);
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, deleteConfirmCheckBox);
            await GenericHelper.Click(_page, deleteDocument);
        }

        public async Task VerifyDocumentDeleted()
        {
            Assert.That(await _page.Locator("//input[@type='radio']").CountAsync(), Is.EqualTo(0));
        }
        public async Task UserSelectTheDesignDataSet()
        {
            await GenericHelper.SelectByText(_page, table_design, "table");
        }
        public async Task EnterAddNewList(string ListTitle, string ListValue)
        {
            await _page.Locator("[data-testid='menu-lists']").ClickAsync();
            await _page.Locator("[data-testid='add-new-list-button']").ClickAsync();
            await _page.Locator("#list-title").FillAsync(ListTitle);
            string[] subs = ListValue.Split(',');
            int a = subs.Count();
            for (int i = 0; i < a; i++)
            {
                await _page.Locator("#add-list-item").ClickAsync();
                await _page.Locator("[id*='list-item-title']+input").FillAsync(subs[i]);
                await _page.Locator("[id*='list-item-value']+input").FillAsync(subs[i]);
                await _page.Locator(".govuk-button").ClickAsync();
            }
            await _page.Locator("//button[text()='Add list']").ClickAsync();
            await _page.Locator(".govuk-back-link").ClickAsync();
        }

        public async Task ImportFile(string fileName)
        {
            string filePath = Path.Combine(projectDirectory, "TestData", fileName);
            await _page.Locator("//div[@class='file-upload-container']/following-sibling::input[@type='file']").SetInputFilesAsync(filePath);
            await ClickSave();
            Thread.Sleep(4000);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await ClickCloseLink();
        }

        public async Task EnterTitle(string Title)
        {
            await _page.Locator("[name='title']").FillAsync(Title);
        }

        public async Task SelectTheList(string list, string type)
        {
            await _page.Locator("#field-options-list").SelectOptionAsync(list);
            if (type.Equals("Bullets"))
            {
                if (await _page.Locator("(//label[@class='govuk-label govuk-radios__label'])[1]").IsVisibleAsync())
                {
                    await _page.Locator("(//label[@class='govuk-label govuk-radios__label'])[1]").ClickAsync();
                }
            }
            else if (type.Equals("Numbered items"))
            {
                if (await _page.Locator("(//input[@class='govuk-radios__input'])[2]").IsVisibleAsync())
                {
                    await _page.Locator("(//input[@class='govuk-radios__input'])[2]").ClickAsync();
                }
            }
            else if (type.Equals("Links"))
            {
                if (await _page.Locator("(//input[@class='govuk-radios__input'])[3]").IsVisibleAsync())
                {
                    await _page.Locator("(//input[@class='govuk-radios__input'])[3]").ClickAsync();
                }
            }

        }

        public async Task AddPrefixValuePound()
        {
            await _page.GetByTestId("add-prefix").ClickAsync();
            await _page.Locator("//input[@id='select-prefix']").ClickAsync();
            await _page.Locator("//select[@id='currency-list']").SelectOptionAsync
                            (new SelectOptionValue { Index = 1 });
        }


        public async Task AddSuffixValue()
        {
            await _page.Locator("//input[@id='add-suffix']").ClickAsync();
            await _page.Locator("//input[@id='custom-suffix']").FillAsync("per min");
        }
        public async Task AddPrecisionValue()
        {
            await _page.Locator("//span[text()='Additional settings']").ClickAsync();
            await _page.Locator("//input[@id='field-schema-precision']").FillAsync("2");
        }
        public async Task EnableOptionalInComponen()
        {
            await _page.Locator("#field-options-required").ClickAsync();
        }
        public async Task addCalculationInDesigner()
        {
            await _page.Locator("//button[text()='Calculation builder']").ClickAsync();
            await _page.Locator("//button[text()='Add calculation']").ClickAsync();
            await _page.Locator("//input[@name='new-calculation-title']").FillAsync("calc1");
            await _page.Locator("(//input[@name='input-autocomplete'])[1]").FillAsync("Second page");
            Thread.Sleep(2000);
            await _page.WaitForTimeoutAsync(2000);
            await _page.Locator("//li[@class='autocomplete__option']").ClickAsync();
            await _page.Locator("//input[@name='new-calculation-title']").FillAsync("calc1");
            await _page.Locator("//input[@name='select-component']").ClickAsync();
            await _page.Locator("(//button[text()='Add to compute block'])[1]").ClickAsync();
            await _page.Locator("//button[text()='Add number input box']").ClickAsync();
            await _page.Locator("(//input[@type='text'])[4]").ClickAsync();
            await _page.Locator("(//input[@type='text'])[4]").FillAsync("+");
            await _page.Locator("(//input[@type='text'])[5]").ClickAsync();
            await _page.Locator("(//input[@type='text'])[5]").FillAsync("100");
            await _page.Locator("//button[text()='Save Calculation']").ClickAsync();
            await _page.Locator("//a[text()='Back']").ClickAsync();
        }

        public async Task<bool> CheckTheFormStatus()
        {
            List<string> formstatus = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                formstatus.Add(await _page.Locator("//td[@id='add-child-forms-my-forms-table-td-cell-" + i + "-3']").TextContentAsync());
            }
            bool status = formstatus.All(x => x == "In development");
            return status;
        }
        public async Task selectcalc()
        {
            await _page.Locator("(//input[@name='input-autocomplete'])[1]").ClickAsync();
            await _page.Locator("(//input[@name='input-autocomplete'])[1]").FillAsync("calc1");
            Thread.Sleep(2000);
            await _page.WaitForTimeoutAsync(2000);
            await _page.Locator("//li[@class='autocomplete__option']").ClickAsync();
        }

        public async Task EnterDate()
        {
            await _page.Locator("//input[@id='add-date']").ClickAsync();
            await _page.Locator("//input[@id='add-time']").ClickAsync();
        }
        public async Task UserSelectTheFileInDropdow(string value)
        {
            await _page.Locator("[name='selectedDocument']").SelectOptionAsync(value);
        }

        public async Task SelectTheSchema()
        {
            await _page.Locator("//select[@name='selectedColumnHeaderValue']").SelectOptionAsync(new SelectOptionValue { Index = 1 });
            await _page.Locator("//select[@name='column-type']").SelectOptionAsync(new SelectOptionValue { Index = 2 });
            await _page.Locator("//input[@type='number']").FillAsync("50");
            await _page.Locator("//button[text()='Add']").ClickAsync();
            await _page.Locator("//select[@name='selectedColumnHeaderValue']").SelectOptionAsync(new SelectOptionValue { Index = 2 });
            await _page.Locator("//select[@name='column-type']").SelectOptionAsync(new SelectOptionValue { Index = 2 });
            await _page.Locator("//input[@type='number']").FillAsync("50");
            await _page.Locator("//button[text()='Add']").ClickAsync();
        }

        public async Task UploadTheFileAndValidate(string file)
        {
            await GenericHelper.UploadFileAsync(_page, "//input[@class='govuk-file-upload']", file);
            await _page.Locator("//button[contains(text(),'Validate Your File')]").ClickAsync();
        }
        public async Task UploadTheFile(IPage page, string file)
        {
            await GenericHelper.Click(_page, import);
            await _page.Locator("#document-title").FillAsync("file");
            await GenericHelper.UploadFileAsync(_page, "//input[@id='document-upload']", file);
            await ClickSave();
            Thread.Sleep(2000);
            await _page.WaitForTimeoutAsync(2000);
            await _page.Locator("//a[text()='Close']").ClickAsync();
        }

        public async Task ClickOnMenu(string menu)
        {
            await _page.Locator("//button[text()='" + menu + "']").ClickAsync();
        }

        public async Task SelectInAutocomplete(string item)
        {
            await _page.WaitForLoadStateAsync();
            Thread.Sleep(3000);
            try
            {
                await _page.Locator("//input[@role='combobox']").FillAsync(item);
            }
            catch (Exception ex) { }
        }
        public async Task Clean_component()
        {
            ILocator elements = _page.Locator(".component-item");

            int count = await elements.CountAsync();

            for (int i = count - 1; i >= 0; i--)
            {
                var element = elements.Nth(i);
                await element.ClickAsync();
                await _page.Locator("//input[@name='delete-confirm']").ClickAsync();
                await _page.Locator("//button[text()='Delete']").ClickAsync();

                try
                {
                    bool deletepopup = await _page.Locator("//button[text()='Delete component']").IsVisibleAsync();
                    if (deletepopup)
                    {
                        await _page.Locator("#confirm").ClickAsync();
                        await _page.Locator("//button[text()='Delete component']").ClickAsync();
                    }
                }
                catch (Exception e) { }
            }
        }
        public async Task ClickSectionsButton()
        {
            await GenericHelper.Click(_page, sectionsButton);
        }
        public async Task ClickListsButton()
        {
            await GenericHelper.Click(_page, listsButton);
        }

        public async Task AddListFile(string title, string file)
        {
            await GenericHelper.Click(_page, importDatasetButton);
            await GenericHelper.Click(_page, importDataset);
            await GenericHelper.Fill(_page, importDataFileTitle, title);
            await GenericHelper.UploadFileAsync(_page, "//input[@id='file-upload-1']", file);
            await GenericHelper.Click(_page, save);
            await GenericHelper.Click(_page, closeLink);
        }

        public async Task AddList(string ListTitle)
        {
            await GenericHelper.Click(_page, addListButton);
            await GenericHelper.Fill(_page, listTitle, ListTitle);
            await _page.Locator(listDropDown).SelectOptionAsync(new SelectOptionValue { Label = ListTitle });
            await GenericHelper.Click(_page, addlistButton);
            string actualText = await _page.Locator("//td[2]/p/span").TextContentAsync();
            Assert.That(actualText?.Trim(), Is.EqualTo(ListTitle));
        }

        public async Task EditList(string ListTitle)
        {
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, editListButton);
            await GenericHelper.Fill(_page, listTitle, ListTitle);
            await _page.Locator(listDropDown).SelectOptionAsync(new SelectOptionValue { Label = ListTitle });
            await GenericHelper.Click(_page, saveListButton);
            string actualText = await _page.Locator("//td[2]/p/span").TextContentAsync();
            Assert.That(actualText?.Trim(), Is.EqualTo(ListTitle));
        }
        public async Task RemoveListItem()
        {
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, editListButton);
            await _page.Locator("//div[text()='Remove']").First.ClickAsync();
            await _page.Locator("//input[@id='confirm']").ClickAsync();
            await _page.Locator("//button[text()='Remove list item']").ClickAsync();
            await GenericHelper.Click(_page, saveListButton);
        }

        public async Task DeleteList()
        {
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, deleteListButton);
            await _page.Locator("//input[@name='delete-confirm']").ClickAsync();
            await _page.Locator("//button[text()='Delete list']").First.ClickAsync();
        }
        public async Task AddSection(string sectionName)
        {
            await GenericHelper.Click(_page, addSectionButton);
            await GenericHelper.Fill(_page, addSectionTitle, sectionName);
            await GenericHelper.Click(_page, addSectionButton);
            string actualText = await _page.Locator("//td[2]/div[@class='table-cell']/span").TextContentAsync();
            Assert.That(actualText?.Trim(), Is.EqualTo(sectionName));
        }

        public async Task EditSection(string sectionName)
        {
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, editSectionButton);
            await GenericHelper.Fill(_page, addSectionTitle, sectionName + "_Edited");
            await GenericHelper.Click(_page, addSectionButton);
            string actualText = await _page.Locator("//td[2]/div[@class='table-cell']/span").TextContentAsync();
            Assert.That(actualText?.Trim(), Is.EqualTo(sectionName + "_Edited"));
        }

        public async Task DeleteSection(string sectionName)
        {
            await GenericHelper.Click(_page, radioSelect);
            await GenericHelper.Click(_page, deleteSectionButton);
            await GenericHelper.Click(_page, deleteSectionConfirmation);
            await GenericHelper.Click(_page, deleteSectionConfirmationButton);
            var isVisible = await _page.GetByText(sectionName).IsVisibleAsync();
            Assert.That(isVisible, Is.False);


        }
        public async Task ClickBackButton()
        {
            await GenericHelper.Click(_page, backButton);
        }

        public async Task AddSectionToPage(string sectionName)
        {
            await GenericHelper.Click(_page, secondPageEditPageLink);
            await _page.Locator(selectSectionDropDown).SelectOptionAsync(new SelectOptionValue { Label = sectionName });
            await ClickSaveButton();
        }

        public async Task VerifyTheAddedSection(string sectionName)
        {
            string actualText = await _page.Locator(sectionNameOnPage).TextContentAsync();
            Assert.That(actualText?.Trim(), Is.EqualTo(sectionName));
        }
        public async Task AddPage(string title)
        {
            await GenericHelper.Click(_page, addPageButton);
            await _page.Locator("//select[@id='link-from']").SelectOptionAsync(new SelectOptionValue { Label = "/second-page" });
            await GenericHelper.Fill(_page, pageTitle, title);
            await GenericHelper.Click(_page, saveButton);
            await GenericHelper.Click(_page, addLinkButton);
            await _page.Locator("//select[@id='link-source']").SelectOptionAsync(new SelectOptionValue { Label = title });
            await _page.Locator("//select[@id='link-target']").SelectOptionAsync(new SelectOptionValue { Label = "Summary" });
            await GenericHelper.Click(_page, saveButton);
            var locator = _page.Locator(
                "//div[5]//*[name()='svg']//*[name()='g'][2]/*[name()='polyline'][1]");
            await locator.FocusAsync();
            await locator.PressAsync("Enter");
            _page.Dialog += async (_, dialog) =>
            {
                Console.WriteLine(dialog.Message);
                await dialog.AcceptAsync();
            };
            await GenericHelper.Click(_page, deleteButton);
        }

        public async Task editSecondPageTitle(string title)
        {
            await GenericHelper.Click(_page, secondPageEditPageLink);
            await GenericHelper.Fill(_page, pageTitle, title);
            await GenericHelper.Click(_page, savePageButton);
        }

        public async Task ValidatePageAddAndEdit(string newPage, string editedPage)
        {
            _page = await TabHelper.SwitchToNewTabAsync(_page, async () =>
            {
                await _page.Locator("(//a[text()='Preview'])[1]").ClickAsync();
            });
            await GenericHelper.Click(_page, saveAndContinueButton);
            var actualHeading = await GenericHelper.TextContent(_page, pageHeading);
            Assert.That(actualHeading?.Trim(),
                Is.EqualTo(editedPage),
                $"Expected heading '{editedPage}' but found '{actualHeading}'.");
            await GenericHelper.Click(_page, saveAndContinueButton);
            var actualHeading_two = await GenericHelper.TextContent(_page, pageHeading);
            Assert.That(actualHeading_two?.Trim(),
                Is.EqualTo(newPage),
                $"Expected heading '{newPage}' but found '{actualHeading_two}'.");
        }

        public async Task AddOutput(string outputTitle)
        {
            await GenericHelper.Click(_page, outputsButton);
            await GenericHelper.Click(_page, addOutputLink);
            await GenericHelper.Fill(_page, outputtitle, outputTitle);
            await _page.Locator("//select[@name='output-type']").SelectOptionAsync(
                   new SelectOptionValue { Label = "Email via GOVUK Notify" });
            await GenericHelper.Fill(_page, outputTemplate, "6e64408c-47da-4a96-b944-9e6215f7db9d");
            await GenericHelper.Fill(_page, outputAPIKey, "pdffileemail-7af93a2c-9f11-4f8e-b02f-7c5060afb45b-0049e6aa-5f77-4f49-883b-86f74e06a168");
            string selectedValue = await _page.Locator("//select[@name='email-field']").TextContentAsync();
            Assert.That(selectedValue, Is.EqualTo("DSI Signin Email"),
                "Expected 'DSI Signin Email' to be selected in the dropdown.");
            await GenericHelper.Click(_page, saveButton);
        }

        public async Task ValidateAddedOutput(string output)
        {
            var addedOutput = _page.GetByRole(AriaRole.Link, new() { Name = output, Exact = true });
            Assert.That(await addedOutput.IsVisibleAsync(), Is.True,
                $"Link '{output}' was not added to the page.");
        }
        public async Task DuplicatePage()
        {
            await GenericHelper.Click(_page, secondPageEditPageLink);
            await GenericHelper.Click(_page, clickDuplicatePageButton);
        }

        public async Task VerifyDuplicatedPage()
        {
            var actualHeading = await _page.Locator("//div/div[4]//h3[text()='Second page']").TextContentAsync();
            Assert.That(actualHeading?.Trim(),
                Is.EqualTo("Second page"),
                $"Expected heading 'Second page' but found '{actualHeading}'.");
        }

        public async Task DeleteDuplicatedPage()
        {
            await _page.Locator("//h3[text()='Second page']/ancestor::div[1]/following-sibling::div[2]/button[1]").Last.ClickAsync();
            await GenericHelper.Click(_page, deleteConfirmCheckBox);
            _page.Dialog += async (_, dialog) =>
            {
                Console.WriteLine(dialog.Message);
                await dialog.AcceptAsync();
            };
            await GenericHelper.Click(_page, deletePageButton);
        }

        public async Task VerifyDeletedPage()
        {
            Assert.True((await _page.Locator("//div/div[4]//h3[text()='Second page']").CountAsync()) == 0, "Page should be deleted");
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
            await GenericHelper.Click(_page, savePageButton);
        }
        public async Task ClickCreateComponentButton()
        {
            await _page.Locator("//button[.='Create component']").First.ClickAsync();
        }
        public async Task ClickDSIComponentLink()
        {
            await GenericHelper.Click(_page, dsiComponentLink);
        }
        public async Task EnterDSIdetails(string title)
        {
            await GenericHelper.Fill(_page, enterTitle, title);
            await GenericHelper.Click(_page, saveButton);
        }

        public async Task AddCondition(string DSI, string ukprn, string conditionTitle)
        {
            await GenericHelper.Click(_page, menuConditionsButton);
            await GenericHelper.Click(_page, addConditionButton);
            await GenericHelper.Fill(_page, conditionName, conditionTitle);
            await GenericHelper.SelectByText(_page, selectComponent, DSI);
            await GenericHelper.SelectByText(_page, selectConditionOperator, "is");
            await GenericHelper.Click(_page, selectCustomTextRadiobutton);
            await GenericHelper.Fill(_page, enterCustomTextValue, ukprn);
            await GenericHelper.Click(_page, addLink);
            await GenericHelper.Click(_page, saveConditionButton);
            await GenericHelper.Click(_page, closeLink);
        }

        public async Task ClickSave()
        {
            await GenericHelper.Click(_page, save);
        }

        public async Task HideOnPage()
        {
            await _page.Locator("(//div[@class='component-item'])[2]").ClickAsync();
            await _page.Locator("#hideResultOnPage").ClickAsync();

        }

        public async Task Hideonsummary()
        {
            await _page.Locator("(//div[@class='component-item'])[2]").ClickAsync();
            await _page.Locator("#hideResultOnSummary").ClickAsync();
        }

        public async Task DeleteImportDataSet()
        {
            await _page.Locator("(//input[@type='radio'])[1]").ClickAsync();
            await _page.Locator("//input[@name='delete-confirm']").ClickAsync();
            await _page.Locator("//button[text()='Delete data set']").ClickAsync();
        }
    }
}
