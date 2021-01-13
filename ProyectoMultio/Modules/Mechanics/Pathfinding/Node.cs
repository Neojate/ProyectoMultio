using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Maps;
using System;
using System.Collections.Generic;

namespace ProyectoMultio.Modules.Mechanics.Pathfinding
{
    public class Node
    {
        public Point Position { get; set; }

        public Node Parent { get; set; }

        public int F { get; set; }
        public int H { get; set; }
        public int G { get; set; }

        public Node(Point position)
        {
            this.Position = position;
        }

        public List<Node> NeighbourNodes(Tile[,] map, List<Node> closedNodes)
        {
            List<Node> neighbourdNodes = new List<Node>();
            for (int y = -1; y < 2; y++)
                for (int x = -1; x < 2; x++)
                    if (!(x == 0 && y == 0) && !map[Position.X + x, Position.Y + y].IsBlock)
                        neighbourdNodes.Add(new Node(new Point(Position.X + x, Position.Y + y)));
            return neighbourdNodes;
        }

        public void CalculateFGH(Node startNode, Node endNode)
        {
            //distancia al nodo inicial
            G = Math.Abs(Position.X - startNode.Position.X) + Math.Abs(Position.Y - startNode.Position.Y);
            //distancia al nodo final
            H = Math.Abs(Position.X - endNode.Position.X) + Math.Abs(Position.Y - endNode.Position.Y);
            //sumatorio
            F = G + H;
        }       
    }
}
