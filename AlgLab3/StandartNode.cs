namespace AlgLab3
{
    public abstract class StandartNode<T>
    {
        public StandartNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}