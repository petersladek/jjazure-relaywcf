# WCF service with Service Bus Relay
WCF Service for getting image via <a href="https://docs.microsoft.com/en-us/azure/service-bus-relay/relay-what-is-it">Azure Relay</a>.<br/>
The reason is to "publish" .Net REST WCF service via Azure Relay. 
There no direct publishing of this service. Service is using WCF Relay binding to publish it. You need no firewall port publishing, communication is started from backend via HTTPS.
Client is calling Azure Relay service.<br/>
Solution is created on full DotNet. DotNetCore is not supported right now, see <a href="https://github.com/dotnet/wcf/issues/1200#issuecomment-233081695">discussion</a>.

## Create Service Bus Relay
Simply create in Azure portal new service called Relay
https://docs.microsoft.com/en-us/azure/service-bus-relay/relay-create-namespace-portal

## Change configuration
Change Key in app.config

Section system.serviceModel\behaviors\endpointBehaviors\behaviortransportClientEndpointBehavior\tokenProvider
```xml
<sharedAccessSignature keyName="RootManageSharedAccessKey" key="KEY" />
```
Section appSettings
```xml
<add key="Microsoft.ServiceBus.ConnectionString" value="Endpoint=sb://<yournamespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KEY" />
<add key="RelayServiceNamespace" value="<yournamespace>"/>
```

## Test service
Run browser with your url, my example: https://jjrelay.servicebus.windows.net/Image/GetImage
You will get image.