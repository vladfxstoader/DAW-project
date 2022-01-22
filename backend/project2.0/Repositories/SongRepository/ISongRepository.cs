using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.SongRepository
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<Song> GetByName(string name);
        Task<List<Song>> GetAllSongsWithAlbumsAndArtists();
        Task<Song> GetByIdWithAlbum(int id);

    }
}
