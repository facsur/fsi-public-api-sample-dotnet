## The FSI Public API Sample App

The FSI Public API Sample Application contains examples of how to use the API to:

- Retrieve a valid authentication token
- Create Work Orders in a particular facility/segment

## What is the FSI Public API?

The FSI Public API is a set of secure, REST based endpoints through which you can manage your facilities data and extend the
capabilities of CMS. See further documentation on the [Public API Developer portal](developer.fsiservices.com)

## Examples
Example code can be found in the /Examples folder. There are currently two sets of code:

- GetTokenExample, provides sample code illustrating how to obtain an authentication token used in FSI Public API requests
- CreateWorkOrderExample, provides sample code illustrating how to use the FSI Public API to create a work order


## Requirements 
- Visual Studio
- .Net Core 6

## Running the samples
- Clone the repository to your local machine
- Populate the class level fields inside PublicApiRequestConstants to be able to call endpoints for your facility's data
- Use the program.cs file to instantiate the respective example classes, if successful, responses are logged to the console