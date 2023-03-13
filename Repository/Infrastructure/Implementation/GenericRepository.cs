using Quiz.Data;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Repository.Infrastructure.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
