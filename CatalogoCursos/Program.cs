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
        (3, "Matemática Discreta", "Math")
    };

    static void Main()
    {
        // Encabezado y prompt al usuario
        Console.WriteLine("Catálogo de Cursos - Demo");
        Console.Write("Buscar: ");

        // Leer la entrada del usuario. Console.ReadLine puede devolver null,
        // por eso usamos el operador ?? para garantizar una cadena no nula.
        // También aplicamos Trim() para ignorar espacios en los extremos.
        var q = (Console.ReadLine() ?? "").Trim();

        // Filtrar la lista usando Contains con comparación que ignora mayúsculas.
        // Nota: Contains con StringComparison requiere .NET Core / .NET 5+.
        var results = Courses.Where(c => c.name.Contains(q,
           StringComparison.OrdinalIgnoreCase));

        // Si la consulta está vacía, mostramos todos los cursos (comportamiento
        // deliberado) pero podríamos cambiarlo para pedir una búsqueda válida.
        var any = false;
        foreach (var c in results)
        {
            any = true;
            Console.WriteLine($"[{c.id}] {c.name} - {c.area}");
        }

        // Si no hubo coincidencias, informamos al usuario.
        if (!any)
        {
            Console.WriteLine("No se encontraron cursos para la búsqueda especificada.");
        }
    }
}


   
