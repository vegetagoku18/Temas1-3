using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        public static bool EsBisiesto(int anho)
        {
            if (anho % 4 == 0 && anho % 100 != 0 || anho % 400 == 0)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1. Comprobar si un año es bisiesto");
                Console.WriteLine("2. Suma de rango de numeros");
                Console.WriteLine("3. Todas las opciones");
                Console.WriteLine("4. Salir");
                bool opcion = int.TryParse(Console.ReadLine(), out int opcionSeleccionada);
                switch (opcionSeleccionada)
                {
                    case 1:
                        Console.WriteLine("Dime un año entre 1 y 10000");
                        bool esAnho = int.TryParse(Console.ReadLine(), out int anho);
                        esAnho = anho >= 1 && anho <= 10000 && EsBisiesto(anho);
                        while (!esAnho && (anho < 1 || anho > 10000))
                        {
                            Console.WriteLine("Año no válido, dime un año entre 1 y 10000");
                            esAnho = int.TryParse(Console.ReadLine(), out anho);
                            esAnho = anho >= 1 && anho <= 10000 && EsBisiesto(anho);
                        }
                        if (esAnho)
                        {
                            Console.WriteLine("El año es bisiesto");
                        }
                        else
                        {
                            Console.WriteLine("El año no es bisiesto");
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor elige una opción del 1 al 4.");
                        break;
                }
            }
        }
    }
}
