using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia_13
{
    public partial class Form1 : Form
    {
        Agencia a = new Agencia();
        FileStream archivo = null;
        StreamReader lector=null;
        StreamWriter escritor=null;

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

                    lbTurnos.Items.Add($"{d.ToString()}");
                }
                else 
                {
                    v = new Vehiculo(patente, c);
                    d = new Denuncia(v);

                    a.ListaVehiculo.Add(v);
                    a.AgregarTicket(d);

                    lbTurnos.Items.Add($"{d.ToString()}");
                }


            }
            if (rbCliente.Checked)
            {

                a.AgregarTicket(c);
                lbTurnos.Items.Add($"{c.ToString()}");

            }
        }
        private void btDenuncias_Click(object sender, EventArgs e)
        {
            Denuncia denuncia = ((Denuncia)a.AtenderTicket(0));
            lbTurnos.Items.Remove(denuncia.ToString());

        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = ((Cliente)a.AtenderTicket(1));
            lbTurnos.Items.Remove(cliente.ToString());
        }
        private void btExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardador = new SaveFileDialog();
            guardador.Filter = "Fichero csv|*.csv*";
            if (guardador.ShowDialog() == DialogResult.OK)
            {
                string ruta = guardador.FileName;
                try
                {
                    List<string> lineas = new List<string>();
                    archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                    escritor = new StreamWriter(archivo);
                    //GUARDADO////////////////////////////////////////////////////////
                    foreach (Cliente cliente in a.nuevos) 
                    {
                        string linea = $"CLIENTE:{cliente.DNI}"; 
                    }
                    foreach (Denuncia denuncia in a.denuncia)
                    {
                        string linea = $"DENUNCIA:{denuncia.dominio}";
                    }
                    foreach (Vehiculo auto in a.ListaVehiculo)
                    {
                        string patente = auto.VerPatente();
                        Cliente dueño = auto.VerDueño();
                        string linea = $"VEHICULO:{patente};{dueño.DNI}";
                    }
                }
                finally
                {
                    escritor.Close();
                    archivo.Close();
                }
            }
        }
        private void btImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abridor = new OpenFileDialog();
            abridor.Filter = "Fichero csv|*.csv*";
            if (abridor.ShowDialog() == DialogResult.OK)
            {
                string ruta = abridor.FileName;
                try
                {
                    List<string> lineas = new List<string>();
                    archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    lector = new StreamReader(archivo);
                    string linea = lector.ReadLine();
                    while (!lector.EndOfStream)
                    {
                        lineas.Add(linea);
                    }
                    foreach (string oracion in lineas)
                    {
                        if (oracion.StartsWith("CLIENTE:"))
                        {
                            string [] datos = oracion.Substring("CLIENTE:".Length).Split(';');
                            long dni = long.Parse(datos[0]);

                            Cliente cliente = new Cliente(dni);
                            a.nuevos.Enqueue(cliente);
                        }
                        if (oracion.StartsWith("VEHICULO:"))
                        {
                            string[] datos = oracion.Substring("VEHICULO:".Length).Split(';');
                            string patente = datos[0];
                            long DNI = long.Parse(datos[1]);

                            Cliente cliente = null;
                            Vehiculo auto = null;

                            bool esta = a.nuevos.Contains(cliente = new Cliente(DNI));
                            if (esta)
                            {
                                auto = new Vehiculo(patente, cliente);
                            }
                            else
                            {
                                a.nuevos.Enqueue(cliente);
                                auto = new Vehiculo(patente, cliente);
                            }
                            a.ListaVehiculo.Add(auto);
                        }
                        if (oracion.StartsWith("DENUNCIA:"))
                        {
                            string[] datos = oracion.Substring("DENUNCIA:".Length).Split(':');
                            string dominio = datos[0];
                            long dni = long.Parse(datos[1]);

                            Cliente cliente = null;
                            Vehiculo auto = null;

                            bool esta = a.nuevos.Contains(cliente = new Cliente(dni));
                            int reesta = a.ListaVehiculo.BinarySearch(auto);

                            if (esta && reesta>=0)
                            {
                                Denuncia denun = new Denuncia(auto);
                                a.denuncia.Enqueue(denun);
                            }
                            
                        }
                    }

                }
                finally
                {
                    lector.Close();
                    archivo.Close();
                }
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ruta = Path.Combine(Application.StartupPath, "Agencia");

            try
            {
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(archivo, a);


            }
            /*catch
            {

            }*/
            finally 
            { 
                if (archivo !=null) { archivo.Close(); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ruta = Path.Combine(Application.StartupPath, "Agencia");

            try
            {
                archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                a = bf.Deserialize(archivo) as Agencia;
            }
            /*catch (Exception ex) 
            {
                //Mesagge.Show("No hay archivo");
            }*/
            finally
            {
                if (archivo != null)
                {
                    archivo.Close();
                }
            }
        }
    }
}
