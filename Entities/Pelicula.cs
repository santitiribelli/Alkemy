using System;
using System.Collections.Generic;

namespace ChallengeAlkemy.Entities
{
    public class Pelicula
    {
        public int id { get; set; }

        public string titulo { get; set; }
        public string imagen { get; set; }
        public DateTime fechaCreacion { get; set; }

        public int clasificacion { get; set; }

        public int? generoId  { get; set; }


        public ICollection<Personaje> Personajes { get; set; }

        


    }
}
