using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GelocateAddressWithBing
{
    class ProgramMultiTask
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                
            };

            Console.WriteLine();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private async void CallWebService2(string formattedURI)
        {
            var result = await CallWebServiceAsync(formattedURI);

        }

        private Task<string> CallWebServiceAsync(string formattedURI)
        {
            return Task.Factory.StartNew(() => CallWebService(formattedURI));
        }

        private string CallWebService(string formattedURI)
        {
            Thread.Sleep(1000);
            Console.WriteLine(formattedURI);
            return formattedURI;
        }

    }
}
