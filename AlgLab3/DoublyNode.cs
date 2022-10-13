namespace AlgLab3
{
    public class DoublyNode<T> : StandartNode<T>
    {
        public DoublyNode(T data) : base(data) { }

        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}