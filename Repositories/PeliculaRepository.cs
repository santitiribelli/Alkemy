using ChallengeAlkemy.Data;
using ChallengeAlkemy.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAlkemy.Repositories
{
    public static class PeliculaRepository
    {

        public static List<Pelicula> Getlist()
        {

            using (var context = new DisneyDbContext())
            {
                return (from p in context.peliculas
                        .Include("Personajes")
                        select p).ToList();
            }
        }

        public static List<Pelicula>GetPelicula(int id)
        {
            
            using (var context = new DisneyDbContext())
            {
                    return (from p in context.peliculas
                            .Include("Personajes")
                            where p.id == id
                           select p).ToList();
            }

        }
        public static List<Pelicula> GetPeliculaPorNombre(string name)
        {

            using (var context = new DisneyDbContext())
            {
                return (from p in context.peliculas
                        .Include("Personajes")
                        where p.titulo == name
                        select p).ToList();
            }
        }
        public static List<Pelicula> GetPeliculaPorGenero(int id)
        {

            using (var context = new DisneyDbContext())
            {
                return (from p in context.peliculas
                        .Include("Personajes")
                        where p.generoId == id
                        select p).ToList();
            }
        }
        public static List<Pelicula> GetPeliculaOrdenada()
        {

            using (var context = new DisneyDbContext())
            {
                return (from p in context.peliculas
                        .Include("Personajes")
                        
                        select p).ToList();
            }
        }

        public static void Insert(Pelicula varia)
        {

            using (var context = new DisneyDbContext())
            {
                context.peliculas.Add(varia);

                context.SaveChanges();
            }
        }
        public static void Update(Pelicula varia)
        {

            using (var context = new DisneyDbContext())
            {
                var viejo= context.peliculas.Attach(context.peliculas.Single(x=>x.id==varia.id));
                context.Entry(viejo).CurrentValues.SetValues(varia);
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context= new DisneyDbContext())
            {
                var valor = (from p in context.peliculas where p.id == id select p).FirstOrDefault();
                context.peliculas.Remove(valor);
                context.SaveChanges();
            }
        }
    }
}
