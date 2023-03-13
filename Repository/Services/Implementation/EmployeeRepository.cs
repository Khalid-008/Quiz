using Quiz.Data;
using Quiz.Models;
using Quiz.Repository.Infrastructure.Implementation;
using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.Services.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Delete(Employee entity)
        {
            context.Set<Employee>().Remove(entity);
            context.SaveChanges();
        }
    }
}
