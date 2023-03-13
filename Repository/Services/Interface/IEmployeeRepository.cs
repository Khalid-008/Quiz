using Quiz.Models;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Repository.Services.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        void Delete(Employee entity);
    }
}
