using Quiz.Repository.Infrastructure.Interface;
using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.Infrastructure.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        UnitOfWork(IStoreRepository storeRepository, IEmployeeRepository employeeRepository)
        {
            StoreRepository = storeRepository;
            EmployeeRepository = employeeRepository;
        }
    }
}
