using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ProyectoMultio.Models.Screen
{
    public enum ScreenState
    {
        Active, Hidden, Shutdown
    }

    public abstract class Screen
    {
        //Nombre de la pantalla
        public string Name { get; set; }

        //Estado de la pantalla
        public ScreenState State { get; set; }
        
        //SpriteBatch de la pantalla
        protected readonly SpriteBatch spriteBatch;

        public Screen(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public abstract void HandleInput();

        public abstract void Update();

        public abstract void Draw();

    }
}
