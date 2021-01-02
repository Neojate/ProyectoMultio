using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Mechanics.Pathfinding
{
    public class Node
    {
        public Point Position { get; set; }

        public Node Parent { get; set; }

        public int F { get; set; }
        public int H { get; set; }

        private int g;        

        public Node()
        {

        }

        public Node(Point position)
        {
            this.Position = position;
        }

        public List<Node> AdjacentNodes(Tile[,] map)
        {
            List<Node> adjacentNodes = new List<Node>()
            {
                new Node(new Point(Position.X, Position.Y - 1)),
                new Node(new Point(Position.X, Position.Y + 1)),
                new Node(new Point(Position.X - 1, Position.Y)),
                new Node(new Point(Position.X + 1, Position.Y))
            };
            return adjacentNodes.Where(node => !map[node.Position.X, node.Position.Y].IsBlock).ToList();
        }

        public void CalculateF(Node endNode, int g)
        {
            this.g = g;
            F = calculateH(endNode) + g;
        }

        private int calculateH(Node endNode)
        {
            H = Math.Abs(Position.X - endNode.Position.X) + Math.Abs(Position.Y - endNode.Position.Y);
            return H;
        }
    }
}
