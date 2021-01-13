using ProyectoMultio.Models.Screen;
using ProyectoMultio.Models.Maps;
using ProyectoMultio.Helper;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ProyectoMultio.Modules.Verbs;
using ProyectoMultio.Modules.Options;
using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Components;
using ProyectoMultio.Modules.Mechanics.Pathfinding;
using ProyectoMultio.Models;
using ProyectoMultio.Modules.Mechanics.Raycasting;
using System.Linq;
using ProyectoMultio.Models.Npcs;

namespace ProyectoMultio.Views
{
    public class GameScreen : Screen
    {
        private Map map;
        private Player player = new Player();
        private MouseElement mouse = new MouseElement();

        private Point p;

        private Pathfinding pathfinding;
        private Raycasting raycasting;

        public GameScreen()
        {
            map = new Map(player);

            //pathfinding = new Pathfinding(map.Scenario);
            //var x = pathfinding.Start(new Point(1, 1), new Point(10, 10));

            Pathfinding path = new Pathfinding();
            List<Point> points  = path.SearchPath(new Point(2, 1), new Point(10, 10), map);

            //foreach (var j in points)
                //map.Scenario[j.X, j.Y].BackgroundColor = Color.Red;

            raycasting = new Raycasting();
            //rayCasting.SearchLight(player.Position, map);
            raycasting.HasVision(player.Position.X, player.Position.Y, 10, 12, map);


        }
        
        public override void Draw()
        {
            //dibujado del mapa
            map.Draw();

            player.Render();

            mouse.Draw();

            //Point m = new Point(Input.MousePosition.X / Globals.TileSize.X, Input.MousePosition.Y / Globals.TileSize.Y);
            //p = new Point(m.X - camera.Position.X, m.Y - camera.Position.Y);
            //foreach (Element element in map.Elements.Where(e => e.Position == p))
            //    Globals.SpriteBatch.DrawString(Fonts.Arial8, element.Name, new Vector2(10, 10), Color.White);
        }

        public override void HandleInput()
        {
            KeyboardOptions controls = Globals.Options.KeyboardOptions;

            if (Input.KeyPressed(controls.Use))
            {
                List<Point> neighbourPoints = player.GetNeighbourPositions();

                foreach (IUsable element in map.Elements.FindAll(e => e is IUsable && neighbourPoints.Contains(e.Position)))
                    element.Use();
            }
            else if (Input.KeyPressed(controls.Grab))
            {
                List<Point> neighbourPoints = player.GetNeighbourPositions();

                foreach (IGrabable element in map.Elements.FindAll(e => e is IGrabable && neighbourPoints.Contains(e.Position)))
                    element.Grab();
            }
            else if (Input.KeyPressed(controls.MoveUp))
                player.Move(MoveType.Up, map.Elements, map);
            else if (Input.KeyPressed(controls.MoveDown))
                player.Move(MoveType.Down, map.Elements, map);
            else if (Input.KeyPressed(controls.MoveLeft))
                player.Move(MoveType.Left, map.Elements, map);
            else if (Input.KeyPressed(controls.MoveRight))
                player.Move(MoveType.Right, map.Elements, map);

            else if (Input.KeyPressed(controls.Inventory))
                Globals.ScreenManager.AddScreenAndFocus(new InventoryScreen());

            else if (Input.KeyPressed(controls.Skill1))
            {
                foreach (Enemy element in map.Elements.Where(e => e is Enemy))
                    if (element.IsAlive)
                    {
                        foreach (Point point in raycasting.HasVisionWithPath(player.Position, element.Position, map))
                            map.Scenario[point.X, point.Y].BackgroundColor = Color.Red;
                    }
                        
            }
            
            if (Input.MouseClick(ButtonType.Right))
                foreach (Element element in map.Elements.FindAll(e => e is IContextualizable && e.Position == Input.MouseTileCoords(player.Camera)))
                    Globals.ScreenManager.AddScreenAndFocus(new ContextualScreen(element, Input.MousePosition));
                
        }

        public override void Update()
        {
            //mover esto a player
            player.Camera.MoveCamera();

            map.UpdateMap();

            foreach (Element element in map.Elements)
                element.BackgroundColor = map.Scenario[element.Position.X, element.Position.Y].IsVisible ? Color.White : Color.DarkGray;

            //for (int y = 0; y < map.Size.Y; y++)
            //    for (int x = 0; x < map.Size.X; x++)
            //        map.Scenario[x, y].BackgroundColor = Color.White;

            //Raycasting raycasting = new Raycasting();

            //Point m = new Point(Input.MousePosition.X / Globals.TileSize.X, Input.MousePosition.Y / Globals.TileSize.Y);
            //p = new Point(m.X - camera.Position.X, m.Y - camera.Position.Y);

            ////raycasting.HasVision(player.Position.X, player.Position.Y, p.X, p.Y, map);
            //raycasting.SearchLight(player.Position, map);
        }
    }
}
