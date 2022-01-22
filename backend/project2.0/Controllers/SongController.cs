using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project2._0.Models.Entities;
using project2._0.Models.Entities.DTOs;
using project2._0.Repositories.SongRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _repository;
        public SongController(ISongRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _repository.GetAllSongsWithAlbumsAndArtists();

            var songsToReturn = new List<SongDTO>();

            foreach (var song in songs)
            {
                songsToReturn.Add(new SongDTO(song));
            }

            return Ok(songsToReturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSongDTO dto)
        {
            try
            {
                Song newSong = new Song();

                newSong.Name = dto.Name;
                newSong.Duration = dto.Duration;
                newSong.Genre = dto.Genre;
                newSong.AlbumId = dto.AlbumId;

                _repository.Create(newSong);

                await _repository.SaveAsync();

                return Ok(new SongDTO(newSong));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _repository.GetByIdWithAlbum(id);

            return Ok(new SongDTO(song));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _repository.GetByIdAsync(id);

            if (song == null)
            {
                return NotFound("Song does not exist!");
            }

            _repository.Delete(song);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
