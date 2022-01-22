using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<CollabArtist> CollabArtists { get; set; }
    }
}
