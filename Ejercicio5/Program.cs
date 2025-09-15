#define PRUEBA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {

        public static bool Factorial(int valor, out int total)
        {
            if (valor < 0 || valor > 10)
            {
                total = 0;
                return false;
            }
            total = 1;
            for (int i = 1; i <= valor; i++)
            {
                total *= i;
            }
            return true;
        }

        public static void Dibujar(int cant = 10)
        {
            Random random = new Random();
            for (int i = 0; i < cant; i++)
            {
                int x = random.Next(1, 21);
                int y = random.Next(1, 11);
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }

        static void Main(string[] args)
        {
#if PRUEBA
            Console.WriteLine("Dime un número entre 0 y 10");
            bool esNumero = int.TryParse(Console.ReadLine(), out int numero);
            while (!esNumero)
            {
                Console.WriteLine("Número no válido");
                esNumero = int.TryParse(Console.ReadLine(), out numero);
            }
            esNumero = Factorial(numero, out int total);
            string mensaje = esNumero ? "El factorial de " + numero + " es " + total : "Este programa no puede calcular el factorial de " + numero;
            Console.WriteLine(mensaje);
#else
            Console.WriteLine("¿Cuántos asteriscos quieres dibujar?");
            bool esNumero = int.TryParse(Console.ReadLine(), out int asteriscos);
            if (esNumero)
            {
                Dibujar(asteriscos);
            }
            else
            {
                Dibujar();
            }
#endif
            Console.ReadLine();
        }
    }
}
