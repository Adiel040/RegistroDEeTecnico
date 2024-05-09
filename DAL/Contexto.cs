using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.Models;

namespace RegistroDEeTecnico.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options)
        : base(Options) { }

        public DbSet<Tecnicos> Tecnicos { get; set; }
    }
}
