using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public SongDTO(Song song)
        {
            this.Id = song.Id;
            this.Name = song.Name;
            this.Duration = song.Duration;
            this.Genre = song.Genre;
            this.AlbumId = song.AlbumId;
            this.Album = song.Album;
        }
    }
}
