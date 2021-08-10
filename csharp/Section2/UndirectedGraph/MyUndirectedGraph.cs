using System;
using System.Collections.Generic;

namespace csharp.Section2.UndirectedGraph
{
    public class MyUndirectedGraph<T> : IUndirectedGraph<T> where T : IComparable<T>
    {
        private Dictionary<T, GraphNode<T>> _nodes;
        private Dictionary<GraphNode<T>, LinkedList<GraphNode<T>>> _edges;

        public MyUndirectedGraph()
        {
            _nodes = new Dictionary<T, GraphNode<T>>();
            _edges = new Dictionary<GraphNode<T>, LinkedList<GraphNode<T>>>();
        }

        public void AddEdge(T from, T to)
        {
            GraphNode<T> fromNode = GetNodeIfExists(from);
            GraphNode<T> toNode = GetNodeIfExists(to);

            if (fromNode == null || toNode == null)
                throw new Exception("Nodes do not exist. Can not add an edge.");

            AddEdgeConnection(_edges[fromNode], toNode);
            AddEdgeConnection(_edges[toNode], fromNode);
        }

        public void AddNode(T label)
        {
            if (_nodes.ContainsKey(label))
                throw new Exception("Duplicate node");

            GraphNode<T> newNode = new GraphNode<T>(label);

            _nodes.Add(label, newNode);
            _edges.Add(newNode, new LinkedList<GraphNode<T>>());
        }

        public void RemoveEdge(T from, T to)
        {
            GraphNode<T> fromNode = GetNodeIfExists(from);
            GraphNode<T> toNode = GetNodeIfExists(to);

            if (fromNode == null || toNode == null)
                throw new Exception("Nodes do not exist. Can not add an edge.");

            LinkedList<GraphNode<T>> fromAdjacentNodes = _edges[fromNode];
            LinkedList<GraphNode<T>> toAdjacentNodes = _edges[toNode];

            fromAdjacentNodes.Remove(toNode);
            toAdjacentNodes.Remove(fromNode);
        }

        public void RemoveNode(T label)
        {
            GraphNode<T> nodeToRemove = GetNodeIfExists(label);
            if (nodeToRemove == null) return;

            _nodes.Remove(label);

            foreach (LinkedList<GraphNode<T>> adjacentNodes in _edges.Values)
                adjacentNodes.Remove(nodeToRemove);
        }

        public void DepthFirstSearch(T start)
        {
            GraphNode<T> startNode = GetNodeIfExists(start);
            if (startNode == null) return;

            HashSet<T> visisted = new HashSet<T>();

            DepthFirstSearch(startNode, visisted);
        }

        private void DepthFirstSearch(GraphNode<T> node, HashSet<T> visisted)
        {
            Console.WriteLine(node.Label);
            visisted.Add(node.Label);

            LinkedList<GraphNode<T>> adjacentNeighbors = GetConnections(node);

            if (adjacentNeighbors == null) return;

            foreach (GraphNode<T> adjacent in adjacentNeighbors)
            {
                if (!visisted.Contains(adjacent.Label))
                    DepthFirstSearch(node, visisted);\
            }
        }

        public void DepthFirstSearchIterative(T start)
        {
            GraphNode<T> startNode = GetNodeIfExists(start);
            if (startNode == null) return;

            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();
            HashSet<T> visisted = new HashSet<T>();

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                GraphNode<T> topOfStack = stack.Pop();

                Console.WriteLine(topOfStack.Label);
                visisted.Add(topOfStack.Label);

                LinkedList<GraphNode<T>> adjacentNeighbors = GetConnections(topOfStack);
                if (adjacentNeighbors == null)
                    continue;

                foreach (GraphNode<T> neighbor in adjacentNeighbors)
                {
                    if (!visisted.Contains(neighbor.Label))
                        stack.Push(neighbor);
                }
            }
        }

        public void BreadthFirstSearch(T start)
        {
            throw new NotImplementedException();
        }

        public void BreadthFirstSearchIterative(T start)
        {
            GraphNode<T> startNode = GetNodeIfExists(start);
            if (startNode == null) return;

            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            HashSet<T> visisted = new HashSet<T>();

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                GraphNode<T> front = queue.Dequeue();
                Console.WriteLine(front.Label);
                visisted.Add(front.Label);

                LinkedList<GraphNode<T>> adjacent = GetConnections(front);
                if (adjacent == null) return;

                foreach (GraphNode<T> neighbor in adjacent)
                {
                    if (!visisted.Contains(neighbor.Label))
                        queue.Enqueue(neighbor);
                }
            }
        }

        public void TopologicalSort()
        {
            throw new NotImplementedException();
        }

        private GraphNode<T> GetNodeIfExists(T label)
        {
            return _nodes.ContainsKey(label) ? _nodes[label] : null;
        }

        private void AddEdgeConnection(LinkedList<GraphNode<T>> adjacentNodes, GraphNode<T> nodeToAdd)
        {
            if (adjacentNodes.Contains(nodeToAdd))
                return;

            adjacentNodes.AddLast(nodeToAdd);
        }

        private LinkedList<GraphNode<T>> GetConnections(GraphNode<T> node)
        {
            return _edges.ContainsKey(node) ? _edges[node] : null;
        }
    }
}