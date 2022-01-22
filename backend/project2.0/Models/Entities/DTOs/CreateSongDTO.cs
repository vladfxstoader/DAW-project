using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class CreateSongDTO
    {
        public string Name { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
    }
}
