using System;

namespace csharp.Section2.UndirectedGraph
{
    public class GraphNode<T> where T : IComparable<T>
    {
        public T Label { get; set; }

        public GraphNode(T label = default(T))
        {
            Label = label;
        }
    }
}