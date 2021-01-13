using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;

namespace ProyectoMultio.Models.Character
{
    public class BasePlayer
    {

        public Texture2D Texture { get; set; } = Textures.Player;

        public Point Position { get; set; }

        public Rectangle SourceRectangle { get; set; } = new Rectangle(0, 0, Globals.TileSize.X, Globals.TileSize.Y);

        public Color BackgroundColor { get; set; } = Color.White;

        //Si el elemento bloquea el camino
        public bool IsBlock { get; set; }
        public bool IsVisible { get; set; }

    }
}
