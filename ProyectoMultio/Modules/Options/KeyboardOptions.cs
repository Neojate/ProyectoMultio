using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Options
{
    public class KeyboardOptions
    {
        public Keys Inventory { get; set; } = Keys.I;

        public Keys Use { get; set; } = Keys.E;
        public Keys Grab { get; set; } = Keys.G;
        public Keys MoveUp { get; set; } = Keys.Up;
        public Keys MoveDown { get; set; } = Keys.Down;
        public Keys MoveLeft { get; set; } = Keys.Left;
        public Keys MoveRight { get; set; } = Keys.Right;
    }
}
