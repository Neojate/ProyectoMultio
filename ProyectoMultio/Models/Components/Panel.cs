using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Modules.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Components
{
    public class Panel
    {
        public Texture2D Texture { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Color BackgroundColor { get; set; } = Color.White;
        public Style Style { get; set; }

        public void Render()
        {
            if (Style == null)
                Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);
            else
                Globals.SpriteBatch.Draw(
                    Texture,
                    new Rectangle(Bounds.X + Style.Margin[0], Bounds.Y + Style.Margin[1], Bounds.Width - (Style.Margin[2] + Style.Margin[0]), Bounds.Height - (Style.Margin[1] + Style.Margin[3])),
                    SourceRectangle,
                    BackgroundColor    
                    );
        }
    }
}
