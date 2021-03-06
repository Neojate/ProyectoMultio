﻿using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Helper
{
    public class Utils
    {
        public static Tile GetTile(TileType type)
        {
            switch(type)
            {
                case TileType.Road:
                    return new Tile()
                    {
                        SourcePoint = new Point(96, 32)
                    };
                case TileType.Grass:
                    return new Tile()
                    {
                        SourcePoint = new Point(32, 0)
                    };
                default:
                    return new Tile()
                    {
                        SourcePoint = new Point(0, 0)
                    };
                    
            }
        }

        public static Point SumPoints(Point pointA, Point pointB)
        {
            return new Point(pointA.X + pointB.X, pointA.Y + pointB.Y);
        }

        public static Point SubstractPoints(Point pointA, Point pointB)
        {
            return new Point(pointA.X - pointB.X, pointA.Y - pointB.Y);
        }
    }
}
