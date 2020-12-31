using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Modules.Actions;

namespace ProyectoMultio.Models.Elements
{
    public class Element : IRenderizable
    {
        public Texture2D Texture { get; set; } = Textures.Tiles;

        public Point Position { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Color BackgroundColor { get; set; } = Color.White;

        //Si el elemento bloquea el camino
        public bool IsBlock { get; set; }

        public virtual void Render(Camera camera)
        {
            Point drawPos = new Point((Position.X + camera.Position.X) * Globals.TileSize.X, (Position.Y + camera.Position.Y) * Globals.TileSize.Y);
            Globals.SpriteBatch.Draw(Texture, 
                new Rectangle(drawPos.X, drawPos.Y, Globals.TileSize.X, Globals.TileSize.Y), 
                SourceRectangle, 
                BackgroundColor);
        }

    }
}
