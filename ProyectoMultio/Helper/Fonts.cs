using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Helper
{
    public class Fonts
    {
        public static SpriteFont Arial8 { get; set; }

        public static void Load()
        {
            Arial8 = Globals.Content.Load<SpriteFont>("fonts/arial_8");
        }
    }
}
