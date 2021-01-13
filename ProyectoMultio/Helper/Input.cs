using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProyectoMultio.Models.Character;

namespace ProyectoMultio.Helper
{
    public enum ButtonType
    {
        Left, Right
    }

    public class Input
    {
        public static Point MousePosition { get; set; }
        public static Point TiledMouse { get; set; }

        private static KeyboardState currentKeyState;
        private static KeyboardState lastKeyState;

        private static MouseState currentMouseState;
        private static MouseState lastMouseState;

        public static void Update()
        {
            lastKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            MousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            Point tiledMouse = new Point(MousePosition.X / Globals.TileSize.X, MousePosition.Y / Globals.TileSize.Y);
            TiledMouse = new Point(tiledMouse.X * Globals.TileSize.X, tiledMouse.Y * Globals.TileSize.Y);
        }

        public static bool KeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && lastKeyState.IsKeyUp(key);
        }

        public static bool MouseDown(ButtonType button)
        {
            switch (button)
            {
                case ButtonType.Left:
                    return currentMouseState.LeftButton == ButtonState.Pressed;
                case ButtonType.Right:
                    return currentMouseState.RightButton == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        public static bool MouseClick(ButtonType button)
        {
            switch (button)
            {
                case ButtonType.Left:
                    return MouseDown(button) && lastMouseState.LeftButton == ButtonState.Released;
                case ButtonType.Right:
                    return MouseDown(button) && lastMouseState.RightButton == ButtonState.Released;
                default:
                    return false;
            }
        }

        public static Point MouseTileCoords(Camera camera)
        {
            Point m = new Point(MousePosition.X / Globals.TileSize.X, MousePosition.Y / Globals.TileSize.Y);
            return new Point(m.X - camera.Position.X, m.Y - camera.Position.Y);
        }

    }
}
