using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia_13
{
    public partial class Form1 : Form
    {
        Agencia a = new Agencia();
        FileStream archivo;
        StreamReader lector;
        StreamWriter escritor;

        public Form1()
        {
            InitializeComponent();
        }

 

        private void btTicket_Click(object sender, EventArgs e)
        {
            long dni = Convert.ToInt32(tbDNI.Text);
            Cliente c = new Cliente(dni);
            Vehiculo v;
            string patente;

            if (rbDenuncia.Checked)
            {

                Denuncia d;
                patente = tbPatente.Text;

                a.ListaVehiculo.Sort();
                v = new Vehiculo(patente, null);
                int busqueda = a.ListaVehiculo.BinarySearch(v);
                if (busqueda >= 0)
                {
                    v = a.ListaVehiculo[busqueda];
                    d = new Denuncia(v);
                    a.AgregarTicket(d);

                    lbTurnos.Items.Add($"{d.ToString()} - {v.ToString()}");
                }
                else 
                {
                    v = new Vehiculo(patente, c);
                    d = new Denuncia(v);

                    a.ListaVehiculo.Add(v);
                    a.AgregarTicket(d);

                    lbTurnos.Items.Add($"{d.ToString()} - {v.ToString()}");
                }


            }
            if (rbCliente.Checked)
            {

                a.AgregarTicket(c);

            }
        }
        private void btDenuncias_Click(object sender, EventArgs e)
        {
            a.AtenderTicket(0);

        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            a.AtenderTicket(1);
        }
        private void btExportar_Click(object sender, EventArgs e)
        {

        }
        private void btImportar_Click(object sender, EventArgs e)
        {

        }
    }
}
