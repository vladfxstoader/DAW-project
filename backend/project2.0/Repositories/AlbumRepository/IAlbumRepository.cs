using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.AlbumRepository
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<Album> GetByName(string name);
        Task<List<Album>> GetAllAlbumsWithArtistsAndSongs();
        Task<Album> GetByIdWithArtist(int id);
        Task<Album> GetByIdWithArtistAndSongs(int id);


    }
}
