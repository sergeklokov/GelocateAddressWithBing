using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;


namespace GelocateAddressWithBing
{
    class DownloadDetails
    {
        public string jobStatus { get; set; }
        public string suceededlink { get; set; }
        public string failedlink { get; set; }

    }
}
