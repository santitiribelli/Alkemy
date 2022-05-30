using ChallengeAlkemy.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Data
{
    public class DisneyDbContext :DbContext
    {
        public DisneyDbContext()
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DisneyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                );
        }
        public DbSet <Genero> generos { get; set; }

        public DbSet<Pelicula> peliculas { get; set; }

        public DbSet<Personaje> personajes { get; set; }

    }
}
