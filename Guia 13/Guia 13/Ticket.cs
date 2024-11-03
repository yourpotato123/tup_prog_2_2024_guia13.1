using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    abstract class Ticket : IComparable<Ticket>
    {
        public int nroOrden { get; protected set; }
        private DateTime fechaHora = DateTime.Now;

        public int VerNro()
        {
            return nroOrden;
        }

        public DateTime VerFechaHora()
        {
            return fechaHora;
        }

        public override string ToString()
        {
            int n = VerNro(); //DateTime f = VerFechaHora();
            return $"Turno {n} - ";
        }

        //Opcional, no se para que usarlo pero se ve lindo
        public int CompareTo(Ticket obj)
        {
            if (obj != null)
            { return nroOrden.CompareTo(obj.nroOrden); }
            return 1;
        }

    }
}
