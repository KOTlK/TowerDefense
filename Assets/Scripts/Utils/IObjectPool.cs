namespace Utils
{
    public interface IObjectPool<TObject>
    {
        TObject Pop();
        void Release(TObject obj);
    }
}