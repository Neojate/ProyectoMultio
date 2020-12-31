using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Models.Elements;
using ProyectoMultio.Models.Items;
using ProyectoMultio.Modules.Actions;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Map
{
    public class Map
    {
        public Tile[,] Scenario { get; set; }
        public Point Size { get; set; }

        public List<Element> Elements { get; set; }

        public Map()
        {
            Size = new Point(100, 100);
            Scenario = new Tile[Size.X, Size.Y];

            //mapa de pega
            for (int y = 0; y < Size.Y; y++)
                for (int x = 0; x < Size.X; x++)
                    Scenario[x, y] = Utils.GetTile(TileType.Road);

            Scenario[13, 5] = Utils.GetTile(TileType.Grass);

            //elementos de pega
            Elements = new List<Element>()
            {
                new Door()
                {
                    Position = new Point(1, 0),
                    SourceRectangle = new Rectangle(0, 0, 32, 32),
                    SourceClose = new Rectangle(0, 0, 32, 32),
                    SourceOpen = new Rectangle(32, 0, 32, 32),
                    Texture = Textures.Furniture,
                    IsOpen = false,
                    IsBlock = true
                },
                new Item()
                {
                    Position = new Point(5, 5),
                    SourceRectangle = new Rectangle(0, 0, 32, 32),
                    Texture = Textures.Furniture
                }
            };
        }

        public void Draw(Camera camera)
        {
            for (int y = 0; y < camera.RenderTiles.Y + 1; y++) 
            { 
                for (int x = 0; x < camera.RenderTiles.X + 1; x++)
                {
                    Point drawPos = new Point(x - camera.Position.X, y - camera.Position.Y);
                    if (drawPos.X >= 0 && drawPos.X < Size.X && drawPos.Y >= 0 && drawPos.Y < Size.Y)
                        Scenario[drawPos.X, drawPos.Y].Render(new Point(x * Globals.TileSize.X, y * Globals.TileSize.Y));
                    
                }
            }

            foreach (IRenderizable element in Elements)
                element.Render(camera);
        }
    }
}
