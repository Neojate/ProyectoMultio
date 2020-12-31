using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Helpers
{
    public static class Textures
    {
        public static Texture2D Background { get; set; }
        public static Texture2D Tiles { get; set; }

        public static void Load()
        {
            Background  = Globals.Content.Load<Texture2D>("images/grayscale");
            Tiles       = Globals.Content.Load<Texture2D>("images/tiles");
        }
    }
}
