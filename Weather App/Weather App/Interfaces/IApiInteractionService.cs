using System.Threading.Tasks;

namespace Weather_App.Interfaces
{
    public interface IApiInteractionService
    {
        Task<T> GetExternalApiResult<T>(string baseUrl, string parametersUrl);
    }
}