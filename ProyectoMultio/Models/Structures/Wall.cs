using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;

namespace ProyectoMultio.Models.Structures
{
    public class Wall : Structure
    {
        public Wall()
        {
            SourceRectangle = new Rectangle(Globals.TileSize.X * 2, 0, Globals.TileSize.X, Globals.TileSize.Y);
        }
    }
}
