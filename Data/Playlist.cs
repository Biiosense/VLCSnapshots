using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Playlist : List<Stream>
    {

        private List<Stream> streams;

        public Playlist()
        {
            streams = new List<Stream>();
        }

        public Playlist(int capacity) : base(capacity) { }

        public Playlist(IEnumerable<Stream> collection) : base(collection) { }


    }
}
