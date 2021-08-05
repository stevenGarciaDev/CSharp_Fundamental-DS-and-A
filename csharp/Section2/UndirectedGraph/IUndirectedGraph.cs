namespace csharp.Section2.UndirectedGraph
{
    public interface IUndirectedGraph<T>
    {
        void AddNode(T label);
        void RemoveNode(T label);
        void AddEdge(T from, T to);
        void RemoveEdge(T from, T to);
    }
}