using Microsoft.EntityFrameworkCore;
using project2._0.Data;
using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.ArtistRepository
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ProjectContext context) : base(context) { }

        public async Task<List<Artist>> GetAllArtistsWithManagers()
        {
            return await _context.Artists.Include(a => a.Manager).ToListAsync();
        }

        public async Task<Artist> GetByIdWithManager(int id)
        {
            return await _context.Artists.Include(a => a.Manager).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Artist> GetByName(string name)
        {
            return await _context.Artists.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
