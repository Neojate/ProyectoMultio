using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProyectoMultio.Models.Map
{
    public struct Tile
    {
        
        //cursor del inicio de Textura
        public Point SourcePoint { get; set; }

        //booleano para saber si es pasable o no
        public bool IsBlock { get; set; }

        public int Friction { get; set; }

        public bool IsRoad { get; set; }
    }
}
