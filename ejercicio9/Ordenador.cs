using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio9
{
    internal class Ordenador
    {
        public string Nombre { set; get; }
        public int ram;

        public static bool IPValida(string ip)//TODO letras y numeros grandes
        {
            string[] partes = ip.Split('.');

            if (partes.Length != 4) return false;

            foreach (var item in partes)
            {
                if (int.Parse(item) < 0 || int.Parse(item) > 255)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
