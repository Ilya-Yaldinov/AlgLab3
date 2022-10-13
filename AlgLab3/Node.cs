namespace AlgLab3
{
    public class Node<T> : StandartNode<T>
    {
        public Node<T> Next { get; set; }

        public Node(T data) : base(data) { }
    }
}