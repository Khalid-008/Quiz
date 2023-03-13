using Quiz.Repository.Infrastructure.Interface;
using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.Infrastructure.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStoreRepository StoreRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public UnitOfWork(IStoreRepository StoreRepository, IEmployeeRepository EmployeeRepository)
        {
            this.StoreRepository = StoreRepository;
            this.EmployeeRepository = EmployeeRepository;
        }
    }
}
