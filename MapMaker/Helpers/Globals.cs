using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MapMaker.Helpers
{
    public static class Globals
    {
        public static SpriteBatch SpriteBatch { get; set; }

        public static ContentManager Content { get; set; }

        public static Point ScreenSize { get; set; }
    }
}
