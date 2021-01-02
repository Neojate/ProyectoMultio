using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Models.Elements;
using System.Collections.Generic;

namespace ProyectoMultio.Models.Character
{
    public class Player : Element
    {
        //public Point Position { get; set; } = new Point(0, 0);

        public Sheet CharacterSheet { get; set; }

        public Player()
        {
            Texture = Textures.Player;
            SourceRectangle = new Rectangle(0, 0, Globals.TileSize.X, Globals.TileSize.Y);

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

        public void Move(MoveType direction, List<Element> elements)
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

        }

    }
}
