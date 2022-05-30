using ChallengeAlkemy.Entities;
using ChallengeAlkemy.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAlkemy.BusinessLogic
{
    public static class PeliculaRepositoryAdmin
    {

       
        public static object GetPeliculas()
        {
            return PeliculaRepository.Getlist().Select(pe => new 
            {
                Imagen=pe.imagen,
                Titulo=pe.titulo,
                FechaDeCreacion=pe.fechaCreacion
                
            }).ToList();
        }

        public static object GetDetails(int id)
        {
            var Peli = PeliculaRepository.GetPelicula(id);
            return Peli.Select
                (pe => new
                {
                 Imagen = pe.imagen,
                 Titulo = pe.titulo,
                 FechaDecreacion = pe.fechaCreacion,
                 Clasifiacion = pe.clasificacion,
                 Personajes = pe.Personajes.Where(x => x.peliculaId == pe.id).Select(x => x.nombre)


         });
        }
        public static object GetPeliculaPorNombre(string name)
        {
            var Peli = PeliculaRepository.GetPeliculaPorNombre(name);
            return Peli.Select
                (pe => new
                {
                    Imagen = pe.imagen,
                    Titulo = pe.titulo,
                    FechaDecreacion = pe.fechaCreacion,
                    Clasifiacion = pe.clasificacion,
                    Personajes = pe.Personajes.Where(x => x.peliculaId == pe.id).Select(x => x.nombre)
                });
        }
        public static object GetPeliculaPorGenero(string name)
        {
            var Peli = PeliculaRepository.GetPeliculaPorNombre(name);
            return Peli.Select
                (pe => new
                {
                    Imagen = pe.imagen,
                    Titulo = pe.titulo,
                    FechaDecreacion = pe.fechaCreacion,
                    Clasifiacion = pe.clasificacion,
                    Personajes = pe.Personajes.Where(x => x.peliculaId == pe.id).Select(x => x.nombre)
                });
        }
        public static object GetPeliculaOrdenada(string order)
        {
            var Peli = PeliculaRepository.GetPeliculaOrdenada();
            if (order == "ASC")
            {


                return Peli.Select
                    (pe => new
                    {
                        Imagen = pe.imagen,
                        Titulo = pe.titulo,
                        FechaDecreacion = pe.fechaCreacion,
                        Clasifiacion = pe.clasificacion,
                        Personajes = pe.Personajes.Where(x => x.peliculaId == pe.id).Select(x => x.nombre)
                    }).OrderBy(x => x.FechaDecreacion);
            }
            else if(order == "DESC")
            {
                return Peli.Select
                (pe => new
                {
                    Imagen = pe.imagen,
                    Titulo = pe.titulo,
                    FechaDecreacion = pe.fechaCreacion,
                    Clasifiacion = pe.clasificacion,
                    Personajes = pe.Personajes.Where(x => x.peliculaId == pe.id).Select(x => x.nombre)
                }).OrderByDescending(x => x.FechaDecreacion);
            }
            return Peli;
        }



        public static void InsertOrUpdate(Pelicula model)
        {
            
            if (model.id > 0)
            {
                var original = PeliculaRepository.GetPelicula(model.id);
                PeliculaRepository.Update(model);
            }
            else
            {
                PeliculaRepository.Insert(model);
            }
          
        }

        public static void Delete(int id)
        {
            PeliculaRepository.Delete(id);
        }

    }
}