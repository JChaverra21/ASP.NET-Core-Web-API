using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeerData
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Precio PrecioPromocion { get; set; }

        // Propiedad que representa la Relacion de uno a muchos entre Curso y Comentario
        public ICollection<Comentario> ComentarioLista { get; set; }

        // Propiedad que representa la Relacion de uno a uno entre Curso y Instructor
        public ICollection<CursoInstructor> InstructorLink { get; set; }
    }
}