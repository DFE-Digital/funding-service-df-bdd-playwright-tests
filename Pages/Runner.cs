using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightBDD_Framework.Helper;
namespace PlaywrightBDD.Pages
{
    public class Runner
    {
        private IPage _page;
        private static readonly Random Random = new();
        int numberTriggerValue_one = Random.Next(1, 8);
        int numberTriggervalue_two = Random.Next(1, 8);
        public Runner(IPage page)
        {
            _page = page;
        }

        public string[] Continue = new[]
        {
            "(//button[contains(text(),'ontinue')])[1]",
            ".govuk-button[type='submit']",
            "#submit"
        };
        public string[] Closedlabel = new[]{
            ".govuk-grid-column-two-thirds>h1:nth-child(1)",
            "(//h1)[2]"
        };
        public string[] Closedlabel2 = new[] { "(//p[@class='govuk-body'])[2]/a[1]" };
        public string Closedlabel3 = "(//p[@class='govuk-body'])[2]/a[2]";
        public string[] submitbutton = new[] { "#submit-form" };
        public string[] summarypdfbutton = new[] { "#pdf-download" };
        public string[] Username = new[] { "#username" };
        public string[] Next = new[] { "#button-next" };
        public string[] Password = new[] { "#password" };
        public string[] signin = new[] { "#button-sign-in" };
        public string[] organisation = new[] { ".govuk-heading-xl" };
        public string[] continuebutton = new[] { "[type='submit']" };
        public string[] yourprofile = new[] { "//div[text()='Your details']" };
        public string[] continueprofile = new[] { "//button[text()='Continue']" };
        public string[] SectionTitle = new[] { "#section-title" };
        public string autocomplete = "[aria-autocomplete='both']";
        public string[] autocomplete1 = new[] { "[aria-autocomplete='both']" };
        public string[] emailelement = new[] { "[type='email']" };
        public string fileupload = "(//input[@class='govuk-file-upload'])[2]";
        public string[] fileupload1 = new[] { "(//input[@class='govuk-file-upload'])[2]" };
        public string[] multiline = new[] { ".govuk-textarea" };
        public string[] telphone = new[] { "[type='tel']" };
        public string[] texteditbox = new[] { "//input[@title='Text component']" };
        public string[] selectbox = new[] { "[title='Select component']" };
        public string[] YesNoButton = new[] { "//input[@value='true']" };
        public string[] saveAndContinueButton = new[] { "//button[@id='submit']" };
        public string[] numberTriggerInput = new[] { "//input[@type='number']" };
        public string[] numberInput = new[] { "//input[@inputmode='numeric']" };
        public string[] dayInput = new[] { "//input[@title='Day']" };
        public string[] monthInput = new[] { "//input[@title='Month']" };
        public string[] yearInput = new[] { "//input[@title='Year']" };
        public string[] hourInput = new[] { "//input[@title='Hour']" };
        public string[] minuteInput = new[] { "//input[@title='Minute']" };
        public string[] chooseAMPM = new[] { "//input[@value='am']" };
        public string checkboxes = "input[type='checkbox']";
        public string[] summarySubmitButton = new[] { "//button[@type='submit']" };

        public async Task chooseradio(string item)
        {
            await _page.Locator("//div[@title='Radios component']/div/input[contains(@value,'" + item + "')]").ClickAsync();
        }
        public async Task EnterAutocomplete(string item)
        {
            await GenericHelper.ScrollToElementAsync(_page, autocomplete1);
            await _page.Locator(autocomplete).FillAsync(item);

        }
        public async Task EnterEmail(string email)
        {
            await GenericHelper.ScrollToElementAsync(_page, emailelement);
            await _page.Locator("[type='email']").FillAsync(email);
        }
        public async Task Uploadfile(string filename)
        {
            await GenericHelper.ScrollToElementAsync(_page, fileupload1);
            await GenericHelper.UploadFileAsync(_page, fileupload, filename);
        }

        public async Task Entermultiline(string multilineval)
        {
            await GenericHelper.ScrollToElementAsync(_page, multiline);
            await GenericHelper.Fill(_page, multiline, multilineval);
        }
        public async Task EnterTelephone(string telephone)
        {
            await GenericHelper.ScrollToElementAsync(_page, telphone);
            await GenericHelper.Fill(_page, telphone, telephone);
        }
        public async Task EnterText(string textcom)
        {
            await GenericHelper.ScrollToElementAsync(_page, texteditbox);
            try
            {
                await GenericHelper.Fill(_page, texteditbox, textcom);
            }
            catch (Exception ex) { }
        }
        public async Task selectcomponent(IPage _page, string item)
        {
            await GenericHelper.ScrollToElementAsync(_page, selectbox);
            await _page.Locator("[title='Select component']").SelectOptionAsync(item);
        }
        public async Task selectyesno(IPage _page, string yesno)
        {
            await _page.Locator("//input[@value='" + yesno + "']").ClickAsync();
        }

