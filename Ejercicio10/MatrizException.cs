using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
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
}
