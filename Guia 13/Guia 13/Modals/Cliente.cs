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
        private long dni;
        public long DNI
        {
            get { return dni; }
            private set
            {
                if (dni > 50000000)
                {
                    dni = value;
                }
            }
        }
        private static int numero = 1;

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
