using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        IStoreRepository StoreRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
    }
}
