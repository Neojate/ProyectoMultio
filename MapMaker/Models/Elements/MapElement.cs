using JsonSubTypes;
using MapMaker.Actions;
using MapMaker.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Models.Elements
{
    public class MapElement : IRenderizable
    {
        public Texture2D Texture { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Color BackgroundColor { get; set; } = Color.White;

        public virtual void Render()
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);
        }
    }
}
