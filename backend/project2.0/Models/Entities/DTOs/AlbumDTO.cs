using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfSongs { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }

        public AlbumDTO(Album album)
        {
            this.Id = album.Id;
            this.Name = album.Name;
            this.YearOfRelease = album.YearOfRelease;
            this.NumberOfSongs = album.NumberOfSongs;
            this.ArtistId = album.ArtistId;
            this.Artist = album.Artist;
            this.Songs = new List<Song>();
        }
    }
}
