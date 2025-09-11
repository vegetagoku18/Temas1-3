using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce tu nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Introduce tu edad");
            string edadTexto = Console.ReadLine();
            int edad = 0;
            try
            {
                edad = int.Parse(edadTexto);
            }
            catch (FormatException)
            {
                bool esNumero = false;
                while (!esNumero)
                {
                    Console.WriteLine("Edad no válida, prueba otra vez");
                    edadTexto = Console.ReadLine();
                    esNumero = int.TryParse(edadTexto, out edad);
                }
            }
            Console.WriteLine("Introduce tu peso");
            string pesoTexto = Console.ReadLine();
            double peso = 0;
            try
            {
                peso = double.Parse(pesoTexto);
            }
            catch (FormatException)
            {
                bool esNumero = false;
                while (!esNumero)
                {
                    Console.WriteLine("Peso no válido, prueba otra vez");
                    pesoTexto = Console.ReadLine();
                    esNumero = double.TryParse(pesoTexto, out peso);
                }
            }
            Console.WriteLine($"Nombre:{nombre,12},Edad:{edad,4}\n\t Peso:{peso:F1}\n\"{nombre}\" \\{edad}\\"); //En el ejemplo pone el peso con 2 decimales en vez de la edad
        }
    }
}
