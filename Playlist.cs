using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLCSnapshots
{
    class Playlist
    {

        private List<Stream> playlist;

        public Playlist()
        {
            playlist = new List<Stream>();
        }



        public void addStream(Stream s)
        {
            playlist.Add(s);
        }
        
        public Stream getStream(int index)
        {
            return playlist.ElementAt(index);
        }
        
        public void removeStream(Stream s)
        {
            playlist.Remove(s);
        }

        public void removeStream(int index)
        {
            playlist.RemoveAt(index);
        }


    }
}
