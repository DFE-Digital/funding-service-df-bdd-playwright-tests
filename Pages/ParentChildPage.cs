using Microsoft.Playwright;
using PlaywrightBDD_Framework.Helper;

namespace DigitalForm_AutomationSuite.Pages
{
    public class ParentChildPage
    {
        private IPage _page;

        public ParentChildPage(IPage page)
        {
            _page = page;
        }

        public string[] markAsParentFormCheckbox = new[]
        {
            "//input[@class='govuk-checkboxes__input']"
        };
        public string[] checkboxToMakeStandaloneForm = new[]
       {
            "//input[@id='confirm']"
        };
        public string[] makeStandaloneButton = new[]
       {
            "//button[text()='Make standalone']"
        };
        public string[] backButton = new[]
       {
            "//a[text()='Back']"
        };

        public string[] descriptionText = new[]
        {
            "//textarea[@name='add-child-list-description']"
        };
        public string[] headingText = new[]
       {
            "//input[@name='add-child-list-heading']"
        };
        public string[] childSearchFormButton = new[]
       {
            "//a[text()='Search form']"
        };
        public string[] dependentSearchFormButton = new[]
       {
            "//a[text()='Search forms']"
        };
        public string[] clickSearch = new[]
       {
            "//input[@type='search']"
        };
        public string[] clickChildSearch = new[]
       {
            "//input[@type='text']"
        };
        public string[] selectForm = new[]
       {
            "//tr[@class='govuk-table__row']/td[2]"
        };
        public string[] addToChildList = new[]
   {
            "//button[text()='Add to child list']"
        };
        public string[] addToDependentList = new[]
       {
            "//button[text()='Add to dependent list']"
        };
        public string[] addChildButton = new[]
              {
            "//button[text()='Add child']"
        };
        public string[] groupFormButton = new[]
      {
            "//button[text()='Group form']"
        };
        public string[] clickConfirmCheckbox = new[]
      {
            "//input[@id='confirm']"
        };
        public string[] selectConditionName = new[]
      {
            "//select[@name='pnc-condition']"
        };
        public string[] clickGroupFormModalwindowButton = new[]
      {
            "//div[@class='modal']//button[text()='Group form']"
        };
        public async Task ClickMarkThisAsParentFormCheckbox()
        {
            await GenericHelper.Click(_page, markAsParentFormCheckbox);
        }

        public async Task ConfirmUnGroupingForms()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await GenericHelper.Click(_page, checkboxToMakeStandaloneForm);
            await GenericHelper.Click(_page, makeStandaloneButton);
            await GenericHelper.Click(_page, backButton);
        }
        public async Task EnterDescriptionAndHeading()
        {
            await GenericHelper.Fill(_page, descriptionText, "Welcome to Parent page");
            await GenericHelper.Fill(_page, headingText, "List of Child forms");
        }
        public async Task SelectChildForm(string formname)
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//a[text()='Search form']"));
            await GenericHelper.Click(_page, childSearchFormButton);
            SearchForForm(formname);
        }
        public async Task SearchForForm(string formName)
        {
            await GenericHelper.Clear(_page, clickChildSearch);
            await GenericHelper.Fill(_page, clickChildSearch, formName);
            await _page.Keyboard.PressAsync("Enter");
            await GenericHelper.Click(_page, selectForm);
            await GenericHelper.Click(_page, addToChildList);
        }

        public async Task SearchDepedentForm(string formname)
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//a[text()='Search forms']"));
            await GenericHelper.Click(_page, dependentSearchFormButton);
            SelectDependentForm(formname);
        }

        public async Task SelectDependentForm(string formName)
        {
            await GenericHelper.Clear(_page, clickChildSearch);
            await GenericHelper.Fill(_page, clickChildSearch, formName);
            await _page.Keyboard.PressAsync("Enter");
            await GenericHelper.Click(_page, selectForm);
            await GenericHelper.Click(_page, addToDependentList);
        }

        public async Task SelectDependentFormStatuses()
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//a[text()='Search forms']"));
            var inProgressInputs = _page.Locator(
                "//table[@id='selected-dependent-forms']//tr/td[2]" +
                "//label[normalize-space()='In progress']/preceding-sibling::input"
            );
            int count = await inProgressInputs.CountAsync();

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var input = inProgressInputs.Nth(i);
                    await input.ScrollIntoViewIfNeededAsync();
                    await input.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible
                    });
                    await input.ClickAsync();
                    await _page.WaitForTimeoutAsync(500);
                }
            }
        }

        public async Task SelectCondition(string conditionTitle)
        {
            await GenericHelper.SelectByText(_page, selectConditionName, conditionTitle);
        }

        public async Task ClickAddChildButton()
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//button[text()='Add child']"));
            await GenericHelper.Click(_page, addChildButton);
        }

        public async Task ClickOnGroupFormButton()
        {
            await GenericHelper.ScrollToElementAsync(_page.Locator("//button[text()='Group form']"));
            await GenericHelper.Click(_page, groupFormButton);
        }

        public async Task ConfirmParentChildGrouping()
        {
            await GenericHelper.Click(_page, clickConfirmCheckbox);
            await GenericHelper.Click(_page, clickGroupFormModalwindowButton);
        }

        public async Task<Boolean> checkArrowForParent()
        {
            bool elementVisible = await _page.Locator("//tr/td[@data-width='30px']/div[@class='table-cell']/span").First.IsVisibleAsync();
            return elementVisible;
        }
    }
}
