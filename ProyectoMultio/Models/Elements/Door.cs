using Microsoft.Xna.Framework;
using ProyectoMultio.Modules.Actions;

namespace ProyectoMultio.Models.Elements
{
    public class Door : Element, IUsable
    {
        public bool IsOpen { get; set; }
        public Rectangle SourceOpen { get; set; }
        public Rectangle SourceClose { get; set; }

        public void OnUse()
        {
            SourceRectangle = IsOpen ? SourceOpen : SourceClose;
            IsOpen = !IsOpen;
            IsBlock = IsOpen;
        }

    }
}
