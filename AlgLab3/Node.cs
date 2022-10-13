namespace AlgLab3
{
    public class Node<T> : StandartNode<T>
    {
        public Node(T data) : base(data) { }

        public Node<T> Next { get; set; }
    }
}