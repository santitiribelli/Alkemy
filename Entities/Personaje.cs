using System.Collections.Generic;

namespace ChallengeAlkemy.Entities
{
    public class Personaje
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public int edad { get; set; }

        public string imagen { get; set; }

        public float peso { get; set; }

        public string historia { get; set; }

        public int? peliculaId { get; set; }

        public Pelicula Pelicula { get; set; }


    }
}
