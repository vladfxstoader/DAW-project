using Microsoft.EntityFrameworkCore;
using project2._0.Data;
using project2._0.Models.Entities;
using project2._0.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.SongRepository
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(ProjectContext context) : base(context) { }

        public async Task<List<Song>> GetAllSongsWithAlbumsAndArtists()
        {
            return await _context.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).ToListAsync();
        }

        public async Task<Song> GetByIdWithAlbum(int id)
        {
            return await _context.Songs.Include(s => s.Album).Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Song> GetByName(string name)
        {
            return await _context.Songs.Where(s => s.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
