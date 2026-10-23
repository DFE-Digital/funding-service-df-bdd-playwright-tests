using AventStack.ExtentReports;
using DigitalForm_AutomationSuite.api.core;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightBDD.Helpers;
using PlaywrightBDD.Hooks;
using Reqnroll;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlaywrightBDD_Framework.Steps
{
    [Binding]

    public class ApiSteps
    {
        private readonly ConfigurationManager config1;
        private readonly ScenarioContext _scenarioContext;
        private HttpResponseMessage _response;
        private string _responseContent;
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public static string Endpoint;
        public static string Env;
        public string Enviorments;
        private IPage _page;

        public ApiSteps(ScenarioContext scenarioContext)
        {
            _page = GlobalHooks.Page;

            _scenarioContext = scenarioContext;
            config1 = new ConfigurationManager();
            config1.AddJsonFile(projectDirectory + "\\Appsettings.json");
            Endpoint = config1["Endpoints"].Trim();
            var tags = _scenarioContext.ScenarioInfo.Tags;
            if (tags[0].Contains("preprod"))
            {
                Env = "https://" + "preprod.";
            }
            else if (tags[0].Contains("test"))
            {
                Env = "https://" + "test.";
            }
            else if (tags[0].Contains("dev"))
            {
                Env = "https://" + "dev.";
            }
        }


        [When("I send a GET request to {string}")]
        public async Task WhenISendAGetRequestTo(string Request)
        {
            using var client = new HttpClient();
            _response = await client.GetAsync(Env + Endpoint + RequestNames.listFormConfigurations);
            _responseContent = await _response.Content.ReadAsStringAsync();
            var scenario = _scenarioContext.Get<ExtentTest>();
        }

        [Then("the response should contain {string}")]
        public void ThenTheResponseShouldContain(string expected)
        {
            var scenario = _scenarioContext.Get<ExtentTest>();
            Assert.IsTrue(_responseContent.Contains(expected), $"Expected '{expected}' in response.");
            scenario.Pass($"Verified response contains: {expected}");
        }
        [When(@"I send a POST request to ""(.*)"" with body")]
        public async Task WhenISendAPostRequestToWithBody(string url, Table table)
        {
            var scenario = _scenarioContext.Get<ExtentTest>();
            var jsonBody = new StringBuilder();
            jsonBody.Append("{");
            foreach (var row in table.Rows)
            {
                var key = row["Key"];
                var value = row["Value"];
                if (key == "data")
                {
                    jsonBody.Append($"\"{key}\": {value},");
                }
                else
                {
                    jsonBody.Append($"\"{key}\": \"{value}\",");
                }
            }
            if (jsonBody[jsonBody.Length - 1] == ',')
                jsonBody.Remove(jsonBody.Length - 1, 1); // Remove trailing comma
            jsonBody.Append("}");
            using var client = new HttpClient();
            var content = new StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json");
            scenario.Info($"POST {url}");
            scenario.Info($"Request Body: {jsonBody}");
            _response = await client.PostAsync(url, content);
            _responseContent = await _response.Content.ReadAsStringAsync();
            scenario.Info($"Status Code: {_response.StatusCode}");
            scenario.Info($"Response: {_responseContent}");
        }
        [When("I send a POST request to addConfiguration")]
        public async Task WhenISendAPOSTRequestToAddConfiguration()
        {
            await RetryHelper.RetryAsync(async () =>
            {
                var scenario = _scenarioContext.Get<ExtentTest>();
                string jsonBody = File.ReadAllText(projectDirectory + "\\TestData\\up94y_am1j.json");
                using var client = new HttpClient();
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                _response = await client.PostAsync(Env + Endpoint + RequestNames.addConfiguration, content);
                _responseContent = await _response.Content.ReadAsStringAsync();
                scenario.Info($"Status Code: {_response.StatusCode}");
                scenario.Info($"Response: {_responseContent}");
            }, maxRetries: 2, delayMilliseconds: 1500);
        }

        [Then("the status code should be {int}")]
        public async Task ThenTheStatusCodeShouldBe(int Statuscode)
        {
            Thread.Sleep(5000);
            await RetryHelper.RetryAsync(async () =>
            {
                int Status = (int)_response.StatusCode;
                Assert.That(Status, Is.EqualTo(Statuscode), "Status");
                Console.WriteLine(Statuscode);
            }, maxRetries: 2, delayMilliseconds: 1500);
        }


        [When("I send a POST request to updateconfigration")]
        public async Task WhenISendAPOSTRequestToUpdateconfigration()
        {
            var scenario = _scenarioContext.Get<ExtentTest>();
            string jsonBody = File.ReadAllText(projectDirectory + "\\TestData\\up94y_am1j updated.json");
            using var client = new HttpClient();
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            _response = await client.PutAsync(Env + Endpoint + RequestNames.updateconfiguration, content);
            _responseContent = await _response.Content.ReadAsStringAsync();
            scenario.Info($"Status Code: {_response.StatusCode}");
            scenario.Info($"Response: {_responseContent}");
        }

        [When("I check the form exist {string}")]
        public async Task WhenICheckTheFormExist(string formname)
        {
            using var client = new HttpClient();
            _response = await client.GetAsync(Env + Endpoint + RequestNames.checkFormExists + "/" + formname);
            _responseContent = await _response.Content.ReadAsStringAsync();
            var scenario = _scenarioContext.Get<ExtentTest>();
        }
        [When("I check the form id exist {string}")]
        public async Task WhenICheckTheFormIdExist(string formid)
        {

            using var client = new HttpClient();
            _response = await client.GetAsync(Env + Endpoint + RequestNames.getConfiguration + "/" + formid);
            _responseContent = await _response.Content.ReadAsStringAsync();
            var scenario = _scenarioContext.Get<ExtentTest>();
        }

        [When("upload the json file config {string} with UKPRN {string}")]
        public async Task WhenUploadTheJsonFileConfigWithUKPRN(string formid, string UKPRN)
        {
            var requestBody = new
            {
                id = formid,
                providers = UKPRN,
                date = "Tue, 25 Nov 2025 16:26:04 GMT"
            };
            string jsonBody = JsonSerializer.Serialize(requestBody);
            using var client = new HttpClient();
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            _response = await client.PostAsync(Env + Endpoint + RequestNames.uploadProvidersMapping, content);
        }

        [When("delete the form  {string}")]
        public async Task WhenDeleteTheForm(string formid)
        {
            using var client = new HttpClient();
            _response = await client.DeleteAsync(Env + Endpoint + RequestNames.deleteConfiguration + "/" + formid);
            _responseContent = await _response.Content.ReadAsStringAsync();
            var scenario = _scenarioContext.Get<ExtentTest>();
        }


        [Then("Delete the form using API")]
        public async Task ThenDeleteTheFormUsingAPI()
        {
             string currentUrl = _page.Url;

            string[] formids = currentUrl.Split("/");

            if (currentUrl.Contains("preprod"))
            {
                Env = "https://" + "preprod.";
            }
            else if (currentUrl.Contains("test"))
            {
                Env = "https://" + "test.";
            }
            else if (currentUrl.Contains("dev"))
            {
                Env = "https://" + "dev.";
            }
            using var client = new HttpClient();
             _response = await client.DeleteAsync(Env + Endpoint + RequestNames.deleteConfiguration + "/" + formids[5]);
             _responseContent = await _response.Content.ReadAsStringAsync();

        }

    }
}
