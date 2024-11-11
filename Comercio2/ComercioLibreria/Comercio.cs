using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    [Serializable]
    public class Comercio
    {
        List<Ticket> ListaAtendidos = new List<Ticket>();
        List<CuentaCorriente> cuentasCorrientes = new List<CuentaCorriente>();
        Queue<Pago> nuevoP = new Queue<Pago>();
        Queue<Cliente> nuevosClientes = new Queue<Cliente>();

        public CuentaCorriente this[int cc]
        {
            get
            {
                cuentasCorrientes.Sort();
                int a = cuentasCorrientes.BinarySearch(new CuentaCorriente(cc, null));
                if (a >= 0)
                {
                    return cuentasCorrientes[a];
                }
                return null;
            }
        }


        public void AgregarTicket(Ticket turno)
        {
            if (turno is Pago)
            {
                nuevoP.Enqueue((Pago)turno);
            }
            if (turno is Cliente)
            {
                nuevosClientes.Enqueue((Cliente)turno);
            }

        }
        public Ticket AtenderTicket(int tipoTicket)
        {
            Ticket ticket = null;
            if (tipoTicket == 0)
            {
                if (nuevosClientes.Count > 0)
                {
                    ticket = nuevosClientes.Dequeue();
                    ListaAtendidos.Add(ticket);
                }
            }
            if (tipoTicket == 1)
            {
                if (nuevoP.Count > 0)
                {
                    ticket = nuevoP.Dequeue();
                    ListaAtendidos.Add(ticket);
                }
            }
            return ticket;
        }
        public List<Ticket> VerAtendidos()
        {
            List<Ticket> resultado = null;
            if(ListaAtendidos != null)
            {
                ListaAtendidos.Sort();
                resultado = new List<Ticket>(ListaAtendidos);
                /*for (int i = 0; i < ListaAtendidos.Count; i++)
                {
                    resultado[i] = ListaAtendidos[i];
                }*/
                return resultado;
            }
            return resultado;
        }
        public Cliente VerCliente(string dni)
        {
            bool esta = false;
            Cliente cliente = new Cliente (dni);
            esta= nuevosClientes.Contains(cliente);
            if(esta)
            {
                return cliente;
            }
            else
            {
                cliente = new Cliente(null);
            }
            return cliente;
        }
        public void AgregarCuenta(CuentaCorriente cte)
        {
            cuentasCorrientes.Add(cte);
            cuentasCorrientes.Sort();
        }
    }
}
