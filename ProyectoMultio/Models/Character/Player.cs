using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Maps;

using ProyectoMultio.Modules.Mechanics.Raycasting;
using ProyectoMultio.Modules.Verbs;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Character
{
    public class Player : BasePlayer, IRenderizable
    {
        //public Point Position { get; set; } = new Point(0, 0);

        public Camera Camera { get; set; }

        public Sheet CharacterSheet { get; set; }

        private Raycasting raycasting = new Raycasting();

        public Player()
        {
            Camera = new Camera(this);

            CharacterSheet = new Sheet();
            Position = new Point(1, 1);
        }

        //public override void Render(Camera camera)
        //{
        //    Globals.SpriteBatch.Draw(
        //        Texture,
        //        new Rectangle(Position.X * Globals.TileSize.X, Position.Y * Globals.TileSize.Y, Globals.TileSize.X, Globals.TileSize.Y),
        //        SourceRectangle,
        //        Color.White
        //        );
        //}

        public List<Point> GetNeighbourPositions()
        {
            List<Point> Positions = new List<Point>();

            for (int y = -1; y < 2; y++)
                for (int x = -1; x < 2; x++)
                    if (!(y == 0 && x == 0))
                        Positions.Add(new Point(Position.X + x, Position.Y + y));

            return Positions;
        }

        public void Move(MoveType direction, List<Element> elements, Map map)
        {
            Point moveIncrement = Point.Zero;
            switch(direction)
            {
                case MoveType.Up:
                    moveIncrement = new Point(0, -1);
                    break;
                case MoveType.Down:
                    moveIncrement = new Point(0, 1);
                    break;
                case MoveType.Left:
                    moveIncrement = new Point(-1, 0);
                    break;
                case MoveType.Right:
                    moveIncrement = new Point(1, 0);
                    break;
            }
            
            Point tempPosition = Utils.SumPoints(Position, moveIncrement);
            Element element = elements.Find(e => e.Position == tempPosition && e.IsBlock);
            
            if (element == null)
                Position = new Point(Position.X + moveIncrement.X, Position.Y + moveIncrement.Y);

            for (int y = 0; y < map.Size.Y; y++)
                for (int x = 0; x < map.Size.X; x++)
                    map.Scenario[x, y].IsVisible = false;

            //raycasting.HasVision(player.Position.X, player.Position.Y, p.X, p.Y, map);
            raycasting.SearchLight(Position, map);

        }

        public virtual void Render()
        {
            Point drawPos = new Point((Position.X + Camera.Position.X) * Globals.TileSize.X, (Position.Y + Camera.Position.Y) * Globals.TileSize.Y);
            Globals.SpriteBatch.Draw(Texture,
                new Rectangle(drawPos.X, drawPos.Y, Globals.TileSize.X, Globals.TileSize.Y),
                SourceRectangle,
                BackgroundColor);
        }

    }
}
