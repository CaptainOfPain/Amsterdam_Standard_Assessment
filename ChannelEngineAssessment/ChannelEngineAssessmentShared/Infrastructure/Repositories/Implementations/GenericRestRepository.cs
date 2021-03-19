using System;
using System.Net;
using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Configurations;
using ChannelEngineAssessmentShared.Exceptions;
using ChannelEngineAssessmentShared.Infrastructure.Factories;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;
using RestSharp;

namespace ChannelEngineAssessmentShared.Infrastructure.Repositories.Implementations
{
    public class GenericRestRepository : IGenericRestRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public GenericRestRepository(IHttpClientFactory httpClientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _applicationConfiguration = applicationConfiguration ?? throw new ArgumentNullException(nameof(applicationConfiguration));
        }

        public async Task<T> GetAsync<T>(IRestRequest restRequest)
            => await CallAsync<T>(restRequest, Method.GET);

        public async Task<T> PostAsync<T>(IRestRequest restRequest)
            => await CallAsync<T>(restRequest, Method.POST);

        public async Task<T> PutAsync<T>(IRestRequest restRequest)
            => await CallAsync<T>(restRequest, Method.PUT);

        public async Task<T> PatchAsync<T>(IRestRequest restRequest)
            => await CallAsync<T>(restRequest, Method.PATCH);

        public async Task<T> DeleteAsync<T>(IRestRequest restRequest)
            => await CallAsync<T>(restRequest, Method.DELETE);

        private async Task<T> CallAsync<T>(IRestRequest restRequest, Method method)
        {
            var client = _httpClientFactory.CreateRestClient();
            restRequest.AddParameter(_applicationConfiguration.ApiKeyNameUrlParameter, _applicationConfiguration.ApiKey, ParameterType.QueryString);
            var responseMessage = await client.ExecuteAsync<T>(restRequest, method);

            if (responseMessage.IsSuccessful)
            {
                return responseMessage.Data;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ApiAuthenticationError(responseMessage.ErrorMessage);
            }

            throw new HttpClientUnhandledException(responseMessage.ErrorMessage);
        }
    }
}
