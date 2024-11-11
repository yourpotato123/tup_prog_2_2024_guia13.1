using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    [Serializable]
    public class Pago : Ticket
    {
        static int nroInicio;
        private CuentaCorriente ficha;

        public Pago(CuentaCorriente cte):base()

        {
            ficha = cte;
        }

        public void MontoPago(double valor) { }

        public override string ToString()
        {
            int nro = VerNro(); DateTime fecha = VerFecha();
            return $"PAGO: {nro} - {fecha} - {ficha.VerCliente()} - {ficha.VerNroCuenta()}";
        }

        public override string CsvString()                          //METODO IMPORTAR
        { 
            return $"PAGO: {VerNro()} - {ficha.VerNroCuenta()}";    //POLIMORFISMO
        }
    }
}
