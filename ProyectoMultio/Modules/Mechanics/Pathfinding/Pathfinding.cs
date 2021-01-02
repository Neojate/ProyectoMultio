using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Modules.Mechanics.Pathfinding
{
    public class Pathfinding
    {
        private const int AXIS_VALUE = 10;
        private const int DIAGONAL_VALUE = 14;

        private Tile[,] map;

        private List<Node> openNodes;
        private List<Node> closestNodes;

        private Node startNode, endNode, currentNode;

        private int g;

        public Pathfinding(Tile[,] map)
        {
            this.map = map;
        }

        public List<Node> Start(Point initialPoint, Point endPoint)
        {
            startNode   = new Node(initialPoint);
            endNode     = new Node(endPoint);

            openNodes = new List<Node>();
            closestNodes = new List<Node>();

            openNodes.Add(startNode);

            while (openNodes.Count > 0)
            {
                int lowerFValue = openNodes.Min(node => node.F);
                currentNode = openNodes.First(node => node.F == lowerFValue);

                closestNodes.Add(currentNode);
                openNodes.Remove(currentNode);

                if (closestNodes.FirstOrDefault(node => node.Position == endNode.Position) != null) 
                    break;

                List<Node> adjacentNodes = currentNode.AdjacentNodes(map);
                g += AXIS_VALUE;

                foreach (Node node in adjacentNodes)
                {
                    if (openNodes.FirstOrDefault(n => n.Position == node.Position) == null)
                    {
                        node.CalculateF(endNode, g);
                        node.Parent = currentNode;
                        openNodes.Insert(0, node);
                    } 
                    else
                    {
                        if (g + node.H < node.F)
                        {
                            node.CalculateF(endNode, g);
                            node.Parent = currentNode;
                        }
                    }

                }
            }
            List<Node> result = new List<Node>();
            while (currentNode != null)
            {
                result.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            return result;
        }
    }
}
