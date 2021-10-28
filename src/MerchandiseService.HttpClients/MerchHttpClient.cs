using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<HttpStatusCode> V1IssueMerch(MerchIssueRequest merchItemIssueModel, CancellationToken token)
        {
            var merchItemIssueModelToJson = JsonSerializer.Serialize(merchItemIssueModel);
            var httpContent = new StringContent(merchItemIssueModelToJson, Encoding.UTF8);
            using var response = await _httpClient.PostAsync("v1/api/merch", httpContent, token);
            return response.StatusCode;
        }

        public async Task<List<MerchItemResponse>> V1GetByEmployeeId(long employeeId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch?employeeId={employeeId}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }
    }
}