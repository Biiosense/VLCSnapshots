using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data
{
    [JsonObject(MemberSerialization.Fields)]
    public class Stream
    {
        private string ipAddress;
        private int streamNumber;
        private string brand;
        private string streamAddress;

        public Stream(string ipAddress, int streamNumber, string brand,  string streamAddress)
        {
            this.ipAddress = ipAddress;
            this.streamNumber = streamNumber;
            this.brand = brand;
            this.streamAddress = streamAddress;
        }

        public bool isEmpty()
        {
            return (ipAddress == "" || brand == "" || streamAddress == "");
        }


        public string getStreamName()
        {
            return ipAddress + "_F" + streamNumber;
        }

        public override string ToString()
        {
            return getStreamName();
        }

        #region Getter

        public string getIPAddress()
        {
            return ipAddress;
        }

        public int getStreamNumber()
        {
            return streamNumber;
        }

        public string getBrand()
        {
            return brand;
        }

        public string getStreamAddress()
        {
            return streamAddress;
        }

        #endregion

        #region Override operators Equals / == / !=

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(Obj, null) || ReferenceEquals(Obj, DBNull.Value)) return false;

            if (Obj is Stream obj && brand == obj.brand && ipAddress == obj.ipAddress && streamNumber == obj.streamNumber && streamAddress == obj.streamAddress)
                return true;

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
