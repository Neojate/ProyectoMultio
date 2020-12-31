using MapMaker.Models.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Models.Map;
using System;

namespace MapMaker.Helpers
{
    public class Utils
    {
        public static Tile GetTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Road:
                    return new Tile()
                    {
                        Friction = 100,
                        IsBlock = false,
                        IsRoad = true,
                        SourcePoint = new Point(96, 32)
                    };
                case TileType.Grass:
                    return new Tile()
                    {
                        Friction = 100,
                        IsBlock = false,
                        IsRoad = false,
                        SourcePoint = new Point(192, 32)
                    };
                case TileType.Land:
                    return new Tile()
                    {
                        Friction = 100,
                        IsBlock = false,
                        IsRoad = true,
                        SourcePoint = new Point(288, 0)
                    };
                default:
                    return new Tile()
                    {
                        Friction = 0,
                        IsBlock = false,
                        IsRoad = true,
                        SourcePoint = new Point(0, 128)
                    };
            }
        }

        public static Point CenterText(SpriteFont font, String text, Rectangle destination)
        {
            Vector2 textMeasure = font.MeasureString(text);
            return new Point(
                (int)((destination.X + destination.Width / 2) - textMeasure.X / 2),
                (int)((destination.Y + destination.Height / 2) - textMeasure.Y / 2));
        }
    }
}
