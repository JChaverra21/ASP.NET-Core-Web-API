using System;
using Microsoft.EntityFrameworkCore;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            /* using (var db = new AppVentaCursosContext())
            {
                AsNoTracking() Evita almacenar en el cache la data que se esta devolviendo de la base de datos
                var cursos = db.Curso.AsNoTracking();  // Devuelve un IQueryable, Un arreglo de objetos
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo + " - " + curso.Descripcion);
                }
            } */

            // Relacion de uno a uno
            /* using (var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();

                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo + " - " + curso.PrecioPromocion.PrecioActual);
                }
            } */

            // Relacion de uno a muchos
            /* using (var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso.Include(c => c.ComentarioLista).AsNoTracking();

                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo);
                    foreach (var comentario in curso.ComentarioLista)
                    {
                        Console.WriteLine("***** " + comentario.ComentarioTexto);
                    }
                }
            } */

            // Relacion de muchos a muchos
            using (var db = new AppVentaCursosContext())
            {
                // Query que relaciona a las tres tablas, Curso llama a CursoInstructor y este a Instructor
                // Eager Loading (Carga ambiciosa)
                var cursos = db.Curso.Include(i => i.InstructorLink).ThenInclude(ci => ci.Instructor).AsNoTracking();

                // Select o Leazy Loading (Carga Perezosa)
                /*
                    var cursos = db.Curso.Select.(
                        c => new
                        {
                            c.Titulo,
                            c.Descripcion,
                        }
                    ).AsNoTracking();
                */

                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo);
                    foreach (var insLink in curso.InstructorLink)
                    {
                        Console.WriteLine("***** " + insLink.Instructor.Nombre + " " + insLink.Instructor.Apellidos);
                    }
                }
            }
        }
    }
}
