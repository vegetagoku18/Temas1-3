using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    internal abstract class Astro
    {
        private string nombre;
        private double radio;
        public Astro() : this("Tierra",6378)
        {

        }
        public Astro(string nombre, double radio)
        {
            this.Nombre = nombre;
            this.Radio = radio;
        }
        public string Nombre  
        {
            set { nombre = value.ToUpper(); }
            get { return $"\"{nombre}\""; }
        }
        public double Radio
        {
            set { 
                if (value < 0) 
                    throw new ArgumentException("El radio no puede ser negativo");
                else 
                    radio = value;
            }
            get { return radio; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Astro)
            {
                Astro a = (Astro)obj;
                return this.nombre == a.nombre;
            } else if (obj is string)
            {
                string s = (string)obj;
                return this.nombre == s;
            }
            return false;
        }
    }
}
