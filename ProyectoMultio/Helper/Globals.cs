using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Modules.Options;
using ProyectoMultio.Modules.ScreenManagers;


namespace ProyectoMultio.Helper
{
    public static class Globals
    {
        //Contenido global del proyecto
        public static ContentManager Content { get; set; }

        //SpriteBatch del proyecto
        public static SpriteBatch SpriteBatch { get; set; }

        //ScreenManager
        public static ScreenManager ScreenManager { get; set; }

        //Resolución de la pantalla -> migrar a las opciones
        public static Point Resolution { get; set; } = new Point(1920, 1080);

        //Tamaño de la cuadricula
        public static Point TileSize { get; set; } = new Point(32, 32);

        //Instancia a las opciones
        public static Options Options;

        //Opciones gráficas del juego
        //public GraphicOptions GraphicOptions { get; set; }


    }
}
