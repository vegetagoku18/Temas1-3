using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    internal class Cometa : Astro, ITerraformable
    {
        public Cometa(string nombre, double radio) : base(nombre, radio) //TODO revisar
        {

        }

        public bool EsHabitable()
        {
            return false;
        }
    }
}
