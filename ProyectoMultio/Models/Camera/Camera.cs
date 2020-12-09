using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Camera
{
    public class Camera
    {
        public Point Position { get; set; }

        public void CenterCamera()
        {
            Position = Point.Zero;
        }
    }
}
