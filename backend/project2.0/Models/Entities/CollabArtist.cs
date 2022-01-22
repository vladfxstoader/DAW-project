using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities
{
    public class CollabArtist
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int CollabId { get; set; }
        public Collab Collab { get; set; }
    }
}
