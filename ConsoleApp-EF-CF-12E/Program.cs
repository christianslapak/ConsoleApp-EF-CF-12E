using System;
using System.Linq;

namespace ConsoleApp_EF_CF_12E
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new EscuelaContext();

            var losEstudiantes = context.Estudiante.ToList();

            foreach (var estu in losEstudiantes)
            {
                Console.WriteLine("Nombre estudiante: " + estu.Nombre + " - Edad: " + estu.Edad);
            }


            Console.WriteLine("Estudiantes Adolescentes - Expresion de Consulta de LinQ");
            var estudiantesTeens = from e in context.Estudiante where e.Edad < 22 select e;
            foreach (var item in estudiantesTeens)
            {
                Console.WriteLine("Nombre estudiante: " + item.Nombre + " - Edad: " + item.Edad);
            }

            Console.WriteLine("Estudiantes Adolescentes - Expresion LinQ tipo Lambda");
            var estudiantesTeens2 = context.Estudiante.Where(estu => estu.Edad < 22);
            foreach (var item in estudiantesTeens2)
            {
                Console.WriteLine("Nombre estudiante: " + item.Nombre + " - Edad: " + item.Edad);
            }

            Console.WriteLine("Estudiantes con M");
            var estudiantesM = from e in context.Estudiante where e.Nombre.StartsWith("M") orderby e.Edad descending select e;
            foreach (var item in estudiantesM)
            {
                Console.WriteLine("Nombre estudiante: " + item.Nombre + " - Edad: " + item.Edad);
            }


            context.Estudiante.Add(new Estudiante() { Nombre = "Nuevo", Edad = 25 });
            context.SaveChanges();
            Console.WriteLine("Nuevo estudiante agregado");
            

            var nuevaLista = context.Estudiante.ToList();

            foreach (var estu in nuevaLista)
            {
                Console.WriteLine("Nombre estudiante: " + estu.Nombre + " - Edad: " + estu.Edad);
            }
            Console.ReadKey();
        }
    }
}
