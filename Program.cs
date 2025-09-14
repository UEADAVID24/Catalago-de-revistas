using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Catálogo de revistas
        static List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Time",
            "Scientific American",
            "Nature",
            "Forbes",
            "Popular Science",
            "Harvard Business Review",
            "PC World",
            "Sports Illustrated",
            "The Economist"
        };

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== CATÁLOGO DE REVISTAS =====");
                Console.WriteLine("1. Buscar revista (iterativo)");
                Console.WriteLine("2. Buscar revista (recursivo)");
                Console.WriteLine("3. Mostrar catálogo");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Validación de entrada
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1;
                }

                switch (opcion)
                {
                    case 1:
                        BuscarIterativo();
                        break;
                    case 2:
                        BuscarRecursivo();
                        break;
                    case 3:
                        MostrarCatalogo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }

        // Método para mostrar el catálogo
        static void MostrarCatalogo()
        {
            Console.WriteLine("\nCatálogo de revistas:");
            foreach (var revista in catalogo)
            {
                Console.WriteLine($"- {revista}");
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        // Búsqueda iterativa
        static void BuscarIterativo()
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = false;
            foreach (var revista in catalogo)
            {
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    break;
                }
            }

            Console.WriteLine(encontrado ? "Encontrado ✅" : "No encontrado ❌");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        // Búsqueda recursiva
        static void BuscarRecursivo()
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = BuscarRecursivoHelper(titulo, 0);

            Console.WriteLine(encontrado ? "Encontrado ✅" : "No encontrado ❌");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        // Función recursiva para recorrer la lista
        static bool BuscarRecursivoHelper(string titulo, int index)
        {
            if (index >= catalogo.Count) return false;
            if (catalogo[index].Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;
            return BuscarRecursivoHelper(titulo, index + 1);
        }
    }
}
