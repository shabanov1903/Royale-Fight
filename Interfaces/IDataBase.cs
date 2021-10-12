public interface IDataBase<T>
{
    public T GetObject(int id);
    public int GetParameter(int id, string column);
    public void SetParameter(T obj);
}