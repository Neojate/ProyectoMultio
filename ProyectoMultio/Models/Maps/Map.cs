using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Furnitures;
using ProyectoMultio.Models.Items;
using ProyectoMultio.Models.Npcs;
using ProyectoMultio.Models.Structures;
using ProyectoMultio.Modules.Verbs;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Maps
{
    public class Map
    {
        public Tile[,] Scenario { get; set; }
        public Point Size { get; set; }

        public List<Element> Elements { get; set; }

        private Player player;

        public Map(Player player)
        {
            this.player = player;

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
                    Position = new Point(3, 5),
                    SourceRectangle = new Rectangle(0, 0, 32, 32),
                    SourceClose = new Rectangle(0, 0, 32, 32),
                    SourceOpen = new Rectangle(32, 0, 32, 32),
                    IsOpen = false,
                    IsBlock = true,
                    Name = Lang.Trans("door"),
                },
                new Chair()
                {
                    Position = new Point(7, 7),
                },
                new Allied()
                {
                    SourceRectangle = new Rectangle(0, 0, 32, 32),
                    Conversation = new string[] { "npc001_001", "npc001_002", "npc001_003", "npc001_004" },
                    Position = new Point(10, 10),
                },
                new Item(this, player)
                {
                    Position = new Point(11, 7),
                    Texture = Textures.Npcs,
                    SourceRectangle = new Rectangle(0, 0, 32, 32),
                },
                //Enemigos
                new Enemy()
                {
                    Position = new Point(12, 12)
                }
            };

            for (int y = 0; y < Size.Y; y++)
            {
                Wall wallLeft = new Wall();
                wallLeft.Position = new Point(0, y);
                Wall wallRight = new Wall();
                wallRight.Position = new Point(Size.X - 1, y);
                Elements.Add(wallLeft);
                Elements.Add(wallRight);
            }

            for (int x = 0; x < Size.X; x++)
            {
                Wall wallTop = new Wall();
                wallTop.Position = new Point(x, 0);
                Wall wallBot = new Wall();
                wallBot.Position = new Point(x, Size.Y - 1);
                Elements.Add(wallTop);
                Elements.Add(wallBot);
            }

            //comprobación pathfinding
            for (int i = 1; i < 6; i++)
                Elements.Add(new Wall() { Position = new Point(5, i) });
            Elements.Add(new Wall() { Position = new Point(1, 5) });
            Elements.Add(new Wall() { Position = new Point(2, 5) });
            Elements.Add(new Wall() { Position = new Point(4, 5) });

            Elements.Add(new Wall() { Position = new Point(13, 14) });
            Elements.Add(new Wall() { Position = new Point(15, 14) });

            Elements.ForEach(element => element.Player = player);

        }

        public void UpdateMap()
        {
            foreach (Element element in Elements)
            {
                Scenario[element.Position.X, element.Position.Y].IsBlock = element.IsBlock;
                element.IsVisible = Scenario[element.Position.X, element.Position.Y].IsVisible;
            }
        }

        public void Draw()
        {
            Camera camera = player.Camera;
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
                element.Render();
        }
    }
}
