# WCF service with Service Bus Relay
WCF Service for getting image

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
