using Microsoft.Xna.Framework;
using ProyectoMultio.Modules.Verbs;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Structures
{
    public class Door : Structure, IUsable, IContextualizable, IInspectable
    {
        public bool IsOpen { get; set; }
        public Rectangle SourceOpen { get; set; }
        public Rectangle SourceClose { get; set; }
        public string Description { get; set; }


        public List<Contextual> ContextualizeMethods()
        {
            return new List<Contextual>()
            {
                new Contextual("Use", true)
            };
        }

        public void Inspect()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            SourceRectangle = IsOpen ? SourceOpen : SourceClose;
            IsOpen = !IsOpen;
            IsBlock = IsOpen;
        }

    }
}
