using ChallengeAlkemy.Entities;
using ChallengeAlkemy.Repositories;
using System.Linq;

namespace ChallengeAlkemy.BusinessLogic
{
      
        public static class PersonajeRepositoryAdmin
        {


            public static object GetPersonajes()
            {
                return PersonajeRepository.Getlist().Select(pe => new
                {
                    Imagen = pe.imagen,
                    Nombre = pe.nombre,
                    

                }).ToList();
            }

            public static object GetDetails(int id)
            {
                var Peli = PersonajeRepository.GetPersonaje(id);
                return Peli.Select
                    (pe => new
                    {
                        Imagen = pe.imagen,
                        Nombre = pe.nombre,
                        Edad = pe.edad,
                        Peso = pe.peso,
                        Historia = pe.historia,
                        Pelicula = pe.Pelicula.titulo


                    });
            }
            public static object GetPersonajePorNombre(string name)
            {
                var Peli = PersonajeRepository.GetPersonajePorNombre(name);
                return Peli.Select
                    (pe => new
                    {
                        Imagen = pe.imagen,
                        Nombre = pe.nombre,
                        Edad = pe.edad,
                        Peso = pe.peso,
                        Historia = pe.historia,
                        Pelicula = pe.Pelicula.titulo
                    });
            }
            public static object GetPersonajePorEdad(int edad)
            {
                var Peli = PersonajeRepository.GetPersonajePorEdad(edad);
                return Peli.Select
                    (pe => new
                    {
                        Imagen = pe.imagen,
                        Nombre = pe.nombre,
                        Edad = pe.edad,
                        Peso = pe.peso,
                        Historia = pe.historia,
                        Pelicula = pe.Pelicula.titulo
                    });
            }
            public static object GetPersonajePorPelicula(int id)
            {
                var Peli = PersonajeRepository.GetPersonajePorPelicula(id);       
                {
                return Peli.Select
                    (pe => new
                    {
                        Imagen = pe.imagen,
                        Nombre = pe.nombre,
                        Edad = pe.edad,
                        Peso = pe.peso,
                        Historia = pe.historia,
                        Pelicula = pe.Pelicula.titulo
                    });
                }
                
            }



            public static void InsertOrUpdate(Personaje model)
            {

                if (model.id > 0)
                {
                    var original = PersonajeRepository.GetPersonaje(model.id);
                    PersonajeRepository.Update(model);
                }
                else
                {
                    PersonajeRepository.Insert(model);
                }

            }

            public static void Delete(int id)
            {
                PersonajeRepository.Delete(id);
            }

        }
    
}
