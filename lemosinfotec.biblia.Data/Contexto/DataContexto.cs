using lemosinfotec.biblia.Data.DataConfig;
using lemosinfotec.biblia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lemosinfotec.biblia.Data.Contexto
{
    public class DataContexto:DbContext
    {
        public DbSet<Biblia> Biblia { get; set; }
        public DataContexto(DbContextOptions<DataContexto> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Biblia>(new BibliaConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
