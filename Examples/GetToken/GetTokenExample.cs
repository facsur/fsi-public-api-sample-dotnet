using System.Text.Json;

namespace Fsi.PublicApi.Sample.Dotnet.Examples.GetToken
{
    public class GetTokenExample
    {
        /* The subscription key obtained by subscribing to a FSI Public API Product on the developer portal */
        private readonly string subscriptionKey = PublicApiRequestConstants.SubscriptionKey;

        /* The site code assigned to your facility, used when logging into CMS */
        private readonly string siteCode = PublicApiRequestConstants.SiteCode;

        /* Your CMS Username */
        private readonly string username = PublicApiRequestConstants.Username;

        /* Your CMS Password */
        private readonly string password = PublicApiRequestConstants.Password;

        /* The FSI Public API endpoint to retrieve a token */
        private readonly string tokenEndpointUrl = "https://api-public.facsur.com/token/v1";

        /**********************************************************************
         * Makes a POST request to the FSI Public API Get Token Endpoint using
         * The parameters defined above, then deserializes the response into 
         * the TokenResponse object.
         * 
         * Ocp-Apim-Subscription-Key & Site are required headers.
         *********************************************************************/
        public async Task<TokenResponse> GetTokenAsync()
        {
            var requestBodyValues = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", this.username },
                { "password", this.password },
            };

            var requestBody = new FormUrlEncodedContent(requestBodyValues);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subscriptionKey);
            client.DefaultRequestHeaders.Add("Site", this.siteCode);

            var response = await client.PostAsync(this.tokenEndpointUrl, requestBody);
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);

            return JsonSerializer.Deserialize<TokenResponse>(jsonResponse);         
        }
    }
}
