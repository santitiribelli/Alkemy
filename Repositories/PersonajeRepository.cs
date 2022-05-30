using ChallengeAlkemy.Data;
using ChallengeAlkemy.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAlkemy.Repositories
{
    
    
        public static class PersonajeRepository
        {

            public static List<Personaje> Getlist()
            {

                using (var context = new DisneyDbContext())
                {
                    return (from p in context.personajes
                            .Include("Pelicula")
                            select p).ToList();
                }
            }

            public static List<Personaje> GetPersonaje(int id)
            {

                using (var context = new DisneyDbContext())
                {
                    return (from p in context.personajes
                            .Include("Pelicula")
                            where p.id == id
                            select p).ToList();
                }

            }
            public static List<Personaje> GetPersonajePorNombre(string name)
            {

                using (var context = new DisneyDbContext())
                {
                    return (from p in context.personajes
                            .Include("Pelicula")
                            where p.nombre == name
                            select p).ToList();
                }
            }
            public static List<Personaje> GetPersonajePorEdad(int id)
            {

                using (var context = new DisneyDbContext())
                {
                    return (from p in context.personajes
                            .Include("Pelicula")
                            where p.edad == id
                            select p).ToList();
                }
            }
            public static List<Personaje> GetPersonajePorPelicula(int id)
            {

                using (var context = new DisneyDbContext())
                {
                    return (from p in context.personajes
                            .Include("Pelicula")
                            where p.peliculaId == id
                            select p).ToList();
                }
            }

            public static void Insert(Personaje varia)
            {

                using (var context = new DisneyDbContext())
                {
                    context.personajes.Add(varia);

                    context.SaveChanges();
                }
            }
            public static void Update(Personaje varia)
            {

                using (var context = new DisneyDbContext())
                {
                    var viejo = context.personajes.Attach(context.personajes.Single(x => x.id == varia.id));
                    context.Entry(viejo).CurrentValues.SetValues(varia);
                    context.SaveChanges();
                }
            }

            public static void Delete(int id)
            {
                using (var context = new DisneyDbContext())
                {
                    var valor = (from p in context.personajes where p.id == id select p).FirstOrDefault();
                    context.personajes.Remove(valor);
                    context.SaveChanges();
                }
            }
        }
    
}
