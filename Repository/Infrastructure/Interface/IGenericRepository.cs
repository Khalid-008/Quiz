namespace Quiz.Repository.Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
    }
}
