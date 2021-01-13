using ProyectoMultio.Helper;
using ProyectoMultio.Modules.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Npcs
{
    public class Npc : Element, IFocusable, IContextualizable
    {
        public bool IsAlive { get; set; } = true;

        public Npc()
        {
            Texture = Textures.Npcs;
        }

        public void Focus()
        {
            
        }

        public List<Contextual> ContextualizeMethods()
        {
            return new List<Contextual>()
            {
                new Contextual("Focus", IsAlive)
            };
        }
    }
}
