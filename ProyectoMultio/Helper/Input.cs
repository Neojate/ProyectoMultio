using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Helper
{
    public class Input
    {
        public static KeyboardState currentKeyState;
        
        public static KeyboardState lastKeyState;

        public static void Update()
        {
            lastKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public static bool KeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && lastKeyState.IsKeyUp(key);
        }

    }
}
