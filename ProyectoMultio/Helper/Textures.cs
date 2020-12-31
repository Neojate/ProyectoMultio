using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Helper
{
    public class Textures
    {
        public static Texture2D Tiles;
        public static Texture2D Player;
        public static Texture2D Furniture;

        public static void Load()
        {
            Tiles       = Globals.Content.Load<Texture2D>("img/tiles");
            Player      = Globals.Content.Load<Texture2D>("img/player");
            Furniture   = Globals.Content.Load<Texture2D>("img/furniture");
        }
    }
}
