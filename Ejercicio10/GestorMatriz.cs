using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio10.Program;

namespace Ejercicio10
{
    internal class GestorMatriz
    {
        private int[,] matriz;

        public int[,] Matriz
        {
            set { matriz = value; }
            get { return matriz; }
        }

        public GestorMatriz(int filas, int columnas)
        {
            Matriz = new int[filas, columnas];
            Random rand = new Random();
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Matriz[i, j] = rand.Next(-5, 21);
                }
            }
        }

        public GestorMatriz() : this(3, 4)
        {

        }

        public (int, bool) SumaFila(int fila)
        {
            if (fila < 0 || fila >= matriz.GetLength(0))
            {
                return (0, false);//TODO  {}
            }
            int suma = 0;
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                suma += matriz[fila, j];
            }
            return (suma, true);
        }

        public bool SumaColumna(int columna, out int suma)
        {
            suma = 0;
            if (columna < 0 || columna >= matriz.GetLength(1))
            {
                return false;
            }
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                suma += matriz[i, columna];
            }
            return true;
        }

        public int[,] SumarMatriz(object obj)
        {
            if (obj == null)
            {
                throw new MatrizException("La matriz no puede ser null");
            }

            int filas = Matriz.GetLength(0);
            int columnas = Matriz.GetLength(1);

            if (obj is int[,] matrizInt)
            {
                if (matrizInt.GetLength(0) != filas || matrizInt.GetLength(1) != columnas)
                {
                    throw new MatrizException("Las matrices no tienen las mismas dimensiones");
                }
                int[,] resultado = new int[filas, columnas];
                {
                    for (int i = 0; i < filas; i++) //TODO  {}
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            resultado[i, j] = matrizInt[i, j] + Matriz[i, j];
                        }
                    }
                }
                return resultado;
            }
            else
            {
                if (obj is GestorMatriz matrizGestor)
                {
                    if (matrizGestor.Matriz.GetLength(0) != filas || matrizGestor.Matriz.GetLength(1) != columnas)
                    {
                        throw new MatrizException("Las matrices no tienen las mismas dimensiones");
                    }
                    int[,] resultado = new int[filas, columnas];
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            resultado[i, j] = matrizGestor.Matriz[i, j] + Matriz[i, j];
                        }
                    }
                    return resultado;
                }
                else
                {
                    if (obj is double[,] matrizDouble)
                    {
                        if (matrizDouble.GetLength(0) != filas || matrizDouble.GetLength(1) != columnas)
                        {
                            throw new MatrizException("Las matrices no tienen  las mismas dimensiones");
                        }
                        int[,] resultado = new int[filas, columnas];
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                resultado[i, j] = (int)(matrizDouble[i, j] + Matriz[i, j]);
                            }
                        }
                        return resultado;
                    }
                    else
                    {
                        throw new MatrizException("El objeto no es una matriz válida");
                    }
                }
            }
        }
        public double[] medias(bool columnaFila)
        {
            double[] arrayMedias = new double[Matriz.GetLength(0)];
            if (columnaFila)
            {
                for (int i = 0; i < Matriz.GetLength(0); i++)
                {
                    //TODO usar sumafila y sumacolumna
                    arrayMedias[i] = SumaFila(i).Item1 / (double)Matriz.GetLength(1);
                }
                return arrayMedias;
            }

            arrayMedias = new double[Matriz.GetLength(1)];
            for (int i = 0; i < Matriz.GetLength(1); i++)
            {
                if (!SumaColumna(i, out int suma))
                {
                    throw new MatrizException("Error al sumar columna");
                }
                arrayMedias[i] = suma / (double)Matriz.GetLength(0);
            }
            return arrayMedias;
        }

        public static void MostrarMatriz<T>(T[,] matriz)
        {
            Console.Write("\n");
            Console.Write("     ");
            for (int i = 0; i < matriz.GetLength(1); i++)
            {
                char caracter = (char)('A' + i);
                Console.Write($"{caracter,5}");
            }
            Console.WriteLine();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.Write($"{i + 1,5}"); // Cabecera de fila
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}
