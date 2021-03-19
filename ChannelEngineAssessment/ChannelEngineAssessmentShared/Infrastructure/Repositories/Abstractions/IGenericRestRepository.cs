using System.Threading.Tasks;
using RestSharp;

namespace ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions
{
    public interface IGenericRestRepository
    {
        Task<T> GetAsync<T>(IRestRequest restRequest);
        Task<T> PostAsync<T>(IRestRequest restRequest);
        Task<T> PutAsync<T>(IRestRequest restRequest);
        Task<T> PatchAsync<T>(IRestRequest restRequest);
        Task<T> DeleteAsync<T>(IRestRequest restRequest);
    }
}
