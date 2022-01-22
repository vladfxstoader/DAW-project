using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class CreateAlbumDTO
    {
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfSongs { get; set; }
        public int ArtistId { get; set; }
    }
}
