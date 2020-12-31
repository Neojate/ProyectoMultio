using ProyectoMultio.Models.Screen;
using ProyectoMultio.Models.Map;
using ProyectoMultio.Helper;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ProyectoMultio.Modules.Actions;
using ProyectoMultio.Modules.Options;
using ProyectoMultio.Models.Character;
using ProyectoMultio.Models.Cameras;

namespace ProyectoMultio.Views
{
    public class GameScreen : Screen
    {
        private Map map = new Map();
        private Player player = new Player();
        private Camera camera = new Camera();
        public override void Draw()
        {
            //dibujado del mapa
            map.Draw(camera);

            player.Render(camera);

        }

        public override void HandleInput()
        {
            KeyboardOptions controls = Globals.Options.KeyboardOptions;

            if (Input.KeyPressed(controls.Use))
            {
                List<Point> neighbourPoints = player.GetNeighbourPositions();

                foreach (IUsable element in map.Elements.FindAll(e => e is IUsable && neighbourPoints.Contains(e.Position)))
                    element.OnUse();

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
                
                //foreach (Point position in player.GetNeighbourPositions())
                    //foreach (IUsable usable in map.Elements.FindAll(e => e is IUsable && e.Bounds.X == position.X && e.Bounds.Y == position.Y))
                        //usable.OnUse();
        }

        public override void Update()
        {
            camera.MoveCamera(player);
        }
    }
}
