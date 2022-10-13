using System.Net.Http.Json;
using ClaimsAutoProcessing.Api.Domain;
using FluentAssertions;

namespace ClaimsAutoProcessing.Tests.Integration
{
    public class AutoProcessingTests : IClassFixture<ClaimsAutoProcessingTestApi>
    {
        private readonly HttpClient _client;

        public AutoProcessingTests(ClaimsAutoProcessingTestApi testApi)
        {
            _client = testApi.CreateClient();
        }

        [Fact]
        public async Task claims_are_autoprocessed()
        {
            var sync = 
                await _client.PostAsync("AutoProcessing", new StringContent(string.Empty));

            sync.EnsureSuccessStatusCode();

            var autoProcessingResult = await _client.GetFromJsonAsync<Batch[]>("AutoProcessing");

            var autoVettedClaim = autoProcessingResult
                .First()
                .Claims
                .First(c => c.DiagnosisCode == "ANT002A");

            autoVettedClaim.VettingStatus.Should().Be(VettingStatus.Accepted);
        }
    }
}