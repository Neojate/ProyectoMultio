using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Npcs
{
    public class Enemy : Npc
    {
        public Enemy()
        {
            SourceRectangle = new Rectangle(0, 192, Globals.TileSize.X, Globals.TileSize.Y);
        }
    }
}
