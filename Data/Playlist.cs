using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data
{
    [JsonObject(MemberSerialization.Fields)]
    public class Playlist : Collection<Stream>
    {

        public string name;

        public Playlist(string name) 
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public override string ToString()
        {
            return getName();
        }

        #region Override operators Equals / == / !=

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(Obj, null) || ReferenceEquals(Obj, DBNull.Value)) return false;

            if (Obj is Playlist obj && name == obj.name && Items.SequenceEqual(obj.Items))
                return true;

            return false;
        }

        public static bool operator ==(Playlist playlist1, Playlist playlist2)
        {
            if (ReferenceEquals(playlist1, null))
                return ReferenceEquals(playlist2, null);
            return playlist1.Equals(playlist2);
        }

        public static bool operator !=(Playlist playlist1, Playlist playlist2)
        {
            if (ReferenceEquals(playlist1, null))
                return !ReferenceEquals(playlist2, null);
            return !playlist1.Equals(playlist2);
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }

        #endregion

    }
}
