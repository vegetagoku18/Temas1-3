using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4 //menos código en peticion datos
{
    internal class Program
    {
        public static bool EsBisiesto(int anho)
        {
            return (anho % 4 == 0 && anho % 100 != 0 || anho % 400 == 0);
        }

        public static int? SumaRango(int valor1, int valor2)
        {
            int suma = 0;
            if (valor1 > valor2)
            {
                return null;
            }
            for (int i = valor1 + 1; i < valor2; i++)
            {
                suma += i;
            }
            return suma;
        }

        public static int PedirDato()
        {
            Console.WriteLine("Dime un valor entre 1 y 10000");
            bool esValido = int.TryParse(Console.ReadLine(), out int anho);
            esValido = anho >= 1 && anho <= 10000;
            Console.WriteLine(esValido);
            while (!esValido )
            {
                Console.WriteLine("Año no válido, dime un año entre 1 y 10000");
                esValido = int.TryParse(Console.ReadLine(), out anho);
                esValido = anho >= 1 && anho <= 10000 ;
            }
            return anho;
        }
        static void Main(string[] args)
        {
            bool exit = false;
            bool opc3 = false;
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
                        int anho = PedirDato();
                        string mensaje = EsBisiesto(anho) ? "El año " + anho + " es bisiesto" : "El año " + anho + " no es bisiesto";
                        Console.WriteLine(mensaje);
                        if (opc3)
                        {
                            opc3 = false;
                            Console.WriteLine("Opcion 2");
                            goto case 2;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Valor 1");
                        int numero1 = PedirDato();
                        Console.WriteLine("Valor 2");
                        int numero2 = PedirDato();
                        int? suma = SumaRango(numero1, numero2);
                        string mensajeSuma = suma == null ? "El primer valor debe ser menor que el segundo" : $"La suma de los números entre {numero1} y {numero2} es {suma}";
                        Console.WriteLine(mensajeSuma);
                        break;
                    case 3:
                        opc3 = true;
                        goto case 1;
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
