using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;

namespace ProyectoMultio.Models.Map
{
    public struct Tile
    {

        //cursor del inicio de Textura
        public Point SourcePoint { get; set; }

        //booleano para saber si es pasable o no
        public bool IsBlock { get; set; }

        //booleano para saber si se ha descubierto o no
        public bool IsDiscovered { get; set; }

        //booleano para saber si es visible o no
        public bool IsVisible { get; set; }

        public void Render(Point position)
        {
            Globals.SpriteBatch.Draw(
                Textures.Tiles,
                new Rectangle(position, Globals.TileSize), 
                new Rectangle(SourcePoint, Globals.TileSize), 
                Color.White
                );
        }
    }
}
