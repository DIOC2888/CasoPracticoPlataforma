// Program.cs (Consola simple)
// Generado con ayuda de Copilot: menú y filtro básico.
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    //Comentarios con ayuda de Copilot
    // Lista estática de cursos en memoria. Se usa una tupla para mantener
    // el ejemplo sencillo; para proyectos más grandes será mejor una clase o record.
    static List<(int id, string name, string area)> Courses = new() {
        (1, "Algoritmos I", "CS"),
        (2, "Introducción a la Programación", "CS"),
        (3, "Matemática Discreta", "Math"),
        (4, "Estructuras de Datos", "CS"),
        (5, "Probabilidades", "Math")
    };

    static void Main()
    {
        // Encabezado de la aplicación
        Console.WriteLine("Catálogo de Cursos - Demo");

        // Bucle principal: permitimos repetir acciones hasta que el usuario salga
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Opciones: (s) Buscar  (p) Paginación  (q) Salir");
            Console.Write("Selecciona una opción: ");
            var opt = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

            if (opt == "q")
            {
                // Salir de la aplicación
                break;
            }
            else if (opt == "s")
            {
                // Modo búsqueda por texto
                Console.Write("Buscar: ");
                var q = (Console.ReadLine() ?? "").Trim();

                // Si la consulta está vacía, mostramos todos los cursos por diseño
                var results = string.IsNullOrEmpty(q)
                    ? Courses
                    : Courses.Where(c => c.name.Contains(q, StringComparison.OrdinalIgnoreCase));

                PrintResults(results);
            }
            else if (opt == "p")
            {
                // Modo paginación simulada
                const int pageSize = 2; // tamaño de página fijo para el ejemplo
                int page = 0;
                int total = Courses.Count;
                int totalPages = (total + pageSize - 1) / pageSize;

                while (true)
                {
                    var pageItems = Courses.Skip(page * pageSize).Take(pageSize);
                    Console.WriteLine();
                    Console.WriteLine($"Página {page + 1}/{totalPages}");
                    PrintResults(pageItems);

                    Console.WriteLine("(n) Siguiente  (b) Anterior  (e) Salir paginación");
                    var cmd = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                    if (cmd == "n")
                    {
                        if (page < totalPages - 1) page++;
                    }
                    else if (cmd == "b")
                    {
                        if (page > 0) page--;
                    }
                    else
                    {
                        // cualquier otra opción sale del modo paginación
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor elige 's', 'p' o 'q'.");
            }
        }
    }

    // Método auxiliar para imprimir resultados y manejar el caso "sin coincidencias"
    static void PrintResults(IEnumerable<(int id, string name, string area)> results)
    {
        var any = false;
        foreach (var c in results)
        {
            any = true;
            Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
        }

        if (!any)
        {
            Console.WriteLine("No se encontraron cursos para la búsqueda especificada.");
        }
    }
}


   
