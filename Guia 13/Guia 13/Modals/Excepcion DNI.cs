using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_13
{
    internal class DniInvalidoException:Exception
    {
        public DniInvalidoException() { }
        public DniInvalidoException(string message) : base(message) { }
    }

}
