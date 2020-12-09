using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Models.Screen;
using ProyectoMultio.Models.Map;

namespace ProyectoMultio.Screens
{
    public class GameScreen : Screen
    {
        private Map map = new Map();

        public GameScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            map.LoadMap("mapa_inicial");
        }

        public override void Draw()
        {
            map.Draw(spriteBatch);
        }

        public override void HandleInput()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
