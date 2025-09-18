using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio9
{
    internal class Program
    {
        static Dictionary<string, Ordenador> diccionario = new Dictionary<string, Ordenador>();

        public static void anhadirOrdenador()
        {
            Console.WriteLine("Introduce el nombre del ordenador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduce la cantidad de RAM (GB)");
            string ramString = Console.ReadLine();
            bool ramValida = int.TryParse(ramString, out int ram);
            while (!ramValida || ram <= 0)
            {
                Console.WriteLine("Cantidad de RAM no válida. Introduce un número");
                ramString = Console.ReadLine();
                ramValida = int.TryParse(ramString, out ram);
            }
            Console.WriteLine("Introduce la dirección IP");
            string ip = Console.ReadLine();
            bool ipValida = Ordenador.IPValida(ip);
            while (!ipValida)
            {
                Console.WriteLine("Dirección IP no válida. Introduce una dirección IP válida");
                ip = Console.ReadLine();
                ipValida = Ordenador.IPValida(ip);
            }
            if (diccionario.ContainsKey(ip))
            {
                Console.WriteLine("Ya existe un ordenador con esa dirección IP");
            }
            else
            {
                diccionario.Add(ip, new Ordenador { nombre = nombre, ram = ram });
            }
        }

        public static void eliminarOrdenador()
        {
            Console.WriteLine("Introduce la dirección IP del ordenador a eliminar");
            string ip = Console.ReadLine();
            bool ipValida = Ordenador.IPValida(ip);
            while (!ipValida)
            {
                Console.WriteLine("Dirección IP no válida. Introduce una dirección IP válida");
                ip = Console.ReadLine();
                ipValida = Ordenador.IPValida(ip);
            }
            if (diccionario.ContainsKey(ip))
            {
                diccionario.Remove(ip);
                Console.WriteLine("Ordenador eliminado");
            }
            else
            {
                Console.WriteLine("No existe ningún ordenador con esa dirección IP");
            }
        }

        public static void mostrarOrdenador()
        {
            Console.WriteLine("Introduce la dirección IP del ordenador a mostrar");
            string ip = Console.ReadLine();
            bool ipValida = Ordenador.IPValida(ip);
            while (!ipValida)
            {
                Console.WriteLine("Dirección IP no válida. Introduce una dirección IP válida");
                ip = Console.ReadLine();
                ipValida = Ordenador.IPValida(ip);
            }
            if (diccionario.ContainsKey(ip))
            {
                Ordenador ordenador = diccionario[ip];
                Console.WriteLine($"Nombre: {ordenador.nombre}, RAM: {ordenador.ram}GB, IP: {ip}");
            }
            else
            {
                Console.WriteLine("No existe ningún ordenador con esa dirección IP");
            }
        }
        static void Main(string[] args)
        {

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Elige una opción");
                Console.WriteLine("1. Añadir ordenador");
                Console.WriteLine("2. Eliminar ordenador");
                Console.WriteLine("3. Mostrar un ordenador");
                Console.WriteLine("4. Salir");

                string opcion = Console.ReadLine();
                bool opcionValida = int.TryParse(opcion, out int opcionInt);
                switch (opcionInt)
                {
                    case 1:
                        anhadirOrdenador();
                        break;
                    case 2:
                        eliminarOrdenador();
                        break;
                    case 3:
                        mostrarOrdenador();
                        break;
                    case 4:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }
}
