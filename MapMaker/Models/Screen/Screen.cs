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

        //Instancia al spritebatch
        protected SpriteBatch SpriteBatch;
        
        //SpriteBatch de la pantalla
        protected readonly SpriteBatch spriteBatch;

        public Screen()
        {
            //spriteBatch = Global.Instance.SpriteBatch;
        }

        public abstract void HandleInput();

        public abstract void Update();

        public abstract void Draw();

    }
}
