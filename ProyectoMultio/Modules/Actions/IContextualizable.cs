using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Actions
{
    public interface IContextualizable
    {
        List<string> ContextualizeMethods();
    }
}
