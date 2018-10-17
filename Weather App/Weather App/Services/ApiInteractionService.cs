using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather_App.Interfaces;

namespace Weather_App.Services
{
    public class ApiInteractionService : IApiInteractionService
    {
        public async Task<T> GetExternalApiResult<T>(string baseUrl, string parametersUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response =
                    await client.GetAsync(parametersUrl);
                var stringResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(stringResult);

                return result;
            }
        }
    }
}