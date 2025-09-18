using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    internal class Program
    {
        public class MatrizException : Exception
        {
            public MatrizException() : base("La matriz no es válida")
            {
            }
            public MatrizException(string message) : base(message)
            {
            }
        }
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
                if (fila < 0 || fila >= matriz.GetLength(0)) return (0, false);
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
                if (columna < 0 || columna >= matriz.GetLength(1)) return false;
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    suma += matriz[i, columna];
                }
                return true;
            }

            public void SumarMatriz(object obj)
            {
                if (obj == null)
                {
                    throw new MatrizException ("La matriz no puede ser null");
                }
                int filas = this.matriz.GetLength(0);
                int columnas = this.matriz.GetLength(1);

                if (obj is int[,])
                {
                    int[,] otraMatriz = (int[,])obj;
                    if (otraMatriz.GetLength(0) != filas || otraMatriz.GetLength(1) != columnas)
                    {
                        throw new MatrizException("Las matrices no tienen las mismas dimensiones");
                    }

                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            this.matriz[i, j] += otraMatriz[i, j];
                        }
                    }
                }
                else
                {
                    if (obj is GestorMatriz)
                    {
                        GestorMatriz gestor = (GestorMatriz)obj;
                        if (gestor.Matriz.GetLength(0) != filas || gestor.Matriz.GetLength(1) != columnas)
                        {
                            throw new MatrizException("Las matrices no tienen las mismas dimensiones");
                        }
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                this.matriz[i, j] += gestor.Matriz[i, j];
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
