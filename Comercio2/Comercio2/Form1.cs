using ComercioLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        Comercio c = new Comercio();
        FileStream archivo = null;
        StreamReader lector = null;
        StreamWriter escritor = null;


        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (cbCte.Checked)
            {
                int cc = Convert.ToInt32(txCte.Text);
                CuentaCorriente cte = null;
                cte = c[cc];
                Pago pago = new Pago(cte);
                c.AgregarTicket(pago);
                listBox1.Items.Add(pago.ToString());
            }
            else
            {
                string dni = txtDNI.Text;
                Cliente cli = new Cliente(dni);
                listBox1.Items.Add(cli.ToString());
            }

        }
        private void btnAtenderCliente_Click(object sender, EventArgs e)
        {

            Ticket ticket = null;
            if (rbCompra.Checked)
            {
                ticket = c.AtenderTicket(0);
                listBox1.Items.Remove(ticket);
            }
            if (rbPago.Checked)
            {
                ticket = c.AtenderTicket(1);
                listBox1.Items.Remove(ticket);

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string lineas;

            SaveFileDialog guardador = new SaveFileDialog();
            guardador.Filter = "Archivo .csv|*.csv*";
            guardador.InitialDirectory = Application.StartupPath;

            if (guardador.ShowDialog() == DialogResult.OK)
            {
                string ruta = guardador.FileName;

                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Write);
                escritor = new StreamWriter(archivo);

                lineas = $"TipoTicket;numero;dni;ctaCte";
                escritor.WriteLine(lineas);

                List<Ticket> lista = c.VerAtendidos();
                if (lista != null)
                {
                    foreach (Ticket t in lista)//int indice = 0; indice < lista.Count(); indice++)
                    {
                        lineas = t.CsvString().Replace("-", ";").Trim();
                        escritor.WriteLine();
                    }
                }
                escritor.Close();
                archivo.Close();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string[] datos;
            string linea;

            OpenFileDialog abridor = new OpenFileDialog();
            abridor.Filter = "Archivo csv|*.csv*";
            abridor.InitialDirectory = Application.StartupPath;

            if (abridor.ShowDialog() == DialogResult.OK)
            {
                string ruta = abridor.FileName;
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                lector = new StreamReader(archivo);

                lector.ReadLine();
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();
                    //linea = linea.Replace("-", "").Trim();
                    datos = linea.Split(';');

                    int numero = Convert.ToInt32(datos[0]);
                    string dni = datos[1];
                    double saldo = Convert.ToDouble(datos[2]);

                    CuentaCorriente cte = c[numero];

                    if (cte == null)
                    {
                        Cliente cliente = c.VerCliente(dni);
                        cte = new CuentaCorriente(numero, cliente);
                        c.AgregarCuenta(cte);
                    }
                    c[numero].RegistrarSaldo(saldo);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string ruta = Path.Combine(Application.StartupPath, "Datos.bin");
            if (File.Exists(ruta))
            {
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                c = (Comercio)bf.Deserialize(archivo);
                archivo.Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string ruta = Path.Combine(Application.StartupPath, "Datos.bin");

            if (File.Exists(ruta))
            {
                archivo = new FileStream(ruta, FileMode.Open, FileAccess.Write);
                bf.Serialize(archivo, c);
            }
            else
            {
                archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write);
            }
            archivo.Close();
        }
    }
}
