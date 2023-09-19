using Fsi.PublicApi.Sample.Dotnet.Examples.CreateWorkOrder;
using Fsi.PublicApi.Sample.Dotnet.Examples.GetLocations;
using Fsi.PublicApi.Sample.Dotnet.Examples.GetToken;
using FSI.PublicApi.Sample.Dotnet.Examples.GetWorkOrderById;

/* Example files can be instantiated and run here, reference the examples below to create a work order for a specific location */

/* Obtain a Public API Access token using the credentials specified in PublicApiRequest Constants */
GetTokenExample tokenExample = new GetTokenExample();
var tokenResponse = await tokenExample.GetTokenAsync();

/* Using the Token, Fetch all the locations for a Facility/Segment */
GetLocationsExample locationsExample = new GetLocationsExample();
var getLocationResponse = await locationsExample.GetLocationsAsync(tokenResponse.access_token);

/* In this example we'll be creating a work order for Room 101, we can parse the GetLocations response to find that location record and retrieve it's Id */
var room101LocationId = getLocationResponse.Data.Where(location => location.Desc == "Room 101")
    .FirstOrDefault()?.Id;

/* Next, we can create a work order using the same access token for the location whose Id we just captured */
CreateWorkOrderExample workorderExample = new CreateWorkOrderExample();
var createWorkOrderResponse = await workorderExample.CreateWorkorderAsync(tokenResponse.access_token, room101LocationId);

/* Finally, we can obtain the newly created work order using the GetWorkOrderById Endpoint. */
GetWorkOrderByIdExample getWorkOrderByIdExample = new GetWorkOrderByIdExample();
var workorder = await getWorkOrderByIdExample.GetWorkOrderByIdAsync(tokenResponse.access_token, createWorkOrderResponse.WorkOrderId);
