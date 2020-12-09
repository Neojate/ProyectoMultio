using Microsoft.Xna.Framework;

namespace ProyectoMultio.Models.Options
{
    public class GraphicOptions : Options
    {
        public Point Resolution { get; set; } = new Point(800, 600);
        public bool IsFullScreen { get; set; } = false;
    }
}
