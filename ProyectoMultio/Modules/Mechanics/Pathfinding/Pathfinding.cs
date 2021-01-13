using Microsoft.Xna.Framework;
using ProyectoMultio.Models.Maps;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoMultio.Modules.Mechanics.Pathfinding
{
    public class Pathfinding
    {
        private Node startNode, endNode, currentNode;
        private List<Node> openNodes = new List<Node>();
        private List<Node> closedNodes = new List<Node>();

        public List<Point> SearchPath(Point startPosition, Point endPosition, Map map)
        {
            startNode   = new Node(startPosition);
            endNode     = new Node(endPosition);

            openNodes.Add(startNode);

            while(openNodes.Count > 0)
            {
                currentNode = openNodes.OrderBy(node => node.F).First();
                
                openNodes.Remove(currentNode);
                closedNodes.Add(currentNode);

                if (currentNode.Position == endPosition)
                    break;

                foreach (Node neighbourNode in currentNode.NeighbourNodes(map.Scenario, closedNodes))
                {
                    if (closedNodes.FirstOrDefault(n => n.Position == neighbourNode.Position) != null)
                        continue;

                    if (openNodes.FirstOrDefault(n => n.Position == neighbourNode.Position) == null)
                    {
                        openNodes.Add(neighbourNode);
                        neighbourNode.Parent = currentNode;
                        neighbourNode.CalculateFGH(startNode, endNode);
                    }
                    else
                    {
                        if (neighbourNode.G < currentNode.G)
                        {
                            neighbourNode.Parent = currentNode;
                            neighbourNode.CalculateFGH(startNode, endNode);
                        }
                    }
                }
            }

            List<Point> finalPositions = new List<Point>();
            while(currentNode != null)
            {
                finalPositions.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }
            return finalPositions;
        }
    }
}
