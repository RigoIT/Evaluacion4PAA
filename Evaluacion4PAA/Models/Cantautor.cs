using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluacion4PAA.Models
{
    [Table("Cantautor")] // Indicar la tabla al que pertenecerá la clase POCO
    public class Cantautor
    {
        public int id_cantautor { get; set; }
        public string nombre_cantautor { get; set; }
        public DateTime primera_presentacion { get; set; }
        public int canciones_publicadas { get; set; }
        public bool? vigencia { get; set; }

        // Relaciones
        public virtual ICollection<Cancion> Canciones { get; set; }
    }
}
