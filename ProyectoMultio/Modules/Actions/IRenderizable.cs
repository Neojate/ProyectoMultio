using ProyectoMultio.Models.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Actions
{
    interface IRenderizable
    {
        void Render(Camera camera);
    }
}
