using lemosinfotec.biblia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemosinfotec.biblia.Repository.Inrterface
{
    public interface IBibliaService
    {
        Task<IEnumerable<Biblia>> GetBiblias();

        Task<Biblia> GetBiblia(int Id);

        Task<IEnumerable<Biblia>> GetBibliaByNome(string nome);

        Task CreateBiblia(Biblia biblia);
        Task UpdateBiblia(Biblia biblia);
        Task DeleteBiblia(Biblia biblia);
    }
}
