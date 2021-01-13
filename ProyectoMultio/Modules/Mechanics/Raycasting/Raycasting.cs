using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Mechanics.Raycasting
{
    public class Raycasting
    {
        Map map;

        public void SearchLight(Point playerPosition, Map map)
        {
            this.map = map;

            Point numTiles = new Point(Globals.Resolution.X / Globals.TileSize.X, Globals.Resolution.Y / Globals.TileSize.Y);
            Point startTile = new Point(playerPosition.X - numTiles.X, playerPosition.Y - numTiles.Y);

            List<Tile> tiles = new List<Tile>();
            for (int y = startTile.Y; y < numTiles.Y + 1; y++)
                for (int x = startTile.X; x < numTiles.X + 1; x++)
                {
                    Rectangle mapRectangle = new Rectangle(0, 0, map.Size.X, map.Size.Y);
                    if (mapRectangle.Contains(new Point(x, y)))
                    {
                        HasVision(playerPosition.X, playerPosition.Y, x, y, map);
                    }

                }
            
        }

        public bool HasVision(int x, int y, int x2, int y2, Map map)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                Rectangle visibleMap = new Rectangle(0, 0, Globals.TileSize.X, Globals.TileSize.Y);
                
                if (visibleMap.Contains(new Point(x, y)))
                {
                    if (map.Scenario[x, y].IsBlock)
                        return false;
                    map.Scenario[x, y].IsVisible = true;
                }
                    

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
            return true;
        }

        public List<Point> HasVisionWithPath(Point start, Point end, Map map)
        {
            List<Point> points = new List<Point>();

            int w = end.X - start.X;
            int h = end.Y - start.Y;
            Point d = Point.Zero;
            Point d2 = Point.Zero;
            if (w < 0) d.X = -1; else if (w > 0) d.X = 1;
            if (h < 0) d.Y = -1; else if (h > 0) d.Y = 1;
            if (w < 0) d2.X = -1; else if (w > 0) d2.X = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) d2.Y = -1; else if (h > 0) d2.Y = 1;
                d2.X = 0;
            }
            int numerator = longest >> 1;
            Point currentPoint = start;
            
            for (int i = 0; i <= longest; i++)
            {
                points.Add(currentPoint);

                Rectangle visibleMap = new Rectangle(0, 0, Globals.TileSize.X, Globals.TileSize.Y);
                if (visibleMap.Contains(currentPoint))
                    if (map.Scenario[currentPoint.X, currentPoint.Y].IsBlock) break;

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    currentPoint = new Point(currentPoint.X + d.X, currentPoint.Y + d.Y);
                }
                else
                {
                    currentPoint = new Point(currentPoint.X + d2.X, currentPoint.Y + d2.Y);
                }
            }
            return points;
        }
    }
}
