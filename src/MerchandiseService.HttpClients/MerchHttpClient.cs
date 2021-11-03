using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels.V1.Request;
using V1MerchItem = MerchandiseService.HttpModels.V1.Response.V1MerchItem;

namespace MerchandiseService.HttpClients
{
    public class MerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task V1IssueMerch(V1MerchIssue merchItemIssueModel, CancellationToken token)
        {
            var merchItemIssueModelToJson = JsonSerializer.Serialize(merchItemIssueModel);
            var httpContent = new StringContent(merchItemIssueModelToJson, Encoding.UTF8); 
            
            await _httpClient.PostAsync("v1/api/merch", httpContent, token);
        }

        public async Task <List<V1MerchItem>> V1GetByEmployeeId(V1MerchByEmployeeId merchByEmployeeId, CancellationToken token)
        {
            var merchByEmployeeIdToJson = JsonSerializer.Serialize(merchByEmployeeId);
            var httpContent = new StringContent(merchByEmployeeIdToJson, Encoding.UTF8); 

            using var response = await _httpClient.PostAsync($"v1/api/merch", httpContent, token);
            var bodyAsString = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<V1MerchItem>>(bodyAsString);
        }
    }
}