using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanDocsUITest.LanDocs.Exceptions
{
    /// <summary>
    /// TODO Summary description 
    /// </summary>
    class ObjectNotFoundException : System.Exception
    {
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
