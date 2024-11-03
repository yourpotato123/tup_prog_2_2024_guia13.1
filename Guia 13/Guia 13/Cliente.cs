using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    [Serializable]
    internal class Cliente : Ticket
    {
        public long DNI { get;private set; }
        private static int numero=1;

        public Cliente(long d)
        {
            nroOrden = numero;
            numero++;
            DNI = d;
        }


        public override string ToString()
        {
            long d = DNI;
            return base.ToString() + $"Cliente {d}";
        }
    }
}
