namespace BIMWebService.Job
{
    public abstract class BaseJob<T> where T : new()
    {
        public void Dispose()
        {
        }

        public abstract string Create(T data);
        public abstract string Load(T data);
        public abstract string Remove(T data);
        public abstract string Update(T data);
    }
}