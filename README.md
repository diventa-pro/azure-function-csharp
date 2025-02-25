# C# Based Azure Functions

## Deploy this on Azure

1. Create a resource group
2. Create an azure function with the proper runtime
3. `dotnet publish -c Release`
4. Compress all files in [publish folder](bin/Release/net8.0/publish)
   `cd bin/Release/net8.0/publish &&  zip ../publish.zip *`
5. `az login`
6. `az functionapp deployment source config-zip --name APP_NAME --resource-group RG_NAME --src ./bin/Release/net8.0/publish.zip`

## Test this locally

1. Start azurite (e.g. via docker)
   `docker run -p 10000:10000 -p 10001:10001 -p 10002:10002 mcr.microsoft.com/azure-storage/azurite`
2. Copy [example.local.settings.json](example.local.settings.json) to [local.settings.json](local.settings.json)
3. Update [local.settings.json](local.settings.json) according to your env (e.g. Connection Strings)
4. `func start`