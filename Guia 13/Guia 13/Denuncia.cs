using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    internal class Denuncia:Ticket
    {
        Vehiculo dominio;
        static int numero;

        public Denuncia (Vehiculo asegurado)
        {
            dominio = asegurado;
        }
        public override string ToString()
        {
            Vehiculo v = dominio;
            return base.ToString() + $"{v.ToString() }";
        }

    }
}
