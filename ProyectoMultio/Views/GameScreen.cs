using ProyectoMultio.Models.Screen;
using ProyectoMultio.Models.Map;
using ProyectoMultio.Helper;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ProyectoMultio.Modules.Actions;
using ProyectoMultio.Modules.Options;
using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Models.Components;
using ProyectoMultio.Modules.Mechanics.Pathfinding;
using System.Linq;
using ProyectoMultio.Models;

namespace ProyectoMultio.Views
{
    public class GameScreen : Screen
    {
        private Map map = new Map();
        private Player player = new Player();
        private Camera camera = new Camera();
        private MouseElement mouse = new MouseElement();

        private Point p;

        private Pathfinding pathfinding;

        public GameScreen()
        {
            map.UpdateBlocking();
            //pathfinding = new Pathfinding(map.Scenario);
            //var x = pathfinding.Start(new Point(1, 1), new Point(10, 10));

            Pathfinding path = new Pathfinding(map.Scenario);
            var x = path.SearchPath(new Point(2, 1), new Point(10, 10));

            foreach (var j in x)
                map.Scenario[j.X, j.Y].BackgroundColor = Color.Red;
        }
        
        public override void Draw()
        {
            //dibujado del mapa
            map.Draw(camera);

            player.Render(camera);

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
                    element.Grab(player, map);
            }
            else if (Input.KeyPressed(controls.MoveUp))
                player.Move(MoveType.Up, map.Elements);
            else if (Input.KeyPressed(controls.MoveDown))
                player.Move(MoveType.Down, map.Elements);
            else if (Input.KeyPressed(controls.MoveLeft))
                player.Move(MoveType.Left, map.Elements);
            else if (Input.KeyPressed(controls.MoveRight))
                player.Move(MoveType.Right, map.Elements);

            else if (Input.KeyPressed(controls.Inventory))
            {
                Globals.ScreenManager.AddWithoutFocus(new InventoryScreen(), this);
            }
            
            if (Input.MouseClick(ButtonType.Right))
            {
                foreach (Element element in map.Elements.FindAll(e => e is IContextualizable && e.Position == p))
                    Globals.ScreenManager.AddWithoutFocus(new ContextualScreen(element, Input.MousePosition), this);
            }
                
                
        }

        public override void Update()
        {
            camera.MoveCamera(player);
        }
    }
}
