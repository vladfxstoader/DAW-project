using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project2._0.Models.Entities;
using project2._0.Models.Entities.DTOs;
using project2._0.Repositories.ArtistRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _repository;
        public ArtistController(IArtistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _repository.GetAllArtistsWithManagers();

            var artistsToReturn = new List<ArtistDTO>();

            foreach (var artist in artists)
            {
                artistsToReturn.Add(new ArtistDTO(artist));
            }

            return Ok(artistsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistDTO dto)
        {
            Artist newArtist = new Artist();

            newArtist.Name = dto.Name;
            newArtist.YearOfBirth = dto.YearOfBirth;
            newArtist.Manager = dto.Manager;

            _repository.Create(newArtist);

            await _repository.SaveAsync();

            return Ok(new ArtistDTO(newArtist));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            var artist = await _repository.GetByIdWithManager(id);

            return Ok(new ArtistDTO(artist));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _repository.GetByIdAsync(id);

            if (artist == null)
            {
                return NotFound("Artist does not exist!");
            }

            _repository.Delete(artist);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
