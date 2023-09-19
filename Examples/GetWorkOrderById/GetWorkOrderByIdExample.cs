using Fsi.PublicApi.Sample.Dotnet.Examples;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FSI.PublicApi.Sample.Dotnet.Examples.GetWorkOrderById
{
    public class GetWorkOrderByIdExample
    {
        /* The subscription key obtained by subscribing to a FSI Public API Product on the developer portal */
        private readonly string subscriptionKey = PublicApiRequestConstants.SubscriptionKey;

        /* The Id of the segment/facility to retrieve locations for */
        private readonly int cmsSegmentId = PublicApiRequestConstants.CmsSegmentId;

        /* The FSI Public API endpoint to retrieve locations for a segment/facility */
        private readonly string geWorkOrderByIdEndpointUrl = "https://api-public.facsur.com/workorders/v1/";

        public async Task<Workorder> GetWorkOrderByIdAsync(string accessToken, Guid workOrderId)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subscriptionKey);
            client.DefaultRequestHeaders.Add("CmsSegmentId", this.cmsSegmentId.ToString());

            var response = await client.GetAsync(geWorkOrderByIdEndpointUrl + workOrderId.ToString());

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.Write(jsonResponse);

            return JsonSerializer.Deserialize<Workorder>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
