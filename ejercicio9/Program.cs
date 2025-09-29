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

        //TODO evitar repetir codigo de peticion de datos

        public static string pedirIP()
        {
            string ip = Console.ReadLine();
          //  bool ipValida = Ordenador.IPValida(ip);
            while (!Ordenador.IPValida(ip))
            {
                Console.WriteLine("Dirección IP no válida. Introduce una dirección IP válida");
                ip = Console.ReadLine();
              //  ipValida = Ordenador.IPValida(ip);
            }
            return ip;
        }

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
            string ip = pedirIP();
            if (diccionario.ContainsKey(ip))
            {
                Console.WriteLine("Ya existe un ordenador con esa dirección IP");
            }
            else
            {
                diccionario.Add(ip, new Ordenador { Nombre = nombre, Ram = ram });
            }
        }

        public static void anhadirVariosOrdenadores()
        {
            Console.WriteLine("Escriba los ordenadores que quieras añadir con el patrón \n \"ip1:ram1,ip2:ram2...\"");
            string ordenadoresString = Console.ReadLine().Trim();
            string[] ordenadores = ordenadoresString.Split(',');
            foreach (var item in ordenadores)
            {
                string[] partesOrdenador = item.Split(':');
                if (partesOrdenador.Length != 2)
                {
                    Console.WriteLine($"El ordenador {item} no es válido");
                }
                else
                {
                    bool ramValida = int.TryParse(partesOrdenador[1], out int ram);
                    if (!ramValida || !Ordenador.IPValida(partesOrdenador[0]))
                    {
                        Console.WriteLine($"Alguno/s parámetros de {item} no son válidos");
                    }
                    else
                    {
                        if (diccionario.ContainsKey(partesOrdenador[0]))
                        {
                            Console.WriteLine("Ya existe un ordenador con esa dirección IP");
                        }
                        else
                        {
                        Ordenador ordenador = new Ordenador { Nombre = "sin definir", Ram = ram };
                            diccionario.Add(partesOrdenador[0], ordenador);
                        }
                    }
                }
            }
        }

        public static void eliminarOrdenador()
        {
            Console.WriteLine("Introduce la dirección IP del ordenador a eliminar");
            string ip = pedirIP();
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

        public static void mostrarListadoOrdenadores()
        {
            if (diccionario.Count == 0)
            {
                Console.WriteLine("No hay ordenadores en el listado");
            }
            else
            {
                foreach (var item in diccionario)
                {
                    Console.WriteLine($"IP: {item.Key}");
                }
            }
        }

        public static void mostrarOrdenador()
        {
            Console.WriteLine("Introduce la dirección IP del ordenador a mostrar");
            string ip = pedirIP();
            if (diccionario.ContainsKey(ip))
            {
                Ordenador ordenador = diccionario[ip];
                Console.WriteLine($"Nombre: {ordenador.Nombre}, RAM: {ordenador.Ram}GB, IP: {ip}");
            }
            else
            {
                Console.WriteLine("No existe ningún ordenador con esa dirección IP");
            }
        }
        static void Main(string[] args)
        {
            Ordenador ordenador1 = new Ordenador { Nombre = "Ofimatica", Ram = 4 };
            Ordenador ordenador2 = new Ordenador { Nombre = "Diseño", Ram = 16 };
            diccionario.Add("192.0.0.255", ordenador1);
            diccionario.Add("192.0.0.254", ordenador2);
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Elige una opción");
                Console.WriteLine("1. Añadir ordenador");
                Console.WriteLine("2. Añadir varios ordenadores");
                Console.WriteLine("3. Eliminar ordenador");
                Console.WriteLine("4. Mostrar listado de ordenadores");
                // TODO listado de IPs
                Console.WriteLine("5. Mostrar un ordenador");
                Console.WriteLine("6. Salir");

                string opcion = Console.ReadLine();
                bool opcionValida = int.TryParse(opcion, out int opcionInt);
                switch (opcionInt)
                {
                    case 1:
                        anhadirOrdenador();
                        break;
                    case 2:
                        anhadirVariosOrdenadores();
                        break;
                    case 3:
                        eliminarOrdenador();
                        break;
                    case 4:
                        mostrarListadoOrdenadores();
                        break;
                    case 5:
                        mostrarOrdenador();
                        break;
                    case 6:
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
