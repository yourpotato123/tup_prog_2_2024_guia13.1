using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    [Serializable]
    internal class Vehiculo:IComparable<Vehiculo>
    {
        string nroPatente { get; }
        Cliente dueño { get; }

        public Vehiculo (string patente, Cliente c) 
        {
            nroPatente = patente;
            dueño = c;
        }

        public Cliente VerDueño() {return dueño;}

        public string VerPatente() { return nroPatente;}

        public override string ToString()
        {
            Cliente c = VerDueño(); string n = VerPatente();
            return $" {n}";
        }

        public int CompareTo (Vehiculo obj)
        {
            if (obj != null) 
            { return nroPatente.CompareTo(obj.nroPatente); }
            return 1;
        }
    }
}
