using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
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

        public Stream()
        {
        }

        public override string ToString()
        {
            return getStreamName();
        }

        public string getStreamName()
        {
            return ipAddress + "_F" + streamNumber;
        }

        #region Override operator == !=

        public override bool Equals(object Obj)
        {
            if (!ReferenceEquals(Obj, DBNull.Value))
                return streamAddress == ((Stream)Obj).streamAddress;
            return false;
        }

        public static bool operator ==(Stream stream1, Stream stream2)
        {
            if (ReferenceEquals(stream1, null))
                return ReferenceEquals(stream2, null);
            return stream1.Equals(stream2);
        }

        public static bool operator !=(Stream stream1, Stream stream2)
        {
            if (ReferenceEquals(stream1, null))
                return !ReferenceEquals(stream2, null);
            return !stream1.Equals(stream2);
        }

        public override int GetHashCode()
        {
            var hashCode = -124560923;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(brand);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ipAddress);
            hashCode = hashCode * -1521134295 + streamNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(streamAddress);
            return hashCode;
        }
        #endregion

    }
}
