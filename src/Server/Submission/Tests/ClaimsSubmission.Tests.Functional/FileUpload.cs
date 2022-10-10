using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http.Json;
using ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;
using FluentAssertions;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace ClaimsSubmission.Tests.Functional
{
    [FeatureFile("./FileUpload.feature")]
    public sealed class FileUpload: Feature, IClassFixture<ClaimsSubmissionTestApi>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        private string _fileName;
        private string _filePath;
        private bool _hasFileUploadSucceeded;

        public FileUpload(
            ClaimsSubmissionTestApi testApi,
            ITestOutputHelper testOutputHelper)
        {
            _client = testApi.CreateClient();
            _testOutputHelper = testOutputHelper;
        }

        [Given(@"the file {string}")]
        public void A_file(string fileName)
        {
            //_testOutputHelper.WriteLine("File {0}", fileName);

            _fileName = fileName;
            _filePath = Path.Combine("TestFiles", fileName);
        }

        [When(@"I request an upload")]
        public async Task I_request_an_upload()
        {
            //_testOutputHelper.WriteLine("Upload requested");

            await using var file = File.OpenRead(_filePath);
            using var content = new StreamContent(file);
            using var formData = new MultipartFormDataContent();

            formData.Add(new StringContent("12345"), "HealthcareFacilityId");
            formData.Add(content, "File", _fileName);

            var response = await _client.PostAsync("api/BatchFile", formData);

            _hasFileUploadSucceeded = response.IsSuccessStatusCode;
        }

        [Then(@"I can see file has been uploaded successfully")]
        public void I_can_see_file_has_been_uploaded_successfully()
        {
            _hasFileUploadSucceeded.Should().BeTrue();
        }

        [And(@"I can see file validation has started")]
        public async Task I_can_see_file_validation_has_started()
        {
            var batchFiles = await _client.GetFromJsonAsync<BatchFileDto[]>("api/BatchFile");

            batchFiles?.FirstOrDefault(f => f.FileOriginalName == _fileName).Should().NotBeNull();
        }
    }
}