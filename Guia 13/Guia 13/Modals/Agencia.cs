using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia_13
{
    [Serializable]
    internal class Agencia
    {
        public List<Ticket> ListaAtendidos = new List<Ticket>();
        public List<Vehiculo> ListaVehiculo = new List<Vehiculo>();
        public Queue<Denuncia> denuncia = new Queue<Denuncia>();
        public Queue<Cliente> nuevos = new Queue<Cliente>();


        public int CantidadAtendido { get { return ListaAtendidos.Count(); } }

        public Agencia()
        {
            Cliente c = new Cliente(59256894);
            Vehiculo v = new Vehiculo("ABC123", c);
            ListaVehiculo.Add(v);

            c = new Cliente(58746582);
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
            { 
                nuevos.Enqueue((Cliente)turno); 
            }

            if (turno != null && turno is Denuncia)
            { 
                denuncia.Enqueue((Denuncia)turno); 
            }
        }

        public Ticket AtenderTicket(int tipo)
        {
            Ticket t=null;
            if (tipo == 0)
            {
                if (denuncia.Count > 0)
                {
                    t = denuncia.Dequeue();
                    ListaAtendidos.Add(t);
                }
                else { MessageBox.Show("No hay Denuncias"); }
            }
            if (tipo == 1)
            {
                if (nuevos.Count > 0)
                {
                    t = nuevos.Dequeue();
                    ListaAtendidos.Add(t);
                }
                else { MessageBox.Show("No hay clientes"); }
            }
            return t;
        }
    }
}
