using Microsoft.Xna.Framework;
using ProyectoMultio.Modules.Actions;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Structures
{
    public class Door : Structure, IUsable, IContextualizable
    {
        public bool IsOpen { get; set; }
        public Rectangle SourceOpen { get; set; }
        public Rectangle SourceClose { get; set; }

        public List<string> ContextualizeMethods()
        {
            return new List<string>() { "Use" };
        }

        public void Use()
        {
            SourceRectangle = IsOpen ? SourceOpen : SourceClose;
            IsOpen = !IsOpen;
            IsBlock = IsOpen;
        }

    }
}
