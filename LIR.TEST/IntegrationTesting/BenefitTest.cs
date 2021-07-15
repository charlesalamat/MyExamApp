using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;
using LIR.API;
using System;
using LIR.VIEWMODEL.ViewModels;

namespace IntegrationTesting
{
    public class BenefitTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        public BenefitTest(WebApplicationFactory<Startup> factory)
        {
            //_httpClient = factory.CreateDefaultClient(new Uri("https://localhost:44314/api"));
            //factory.ClientOptions.BaseAddress = new Uri("https://localhost:44314/api");
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task CheckSetup()
        {
            var response = await _httpClient.GetAsync("api/Benefit/getSetup");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ConfigureSetup()
        {
            var content = new
            {
                Url = "/api/Benefit/configureSetup",
                Body = new RetirementSetupViewModel()
                {
                    GuaranteedIssue = 45000,
                    MaxAgeLimit = 60,
                    MinAgeLimit = 18,
                    MinimumRange = 1,
                    MaximumRange = 5,
                    Increments = 1
                }
            };
            var response = await _httpClient.PostAsync(content.Url, ContentHelper.GetStringContent(content.Body));
            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Compute()
        {
            var content = new
            {
                Url= "/api/Benefit/compute",
                Body= new ConsumerProfileViewModel()
                {
                    ConsumerName = "Charles Victor",
                    BasicSalary = 99999,
                    Birthdate = DateTime.Now.AddYears(-25)
                }
            };
            var response = await _httpClient.PostAsync(content.Url, ContentHelper.GetStringContent(content.Body));
            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetHistoryById()
        {
            var response = await _httpClient.GetAsync("api/Benefit/historyEdit?id=BC92DF27-FDF0-4B80-02E2-08D946E41CF9");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateConsumerRecord()
        {
            var content = new
            {
                Url = "/api/Benefit/historyEdit",
                Body = new ConsumerProfileViewModel()
                {
                    Id = Guid.Parse("BC92DF27-FDF0-4B80-02E2-08D946E41CF9"),
                    ConsumerName = "Charles Victor",
                    BasicSalary = 88888,
                    Birthdate = DateTime.Now.AddYears(-25)
                }
            };
            var response = await _httpClient.PostAsync(content.Url, ContentHelper.GetStringContent(content.Body));
            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
}
