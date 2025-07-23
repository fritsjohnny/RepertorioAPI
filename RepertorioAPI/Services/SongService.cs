using Microsoft.EntityFrameworkCore;
using RepertorioAPI.Data;
using RepertorioAPI.Models;

namespace RepertorioAPI.Services
{

    public interface ISongService
    {
        Task<List<Song>> GetAllAsync();
        Task<Song> GetByIdAsync(int id);
        Task<Song> CreateAsync(Song song);
        Task<bool> UpdateAsync(Song song);
        Task<bool> DeleteAsync(int id);
    }

    public class SongService : ISongService
    {
        private readonly RepertorioContext _context;

        public SongService(RepertorioContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song?> GetByIdAsync(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<Song> CreateAsync(Song song)
        {
            _context.Songs.Add(song);

            await _context.SaveChangesAsync();

            return song;
        }

        public async Task<bool> UpdateAsync(Song song)
        {
            if (!await _context.Songs.AnyAsync(s => s.Id == song.Id))
                return false;

            _context.Entry(song).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Song? song = await _context.Songs.FindAsync(id);

            if (song == null)
                return false;

            _context.Songs.Remove(song);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
