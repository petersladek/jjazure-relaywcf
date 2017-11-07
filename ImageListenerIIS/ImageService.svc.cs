using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;

// !!!!!!!!!!!!!!!!!!!
// ! NOT WORKING NOW !
// !!!!!!!!!!!!!!!!!!!
// https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-host-a-wcf-service-in-iis
// https://stackoverflow.com/questions/32503307/can-azure-service-bus-relay-be-used-to-expose-an-asp-net-hosted-wcf-service
// https://blog.jeroenmaes.eu/2014/06/azure-service-bus-relay-and-iis-8-warming-up-wcf-services/
// https://social.msdn.microsoft.com/Forums/en-US/c6024ac0-b670-4819-988a-a5ca3b389c3a/how-to-expose-an-iis-hosted-wcf-rest-service-using-webhttprelaybinding-on-the-appfabric-service?forum=WAVirtualMachinesVirtualNetwork
// https://blog.vertica.dk/2016/04/17/exposing-any-on-premise-wcf-services-in-azure/

namespace Microsoft.ServiceBus.Samples
{
    [ServiceBehavior(Name = "ImageService", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
    public class ImageService : IImageContract
    {
        string imageFilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "image.jpg");

        Image bitmap;

        public ImageService()
        {
            this.bitmap = Image.FromFile(imageFilePath);
        }

        public Stream GetImage()
        {
            MemoryStream stream = new MemoryStream();
            this.bitmap.Save(stream, ImageFormat.Jpeg);

            stream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";

            return stream;
        }
    }
}
