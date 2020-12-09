using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Globals;

namespace ProyectoMultio.Models.Map
{
    public struct Tile
    {
        //constante de la textura
        public static Texture2D Texture { get; set; } = Global.Content.Load<Texture2D>("Images/Map/texture1");

        //constante para el tamaño del tile x, y
        public static Point Size { get; set; } = new Point(32, 32);

        //booleano para saber si es pasable o no
        public bool IsBlock { get; set; }

        //booleano para saber si se ha descubierto o no
        public bool IsDiscovered { get; set; }

        //booleano para saber si es visible o no
        public bool IsVisible { get; set; }

        //coordenadas x, y de la textura a dibujar
        public Point PointTexture { get; set; }
    }
}
