using lemosinfotec.biblia.Data.Contexto;
using lemosinfotec.biblia.Domain.Entities;
using lemosinfotec.biblia.Repository.Inrterface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lemosinfotec.biblia.Repository.Repository
{

    public class BibliaRepository : IBibliaService
    {
        private readonly DataContexto _context;

        public BibliaRepository(DataContexto context)
        {
            _context = context;
        }
        public async Task CreateBiblia(Biblia biblia)
        {
            _context.Biblia.Add(biblia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBiblia(Biblia biblia)
        {
            _context.Biblia.Remove(biblia);
            await _context.SaveChangesAsync();

        }

        public async Task<Biblia> GetBiblia(int Id)
        {
            var biblia = await _context.Biblia.FindAsync(Id);
            return biblia;
        }

        public async Task<IEnumerable<Biblia>> GetBibliaByNome(string nome)
        {
            IEnumerable<Biblia> biblias;
            if (!string.IsNullOrEmpty(nome))
            {
                biblias = await _context.Biblia.Where(n => n.Titulo.Contains(nome)).ToListAsync();
            }
            else
            {
                biblias = await GetBiblias();
            }
            return biblias;
        }

        public async Task<IEnumerable<Biblia>> GetBiblias()
        {
            return await _context.Biblia.ToListAsync();
        }

        public async Task UpdateBiblia(Biblia biblia)
        {
            _context.Entry(biblia).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }
    }
}
