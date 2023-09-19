using FSI.PublicApi.Sample.Dotnet.Examples.CreateWorkOrder;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Fsi.PublicApi.Sample.Dotnet.Examples.CreateWorkOrder
{
    public class CreateWorkOrderExample
    {
        /* The subscription key obtained by subscribing to a FSI Public API Product on the developer portal */
        private readonly string subscriptionKey = PublicApiRequestConstants.SubscriptionKey;

        /* The Id of the segment/facility to create the work order in */
        private readonly int cmsSegmentId = PublicApiRequestConstants.CmsSegmentId;

        /* The FSI Public API endpoint to create a work order */
        private readonly string createWorkorderEndpointUrl = "https://api-public.facsur.com/workorders/v1/";

        /**********************************************************************
        * Makes a POST request to the FSI Public API Create Work Order Endpoint.
        * 
        * Ocp-Apim-Subscription-Key, Site, and Segment Id are required headers.
        *********************************************************************/
        public async Task<CreateWorkOrderResponse> CreateWorkorderAsync(string accessToken, int? locationId) 
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subscriptionKey);
            client.DefaultRequestHeaders.Add("CmsSegmentId", this.cmsSegmentId.ToString());

            var createWorkorderRequest = GetCreateWorkorderRequestBody(locationId);
            var requestBodyJson = new StringContent(JsonSerializer.Serialize(createWorkorderRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(this.createWorkorderEndpointUrl, requestBodyJson);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);

            // The endpoint will return a url to retrieve the created work order in the 'location' header. 
            // Optionally, the request body also contains the Id of the newly created work order which can be fed into the 
            // GetWorkOrderById Endpoint.
            //return response.Headers.GetValues("location").First();
            return JsonSerializer.Deserialize<CreateWorkOrderResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private CreateWorkorderRequest GetCreateWorkorderRequestBody(int? locationId)
        {
            return new CreateWorkorderRequest
            {
                LocationId = locationId,
                Description = "The main bathroom sink is leaking",
                RequestorName = "John Smith",
                RequestorEmail = "js@facilities.net",
                RequestorPhone = "111-123-4567"
            };
        }
    }
}
