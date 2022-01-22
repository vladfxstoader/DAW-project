using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfSongs { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } //proprietatea de navigare 
        public ICollection<Song> Songs { get; set; }
    }
}
