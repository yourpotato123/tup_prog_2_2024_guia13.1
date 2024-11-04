using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    [Serializable]
    internal class Denuncia:Ticket
    {
        public Vehiculo dominio { get; private set; }
        private static int numero=1;

        public Denuncia (Vehiculo asegurado)
        {
            nroOrden = numero;
            numero++;
            dominio = asegurado;
            
        }
        public override string ToString()
        {
            Vehiculo v = dominio;
            return base.ToString() + $"Denuncia - {v.ToString() }";
        }

    }
}
