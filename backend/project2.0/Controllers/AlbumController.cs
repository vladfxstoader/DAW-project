using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project2._0.Models.Entities;
using project2._0.Models.Entities.DTOs;
using project2._0.Repositories.AlbumRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _repository;
        public AlbumController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            var albums = await _repository.GetAllAlbumsWithArtistsAndSongs();

            var albumsToReturn = new List<AlbumDTO>();

            foreach (var album in albums)
            {
                albumsToReturn.Add(new AlbumDTO(album));
            }

            return Ok(albumsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumDTO dto)
        {
            try
            {
                Album newAlbum = new Album();

                newAlbum.Name = dto.Name;
                newAlbum.YearOfRelease = dto.YearOfRelease;
                newAlbum.NumberOfSongs = dto.NumberOfSongs;
                newAlbum.ArtistId = dto.ArtistId;
                //newAlbum.Artist = dto.Artist;

                _repository.Create(newAlbum);

                await _repository.SaveAsync();

                return Ok(new AlbumDTO(newAlbum));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _repository.GetByIdWithArtist(id);

            return Ok(new AlbumDTO(album));
        }

        /*[HttpGet("{id}")]
        [Route("albumwithsongs/{id}")]
        public async Task<IActionResult> GetAlbumByIdWithSongs(int id)
        {
            var album = await _repository.GetByIdWithArtistAndSongs(id);

            return Ok(new AlbumDTO(album));
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _repository.GetByIdAsync(id);

            if (album == null)
            {
                return NotFound("Album does not exist!");
            }

            _repository.Delete(album);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
