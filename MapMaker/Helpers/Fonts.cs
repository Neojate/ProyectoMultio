using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Helpers
{
    public static class Fonts
    {
        public static SpriteFont Arial_12 { get; set; }

        public static void Load()
        {
            Arial_12 = Globals.Content.Load<SpriteFont>("fonts/arial_12");
        }
    }
}
