using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;

namespace ProyectoMultio.Models.Components
{
    public class MouseElement
    {
        
        private Point tileSize;

        public MouseElement()
        {
            tileSize = Globals.TileSize;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(
                Textures.Another,
                new Vector2(Input.TiledMouse.X, Input.TiledMouse.Y),
                new Rectangle(0, 0, tileSize.X, tileSize.Y),
                Color.White
                );
        }
    }
}
