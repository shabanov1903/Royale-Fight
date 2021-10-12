public interface ITransaction<T>
{
    public bool Execute(T obj, string PriceType);
}