using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.Models;

namespace RegistroDEeTecnico.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
     : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales del modelo
        }
        public DbSet<IncentivosTecnicos> IncentivosTecnicos { get; set; }
        public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set; }
    }
}
