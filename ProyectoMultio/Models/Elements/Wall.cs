using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;

namespace ProyectoMultio.Models.Elements
{
    public class Wall : Element
    {
        public Wall()
        {
            Texture = Textures.Furniture;
            SourceRectangle = new Rectangle(Globals.TileSize.X * 2, 0, Globals.TileSize.X, Globals.TileSize.Y);
            IsBlock = true;
        }
    }
}
