using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    internal class Cliente:Ticket
    {
        long dni;
        static int numero;

        public Cliente(long d)
        {
            dni = d;
        }

        public override string ToString()
        {
            long d = dni;
            return base.ToString() + $" {d }";
        }
    }
}
