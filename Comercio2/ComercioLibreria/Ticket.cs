using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    [Serializable]
    abstract public class Ticket
    {
        private int contador = 1;
        protected int nroOrden;
        private DateTime fechaHora;

        public Ticket()
        {
            nroOrden = contador++;  //si esta despues primero asigna y luego aumenta
            fechaHora = DateTime.Now;
        }

        public int VerNro()
        {
            return nroOrden;
        }
        public DateTime VerFecha()
        {
            return fechaHora;
        }
        public abstract string CsvString();
    }
}
