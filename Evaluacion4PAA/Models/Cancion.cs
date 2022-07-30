using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluacion4PAA.Models
{
    [Table("Cancion")] // Indicar la tabla al que pertenecerá la clase POCO
    public class Cancion
    {
        public int id_cancion { get; set; }
        public int id_cantautor { get; set; }
        public string nombre_cancion { get; set; }
        public int posicion { get; set; }

        // Relaciones
        public virtual Cantautor Cantautor { get; set; }
    }
}
