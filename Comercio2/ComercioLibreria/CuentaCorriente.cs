using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    [Serializable]
    public class CuentaCorriente : IComparable<CuentaCorriente>

    {
        private int nroCuenta;
        private Cliente titular;
        private double saldo;

        public CuentaCorriente(int nro, Cliente titular)
        {
            nroCuenta = nro;
            this.titular = titular;
        }

        public Cliente VerCliente()
        {
            return titular;
        }
        public int VerNroCuenta()
        {
            return nroCuenta;
        }
        public void RegistrarPago(double monto) { }
        public void RegistrarVenta(double monto) { }

        public override string ToString()
        {
            return $"{VerNroCuenta()} - {VerCliente().DNI} - {saldo}";
        }
        public int CompareTo(CuentaCorriente other)
        {
            if (other != null)
            {
                return nroCuenta.CompareTo(other.nroCuenta);
            }
            return 1;
        }
    }
}
