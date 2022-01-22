using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.ArtistRepository
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<Artist> GetByName(string name);
        Task<List<Artist>> GetAllArtistsWithManagers();
        Task<Artist> GetByIdWithManager(int id);

    }
}
