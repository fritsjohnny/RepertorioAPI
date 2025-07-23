using Microsoft.EntityFrameworkCore;
using RepertorioAPI.Data;
using RepertorioAPI.Models;

namespace RepertorioAPI.Services
{
    public interface IRepertoireSongService
    {
        Task<List<RepertoireSong>> GetAllAsync();
        Task<RepertoireSong?> GetByIdAsync(int id);
        Task<RepertoireSong> CreateAsync(RepertoireSong repertoireSong);
        Task<bool> UpdateAsync(RepertoireSong repertoireSong);
        Task<bool> DeleteAsync(int id);
    }

    public class RepertoireSongService : IRepertoireSongService
    {
        private readonly RepertorioContext _context;

        public RepertoireSongService(RepertorioContext context)
        {
            _context = context;
        }

        public async Task<List<RepertoireSong>> GetAllAsync()
        {
            return await _context.RepertoireSongs.ToListAsync();
        }

        public async Task<RepertoireSong?> GetByIdAsync(int id)
        {
            return await _context.RepertoireSongs.FindAsync(id);
        }

        public async Task<RepertoireSong> CreateAsync(RepertoireSong repertoireSong)
        {
            _context.RepertoireSongs.Add(repertoireSong);

            await _context.SaveChangesAsync();

            return repertoireSong;
        }

        public async Task<bool> UpdateAsync(RepertoireSong repertoireSong)
        {
            if (!await _context.RepertoireSongs.AnyAsync(r => r.Id == repertoireSong.Id))
                return false;

            _context.Entry(repertoireSong).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            RepertoireSong? entity = await _context.RepertoireSongs.FindAsync(id);

            if (entity == null)
                return false;

            _context.RepertoireSongs.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
