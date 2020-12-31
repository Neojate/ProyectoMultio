using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.MapMaker
{
    public class TileButton : Button
    {
        public Tile Tile { get; set; }

        public override void onClick(Point mousePosition)
        {
            if (Bounds.Contains(mousePosition))
                Game1.TileOnMemory = Tile;
        }


    }
}
