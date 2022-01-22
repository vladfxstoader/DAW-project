using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Models.Entities.DTOs
{
    public class CreateArtistDTO
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Manager Manager { get; set; }
    }
}
