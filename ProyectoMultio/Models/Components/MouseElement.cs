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
    public class MouseElement
    {
        
        private Point tileSize;

        public MouseElement()
        {
            tileSize = Globals.TileSize;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(
                Textures.Another,
                new Vector2(Input.TiledMouse.X, Input.TiledMouse.Y),
                new Rectangle(0, 0, tileSize.X, tileSize.Y),
                Color.White
                );
        }
    }
}