        public async Task selectchecbox(IPage _page, string checbox)
        {
            await _page.Locator("//input[@class='govuk-radios__input' and @value='" + checbox + "']").ClickAsync();
        }
        public async Task selectcheckbox(IPage _page, string item)
        {
            await GenericHelper.scrolldowntobottom(_page);
            Thread.Sleep(3000);
            await _page.WaitForTimeoutAsync(3000);
            await _page.Locator("//div[@class='govuk-checkboxes__item']/input[@class='govuk-checkboxes__input' and @type='checkbox' and contains(@value,'" + item + "')]").ClickAsync();
        }

        public async Task Enternumber(IPage page, string number)
        {
            await GenericHelper.scrolldowntobottom(_page);
            await _page.Locator(".govuk-input__prefix +input").FillAsync(number);
        }

        public async Task enterdate(IPage page, string date)
        {
            string[] parts = date.Split('/');
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
        public async Task EnterDFESignin(string username, string password, string uKPRN, string org)
        {
            await GenericHelper.Fill(_page, Username, username);
            await GenericHelper.Click(_page, Next);
            await GenericHelper.Fill(_page, Password, "");
            await GenericHelper.Click(_page, signin);
            try
            {
                await _page.Locator("//span[contains(text(),'" + org + "')]/parent::label/parent::div/input").ClickAsync();
                await GenericHelper.Click(_page, continuebutton);
            }
            catch (Exception ex) { }
            await GenericHelper.Click(_page, continueprofile);
        }
        public async Task<string> GetSectionTitle(IPage _page)
        {
            return await GenericHelper.GetText(_page, SectionTitle);
        }
        public async Task<string> GetTitle(IPage _page)
        {
            return await GenericHelper.GetText(_page, organisation);
        }

        public async Task<string> GetSubmittext(IPage _page)
        {
            return await GenericHelper.GetText(_page, submitbutton);
        }
        public async Task<string> GetSummarypdftext(IPage _page)
        {
            return await GenericHelper.GetText(_page, summarypdfbutton);
        }
        public async Task<string> Closedlstatus_text_two(IPage _page)
        {
            return await GenericHelper.GetText(_page, Closedlabel2);
        }

        public async Task<string> Closedlstatus_text_three(IPage _page)
        {
            return await GenericHelper.GetText(_page, Closedlabel3);
        }

        public async Task<string> Closedlstatus_text_first(IPage _page)
        {
            return await GenericHelper.GetText(_page, Closedlabel);
        }

        public async Task Cleancomponent(IPage _page)
        {
            try
            {
                var elements = _page.Locator("//div[@class='component-item']");
                int a = await elements.CountAsync();
                for (int i = 1; i <= a; i++)
                {
                    await _page.Locator("(//div[@class='component-item'])[" + i + "]").ClickAsync();
                    await _page.Locator("#delete-confirm-0").ClickAsync();
                    await _page.Locator(".govuk-button.govuk-button--warning").ClickAsync();
                    if (await _page.Locator("#confirm").IsVisibleAsync())
                    {
                        await _page.Locator("#confirm").ClickAsync();
                        await _page.Locator("//button[text()='Delete component']").ClickAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                await _page.Locator("//div[@class='component-item']").ClickAsync();
                await _page.Locator("#delete-confirm-0").ClickAsync();
                await _page.Locator(".govuk-button.govuk-button--warning").ClickAsync();
            }
        }

        public async Task EnterAllFormDetails(IPage _page)
        {
            var randomDate = new DateTime(2020, 1, 1)
                .AddDays(Random.Next((new DateTime(2026, 12, 31) - new DateTime(2020, 1, 1)).Days + 1));
            int day = randomDate.Day;
            int month = randomDate.Month;
            int year = randomDate.Year;
            await GenericHelper.Click(_page, YesNoButton);
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Fill(_page, numberTriggerInput, numberTriggerValue_one.ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            for (int i = 1; i <= numberTriggerValue_one; i++)
            {
                await GenericHelper.Fill(_page, numberInput, Random.Next(1, 100).ToString());
                await GenericHelper.Click(_page, saveAndContinueButton);
                await GenericHelper.Fill(_page, numberInput, Random.Next(1, 100).ToString());
                await GenericHelper.Click(_page, saveAndContinueButton);
            }
            await GenericHelper.Fill(_page, dayInput, day.ToString());
            await GenericHelper.Fill(_page, monthInput, month.ToString());
            await GenericHelper.Fill(_page, yearInput, year.ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Fill(_page, numberTriggerInput, numberTriggervalue_two.ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            for (int i = 1; i <= numberTriggervalue_two; i++)
            {
                await GenericHelper.Fill(_page, numberInput, Random.Next(1, 100).ToString());
                await GenericHelper.Click(_page, saveAndContinueButton);
                await GenericHelper.Click(_page, saveAndContinueButton);
                await _page.Locator("//input[@value='Yes we spent NTP funding centrally']").UncheckAsync();
                await _page.Locator("//input[@value='Yes we spent NTP funding centrally']").CheckAsync();
                if (i == numberTriggervalue_two)
                {
                    await _page.Locator("//input[@value='false']").ClickAsync();
                }
                await GenericHelper.Click(_page, saveAndContinueButton);
            }
            await GenericHelper.Fill(_page, dayInput, day.ToString());
            await GenericHelper.Fill(_page, monthInput, month.ToString());
            await GenericHelper.Fill(_page, yearInput, year.ToString());
            await GenericHelper.Fill(_page, hourInput, month.ToString());
            await GenericHelper.Fill(_page, minuteInput, day.ToString());
            await GenericHelper.Click(_page, chooseAMPM);
            await GenericHelper.Click(_page, saveAndContinueButton);
            var locator = _page.Locator(checkboxes);
            int count = await locator.CountAsync();

            for (int i = 0; i < count; i++)
            {
                var checkbox = locator.Nth(i);

                if (await checkbox.IsVisibleAsync())
                {
                    await checkbox.UncheckAsync();
                    await checkbox.CheckAsync();
                }
            }
            await GenericHelper.Click(_page, saveAndContinueButton);
        }

        public async Task ValidateValuesInSummary(IPage _page)
        {
            var firstSectionHeadings = _page.Locator("//dl[@class='govuk-summary-list print-pdf']/h2[contains(normalize-space(.), 'school Detail Transferred')]");
            int firstSectionCountInSummary = await firstSectionHeadings.CountAsync();
            Assert.That(numberTriggerValue_one, Is.EqualTo(firstSectionCountInSummary));
            var secondSectionHeadings = _page.Locator("//dl[@class='govuk-summary-list print-pdf']/h2[contains(normalize-space(.), 'Add more school ')]");
            int secondSectionCountInSummary = await secondSectionHeadings.CountAsync();
            Assert.That(numberTriggervalue_two, Is.EqualTo(secondSectionCountInSummary));
        }

        public async Task SubmitForm(IPage _page)
        {
            await GenericHelper.Click(_page, summarySubmitButton);
        }
        public async Task ChangeValuesFromSummaryPage(IPage _page)
        {
            var randomDate = new DateTime(2020, 1, 1)
               .AddDays(Random.Next((new DateTime(2026, 12, 31) - new DateTime(2020, 1, 1)).Days + 1));
            int day = randomDate.Day;
            int month = randomDate.Month;
            int year = randomDate.Year;
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.Locator("(//*[contains(text(),'Date and time')]/following-sibling::dd[2]//a[contains(.,'Change')])[1]").ClickAsync();
            await GenericHelper.Fill(_page, dayInput, day.ToString());
            await GenericHelper.Fill(_page, monthInput, month.ToString());
            await GenericHelper.Fill(_page, yearInput, year.ToString());
            await GenericHelper.Fill(_page, hourInput, month.ToString());
            await GenericHelper.Fill(_page, minuteInput, day.ToString());
            await GenericHelper.Click(_page, chooseAMPM);
            await GenericHelper.Click(_page, saveAndContinueButton);
            await _page.Locator("(//*[contains(text(),'How many schools have you transferred')]/following-sibling::dd[2]//a[contains(.,'Change')])[1]").ClickAsync();
            numberTriggerValue_one = numberTriggerValue_one++;
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await GenericHelper.Fill(_page, numberTriggerInput, numberTriggerValue_one.ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Fill(_page, numberInput, Random.Next(1, 100).ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Fill(_page, numberInput, Random.Next(1, 100).ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Click(_page, saveAndContinueButton);
            await _page.Locator("(//*[contains(text(),'How many special schools have you transferred')]/following-sibling::dd[2]//a[contains(.,'Change')])[1]").ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            numberTriggervalue_two = numberTriggervalue_two - 1;
            await GenericHelper.Fill(_page, numberTriggerInput, numberTriggervalue_two.ToString());
            await GenericHelper.Click(_page, saveAndContinueButton);
            await GenericHelper.Click(_page, saveAndContinueButton);
        }

        public async Task ClickContinue(IPage _page)
        {
            await GenericHelper.Click(_page, Continue);
        }

        public async Task ClickSaveAndContinue(IPage _page)
        {
            await GenericHelper.Click(_page, saveAndContinueButton);
        }

        public async Task selectdropdown(IPage _page, string item)
        {
            await _page.Locator(".govuk-select").SelectOptionAsync(item);
        }
    }
}
