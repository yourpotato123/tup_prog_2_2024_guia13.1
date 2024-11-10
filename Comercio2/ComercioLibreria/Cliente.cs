using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    [Serializable]
    public class Cliente : Ticket
    {
        static int nroInicio;
        private int dni;
        public int DNI
        {
            get
            {
                if (dni <= 3000000 && dni <= 45000000)
                {
                    return dni;
                }
                else
                {
                    throw new DniInvalidoException();
                }
            }
            set { dni = value; }
        }


        public Cliente(string dni):base()
        {
            this.dni = Convert.ToInt32(dni); //hacer excepcion
        }

        public override string ToString()
        {
            int nro = VerNro(); DateTime fecha = VerFecha();
            int d = dni; 
            return $"CLIENTE: {nro} - {fecha} - {d}";
        }
        public override string CsvString()
        {
            return $"CLIENTE: {VerNro()} - {DNI}";
        }


    }
}
