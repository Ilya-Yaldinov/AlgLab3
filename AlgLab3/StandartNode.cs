namespace AlgLab3
{
    public abstract class StandartNode<T>
    {
        public T Data { get; set; }
        public StandartNode(T data)
        {
            Data = data;
        }
    }
}