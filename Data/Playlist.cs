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

    }
}
