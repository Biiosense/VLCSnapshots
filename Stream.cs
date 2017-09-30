using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLCSnapshots
{
    public class Stream
    {
        public string brand;
        public string ipAddress;
        public int streamNumber;
        public string streamAddress;

        public Stream(string brand, string ipAddress, int streamNumber, string streamAddress)
        {
            this.brand = brand;
            this.ipAddress = ipAddress;
            this.streamNumber = streamNumber;
            this.streamAddress = streamAddress;
        }

        public string getStreamName()
        {
            return ipAddress + "_F" + streamNumber;
        }
    }
}
