# BlazorAuthForwarding

[Backend function](https://github.com/nampacx/AzFnctAzDbEFAADUser) needed to provide data.

appsettings.json needs to be added to wwwroot

```
{
  "AzureAd": {
    "ClientId": "{{appregistration_client_id}}",
    "Authority": "https://login.microsoftonline.com/{{tenant_id}}/",
    "ValidateAuthority": true,
  },
  "LocalhostBaseAddress": "http://localhost:{{port}}/",
  "ToDosUri": "{{todo_function_enddpoint}}"
}
```
LocalhostBaseAddress only needed for local testing. After publishing as Static Web App this can be empty. The static web app need than to configure a api link to [Backend function](https://github.com/nampacx/AzFnctAzDbEFAADUser) and the funtion needs than to be set as ToDosUri.
