using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    internal class Agencia
    {
        public List<Ticket> ListaAtendidos = new List<Ticket>();
        public List<Vehiculo> ListaVehiculo = new List<Vehiculo>();
        public Queue<Denuncia> denuncia = new Queue<Denuncia>();
        public Queue<Cliente> nuevos = new Queue<Cliente>();

       
        public int CantidadAtendido { get { return ListaAtendidos.Count(); } }

        public Agencia()
        {
            Cliente c = new Cliente(39256894);
            Vehiculo v = new Vehiculo("ABC123", c);
            ListaVehiculo.Add(v);

            c = new Cliente(38746582);
            v = new Vehiculo("QWE789", c);
            ListaVehiculo.Add(v);

        }

        public Ticket this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < CantidadAtendido)
                { return ListaAtendidos[idx]; }
                return null;
            }
        }

        public void AgregarTicket(Ticket turno)
        {
            if (turno != null && turno is Cliente)
            { nuevos.Enqueue((Cliente)turno); }

            if (turno != null && turno is Denuncia)
            { denuncia.Enqueue((Denuncia)turno); }
        }

        public void AtenderTicket(int tipo)
        {
            Ticket t;
            if (tipo == 0)
            {
                t = nuevos.Peek();
                ListaAtendidos.Add(t);
                nuevos.Dequeue();
            }
            if (tipo == 1)
            {
                t = denuncia.Peek();
                ListaAtendidos.Add(t);
                denuncia.Dequeue();
            }

        }
    }
}
