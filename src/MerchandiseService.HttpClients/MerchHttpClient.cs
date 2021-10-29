using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.HttpModels;

namespace MerchandiseService.HttpClients
{
    public class MerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<BaseResponse<object>> V1IssueMerch(MerchIssueRequest merchItemIssueModel, CancellationToken token)
        {
            var merchItemIssueModelToJson = JsonSerializer.Serialize(merchItemIssueModel);
            var httpContent = new StringContent(merchItemIssueModelToJson, Encoding.UTF8);
            
            using var response = await _httpClient.PostAsync("v1/api/merch", httpContent, token);
            var bodyAsString = await response.Content.ReadAsStringAsync(token);
            var issueMerchResponse = JsonSerializer.Deserialize<BaseResponse<object>>(bodyAsString);
            return issueMerchResponse;
        }

        public async Task<BaseResponse<List<MerchItemResponse>>> V1GetByEmployeeId(long employeeId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch?employeeId={employeeId}", token);
            var bodyAsString = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<BaseResponse<List<MerchItemResponse>>>(bodyAsString);
        }
    }
}