using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;
using Newtonsoft.Json;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public class Sut
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandler;
        private readonly ICapMonsterCloudClient _cloudClient;
        private readonly List<(RequestType, string)> _actualRequests = new();

        public Sut(string clientKey)
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            
            var clientOptions = new ClientOptions
            {
                ServiceUri = Gen.RandomUri(),
                ClientKey = clientKey
            };
            
            var httpClient = _httpMessageHandler.CreateClient();

            var cloudClientFactory = new CapMonsterCloudClientFactory(
                clientOptions,
                () => _httpMessageHandler.Object,
                (_) =>
                {
                    _httpMessageHandler.CreateClient();
                    httpClient.BaseAddress = clientOptions.ServiceUri;
                });
            
            _cloudClient = cloudClientFactory.Create();
        }

        public async Task<CaptchaResult<ImageToTextResponse>> SolveAsync (
            ImageToTextRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<RecaptchaV2Response>> SolveAsync (
            RecaptchaV2Request request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<RecaptchaV2Response>> SolveAsync (
            RecaptchaV2ProxylessRequest request) => await _cloudClient.SolveAsync(request);

        public async Task<CaptchaResult<RecaptchaV3Response>> SolveAsync (
            RecaptchaV3ProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<FunCaptchaResponse>> SolveAsync (
            FunCaptchaRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<FunCaptchaResponse>> SolveAsync (
            FunCaptchaProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<HCaptchaResponse>> SolveAsync (
            HCaptchaRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<HCaptchaResponse>> SolveAsync (
            HCaptchaProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<GeeTestResponse>> SolveAsync (
            GeeTestRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<GeeTestResponse>> SolveAsync (
            GeeTestProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync (
            RecaptchaV2EnterpriseRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync (
            RecaptchaV2EnterpriseProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<TurnstileResponse>> SolveAsync (
            TurnstileRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<TurnstileResponse>> SolveAsync (
            TurnstileProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync (
            RecaptchaComplexImageTaskRequest request) => await _cloudClient.SolveAsync(request); 
        
        public async Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync (
            HCaptchaComplexImageTaskRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync (
            FunCaptchaComplexImageTaskRequest request) => await _cloudClient.SolveAsync(request);

        public async Task<CaptchaResult<CustomTaskResponse>> SolveAsync(
            DataDomeCustomTaskRequest request) => await _cloudClient.SolveAsync(request);

        public async Task<CaptchaResult<CustomTaskResponse>> SolveAsync(
            DataDomeCustomTaskProxylessRequest request) => await _cloudClient.SolveAsync(request);

        public async Task<decimal> GetBalanceAsync()
        {
            return await _cloudClient.GetBalanceAsync();
        }

        public List<(RequestType, string)> GetActualRequests()
        {
            return _actualRequests;
        }

        public void SetupHttpServer(
            List<object> expectedResponses)
        {
            var part = _httpMessageHandler
                .Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(request => SaveRequest(request).Result),
                    ItExpr.IsAny<CancellationToken>()
                );

            foreach (var item in expectedResponses)
            {
                part.ReturnsResponse(HttpStatusCode.OK, new StringContent(JsonConvert.SerializeObject(item)));
            }
        }

        private async Task<bool> SaveRequest(HttpRequestMessage request)
        {
            if (request.RequestUri == null && request.Content == null)
                return false;
            
            var path = request.RequestUri!.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            var type = Enum.Parse<RequestType>(path,true);

            var requestStringContent = await request.Content!.ReadAsStringAsync();

            _actualRequests.Add(new(type, requestStringContent));

            return true;
        }
    }
}