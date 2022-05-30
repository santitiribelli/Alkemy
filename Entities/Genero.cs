using System.Collections.Generic;

namespace ChallengeAlkemy.Entities
{
    public class Genero
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; }

    }
}
