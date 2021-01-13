using ProyectoMultio.Models;
using System.Collections.Generic;

namespace ProyectoMultio.Modules.Verbs
{
    public interface IContextualizable
    {
        List<Contextual> ContextualizeMethods();
    }
}
