using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Manager Manager { get; set; }
        public List<Album> Albums { get; set; }
        public List<CollabArtist> CollabArtists { get; set; }

        public ArtistDTO(Artist artist)
        {
            this.Id = artist.Id;
            this.Name = artist.Name;
            this.YearOfBirth = artist.YearOfBirth;
            this.Manager = artist.Manager;
            this.Albums = new List<Album>();
            this.CollabArtists = new List<CollabArtist>();
        }
    }
}
