using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    internal class DniInvalidoException : Exception
    {
        public DniInvalidoException() { }
        public DniInvalidoException(string message) : base(message) { }


    }
}