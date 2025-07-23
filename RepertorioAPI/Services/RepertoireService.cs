using Microsoft.EntityFrameworkCore;
using RepertorioAPI.Data;
using RepertorioAPI.Models;

namespace RepertorioAPI.Services
{
    public interface IRepertoireService
    {
        Task<List<Repertoire>> GetAllAsync();
        Task<Repertoire?> GetByIdAsync(int id);
        Task<Repertoire> CreateAsync(Repertoire repertoire);
        Task<bool> UpdateAsync(Repertoire repertoire);
        Task<bool> DeleteAsync(int id);
    }

    public class RepertoireService : IRepertoireService
    {
        private readonly RepertorioContext _context;

        public RepertoireService(RepertorioContext context)
        {
            _context = context;
        }

        public async Task<List<Repertoire>> GetAllAsync()
        {
            return await _context.Repertoires.Include(r => r.RepertoireSongs)
                                             .ThenInclude(rs => rs.Song) 
                                             .ToListAsync();
        }

        public async Task<Repertoire?> GetByIdAsync(int id)
        {
            return await _context.Repertoires.Include(r => r.RepertoireSongs)
                                             .ThenInclude(rs => rs.Song)
                                             .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Repertoire> CreateAsync(Repertoire repertoire)
        {
            _context.Repertoires.Add(repertoire);

            await _context.SaveChangesAsync();

            return repertoire;
        }

        public async Task<bool> UpdateAsync(Repertoire repertoire)
        {
            if (!await _context.Repertoires.AnyAsync(r => r.Id == repertoire.Id))
                return false;

            _context.Entry(repertoire).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Repertoire? rep = await _context.Repertoires.FindAsync(id);

            if (rep == null)
                return false;

            _context.Repertoires.Remove(rep);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
