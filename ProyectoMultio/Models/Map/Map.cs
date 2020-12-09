using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProyectoMultio.Models.Map
{
    public class Map
    {
        public Tile[,] Scenario { get; set; }
        private Point Size { get; set; } = new Point(100, 100);

        public void LoadMap(string mapName)
        {
            Scenario = new Tile[100, 100];
            
            for (int y = 0; y < Size.Y; y++)
            {
                for (int x = 0; x < Size.X; x++)
                {
                    Scenario[x, y] = new Tile()
                    {
                        IsBlock = false,
                        IsDiscovered = false,
                        IsVisible = false,
                        PointTexture = Point.Zero
                    };
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Size.Y; y++)
            {
                for(int x = 0; x < Size.X; x++)
                {
                    Tile tile = Scenario[x, y];

                    Point position = new Point(x * Tile.Size.X, y * Tile.Size.Y);
                    
                    Rectangle destinarion = new Rectangle(position, Tile.Size);
                    Rectangle source = new Rectangle(tile.PointTexture, Tile.Size);

                    spriteBatch.Begin();
                    spriteBatch.Draw(Tile.Texture, destinarion, source, Color.White);
                    spriteBatch.End();
                }
            }
        }
    }
}
