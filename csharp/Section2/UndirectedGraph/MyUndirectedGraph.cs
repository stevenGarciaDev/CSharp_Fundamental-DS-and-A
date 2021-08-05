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
    }
}