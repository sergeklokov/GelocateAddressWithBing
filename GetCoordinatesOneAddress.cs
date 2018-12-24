using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Web;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using BingMapsRESTService.Common.JSON;

namespace GelocateAddressWithBing
{
    class GetCoordinatesOneAddress
    {
        /// <summary>
        /// This application will convert address to the coordinates on the globe by using Bing Map
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string bingKey = ConfigurationManager.AppSettings["BingKey"];
            string bingURI = ConfigurationManager.AppSettings["BingURI"];

            //string address = "1 Microsoft Way, Redmond, WA";
            string address = "5470 S Scott Pl Chandler AZ, 85249";

            var geocodeRequest = new Uri(string.Format(bingURI, address, bingKey));

            GetResponse(geocodeRequest, (x) =>
            {
                Console.WriteLine(x.ResourceSets[0].Resources.Length + " result(s) found.");

                var location = (Location)x.ResourceSets[0].Resources[0];

                Console.WriteLine("Address found: " + location.Address.FormattedAddress);
                Console.WriteLine("Entity Type: " + location.EntityType);
                Console.WriteLine("Coordinates: {0}, {1}", location.Point.Coordinates[0], location.Point.Coordinates[1]);
                Console.WriteLine("Confidence: " + location.Confidence);
                Console.WriteLine();
                Console.WriteLine("Press any key");
            });

            Console.ReadKey();
        }

        static void GetResponse(Uri uri, Action<Response> callback)
        {
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                    callback(ser.ReadObject(a.Result) as Response);
                }
            };
            wc.OpenReadAsync(uri);
        }
    }
}
