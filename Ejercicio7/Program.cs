#define EJERCICIO8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    internal class Program
    {
        // Funciones del Ejercicio 8

        public static Planeta crearPlaneta()
        {
            Planeta planeta = new Planeta();
            Console.WriteLine("Introduce el nombre del planeta:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce el radio del planeta (en km):");
            double radio = 0;
            try
            {
                bool radioValido = double.TryParse(Console.ReadLine(), out radio);
                while (!radioValido)
                {
                    Console.WriteLine("Radio inválido. Introduce un número positivo:");
                    radioValido = double.TryParse(Console.ReadLine(), out radio);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("¿Es un planeta gaseoso? (si/no):");
            string gaseosoInput = Console.ReadLine().ToLower();
            bool gaseoso = gaseosoInput == "si";
            Console.WriteLine("Introduce el número de satélites:");
            bool satelitesValidos = int.TryParse(Console.ReadLine(), out int numSatelites);
            while (!satelitesValidos)
            {
                Console.WriteLine("Número de satélites inválido. Introduce un número entero no negativo:");
                satelitesValidos = int.TryParse(Console.ReadLine(), out numSatelites);
            }
            planeta.Nombre = nombre;
            planeta.Radio = radio;
            planeta.Gaseoso = gaseoso;
            planeta.NumSatelites = numSatelites;
            return planeta;
        }

        public static Cometa crearCometa()
        {
            Cometa cometa = new Cometa("", 0);
            Console.WriteLine("Introduce el nombre del cometa:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce el radio del cometa (en km):");
            double radio = 0;
            try
            {
                bool radioValido = double.TryParse(Console.ReadLine(), out radio);
                while (!radioValido)
                {
                    Console.WriteLine("Radio inválido. Introduce un número positivo:");
                    radioValido = double.TryParse(Console.ReadLine(), out radio);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            cometa.Nombre = nombre;
            cometa.Radio = radio;
            return cometa;
        }

        public static void mostrarDatos(List<Astro> astros)
        {
            foreach (Astro astro in astros)
            {

                if (astro is Planeta planeta)
                {

                    Console.WriteLine(planeta.ToString());
                }
                else if (astro is Cometa cometa)
                {
                    Console.WriteLine(cometa.Nombre);
                }
                if (astro is ITerraformable terraformable)
                {
                    Console.WriteLine($"¿Es habitable? {(terraformable.EsHabitable() ? "Sí" : "No")}");
                }
            }
        }

        static void ModificarSatelites(List<Astro> astros)
        {
            Console.Write("Nombre del astro: ");
            string nombre = Console.ReadLine();

            // Recuerda que en la propiedad Nombre añades comillas y mayúsculas,
            // por eso buscamos con ese formato:
            string nombreBusqueda = $"\"{nombre.ToUpper()}\"";

            // Usamos IndexOf pasando el string para buscar gracias a Equals sobrecargado
            //int index = astros.IndexOf(new Astro("Tierra", 6378));

            if (index == -1)
            {
                Console.WriteLine("Astro no encontrado.");
                return;
            }

            if (astros[index] is Planeta planeta)
            {
                Console.Write("¿Deseas incrementar (i) o decrementar (d) el número de satélites? ");
                string opcion = Console.ReadLine().ToLower();

                if (opcion == "i")
                {
                    planeta.NumSatelites++;
                    Console.WriteLine("Número de lunas incrementado.");
                }
                else if (opcion == "d")
                {
                    if (planeta.NumSatelites > 0)
                    {
                        planeta.NumSatelites--;
                        Console.WriteLine("Número de lunas decrementado.");
                    }
                    else
                    {
                        Console.WriteLine("El planeta no tiene lunas para decrementar.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
            else
            {
                Console.WriteLine("El astro no es un planeta.");
            }
        }

        static void Main(string[] args)
        {
#if EJERCICIO7

            Planeta planeta = new Planeta("Jupiter", 69911, true, 97);
            Planeta planeta2 = new Planeta();
            planeta2.Nombre = "Saturnalia";
            Cometa cometa = new Cometa("Halley", 11);
            Console.WriteLine($"El planeta {planeta.Nombre} es habitable? {planeta.EsHabitable()}");
            Console.WriteLine(planeta.NumSatelites);
            planeta++;
            Console.WriteLine(planeta.NumSatelites);
            planeta--;
            Console.WriteLine(planeta.NumSatelites);
            Console.WriteLine($"El planeta {planeta.Nombre} es igual al planeta {planeta2.Nombre}? " +
                $"{Astro.Equals(planeta, planeta2)}");
            Console.WriteLine(planeta.ToString());
            Console.WriteLine($"El cometa {cometa.Nombre} es habitable? {cometa.EsHabitable()}");
            Console.ReadKey();
#else
            List<Astro> astros = new List<Astro>();
            astros.Add(new Planeta("Tierra", 6378, false, 1));
            astros.Add(new Cometa("Halley", 11));
            astros.Add(new Planeta("Jupiter", 69911, true, 97));
            astros.Add(new Cometa("Encke", 4));
            astros.Add(new Planeta("Marte", 3390, false, 2));
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Elige una opción");
                Console.WriteLine("1. Crear planeta");
                Console.WriteLine("2. Crear cometa");
                Console.WriteLine("3. Mostrar datos");
                Console.WriteLine("4. Añadir o eliminar satélite a un planeta");
                Console.WriteLine("5. Eliminar los no terraformables");
                Console.WriteLine("6. Salir");
                bool opcionValida = int.TryParse(Console.ReadLine(), out int opcion);
                switch (opcion)
                {
                    case 1:
                        Planeta nuevoPlaneta = crearPlaneta();
                        astros.Add(nuevoPlaneta);
                        break;
                    case 2:
                        Cometa nuevoCometa = crearCometa();
                        astros.Add(nuevoCometa);
                        break;
                    case 3:
                        mostrarDatos(astros);
                        break;
                    case 4:
                        ModificarSatelites(astros);
                        break;
                    case 5:
                        break;
                    case 6:
                        salir = true;
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;

                }
            }
#endif
        }
    }
}
