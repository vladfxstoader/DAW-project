using Microsoft.EntityFrameworkCore;
using project2._0.Data;
using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.AlbumRepository
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ProjectContext context) : base(context) { }

        public async Task<List<Album>> GetAllAlbumsWithArtistsAndSongs()
        {
            return await _context.Albums.Include(a => a.Artist).Include(a => a.Songs).ToListAsync();
        }

        public async Task<Album> GetByIdWithArtist(int id)
        {
            return await _context.Albums.Include(a => a.Artist).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Album> GetByIdWithArtistAndSongs(int id)
        {
            return await _context.Albums.Include(a => a.Artist).Include(a => a.Songs).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Album> GetByName(string name)
        {
            return await _context.Albums.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
