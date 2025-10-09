using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    internal class Program//TODO estructuración correcta en clases
    {

        public static int pedirDato()
        {
            Console.WriteLine("Introduce un número entero:");
            string input = Console.ReadLine();
            int numero;
            while (!int.TryParse(input, out numero))
            {
                Console.WriteLine("Entrada inválida. Introduce un número entero:");
                input = Console.ReadLine();
            }
            return numero;
        }
        static void Main(string[] args)//TODO principal
        {
            GestorMatriz gm = new GestorMatriz();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Elige una opcion:");
                Console.WriteLine("1. Mostrar tabla");
                Console.WriteLine("2. Mostrar medias");
                Console.WriteLine("3. Suma de una fila");
                Console.WriteLine("4. Suma de una columna");
                Console.WriteLine("5. Incremento aleatorio");
                Console.WriteLine("6. Cambiar matriz");
                Console.WriteLine("7. Salir");

                string opcion = Console.ReadLine();
                bool esValido = int.TryParse(opcion, out int opcionInt);
                switch (opcionInt)
                {
                    case 1:
                        GestorMatriz.MostrarMatriz(gm.Matriz);
                        break;
                    case 2:
                        double[] mediasFilas = gm.medias(true);
                        Console.WriteLine("Medias de las filas:");
                        for (int i = 0; i < mediasFilas.Length; i++)
                        {
                            Console.WriteLine($"Fila {(i + 1)}: {mediasFilas[i]:F2}");
                        }
                        double[] mediasColumnas = gm.medias(false);
                        Console.WriteLine("Medias de las columnas:");
                        for (int i = 0; i < mediasFilas.Length; i++)
                        {
                            Console.WriteLine($"Columna {(i + 1)}: {mediasColumnas[i]:F2}");
                        }
                        break;
                    case 3:
                        int fila = pedirDato();
                        var (sumaFila, esValida) = gm.SumaFila(fila - 1);
                        string mensaje = esValida ? $"La suma de la fila {fila} es: {sumaFila}" : "No se ha podido hacer la suma";
                        Console.WriteLine(mensaje);
                        break;
                    case 4:
                        int columna = pedirDato();
                        string mensajeColumna = gm.SumaColumna(columna - 1, out int sumaColumna) ? $"La suma de la columna {columna} es: {sumaColumna}" : "No se ha podido hacer la suma";
                        Console.WriteLine(mensajeColumna);
                        break;
                    case 5:
                        GestorMatriz incremento = new GestorMatriz();
                        Random rand = new Random();
                        for (int i = 0; i < incremento.Matriz.GetLength(0); i++)
                        {
                            for (int j = 0; j < incremento.Matriz.GetLength(1); j++)
                            {
                                incremento.Matriz[i, j] = rand.Next(1, 11);
                            }
                        }
                        Console.WriteLine("Matriz original");
                        GestorMatriz.MostrarMatriz(gm.Matriz);
                        Console.WriteLine("Matriz incremento");
                        GestorMatriz.MostrarMatriz(incremento.Matriz);
                        Console.WriteLine("Matriz resultante");
                        GestorMatriz.MostrarMatriz(gm.SumarMatriz(incremento.Matriz));
                        break;
                    case 6:
                        Console.WriteLine("Primero las filas");
                        int filaCambio = pedirDato();
                        Console.WriteLine("Ahora las columnas");
                        int columnaCambio = pedirDato();
                        gm = new GestorMatriz(filaCambio, columnaCambio);
                        break;
                    case 7:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida, elige una opción del 1 al 7.");
                        break;
                }
            }
        }
    }
}
