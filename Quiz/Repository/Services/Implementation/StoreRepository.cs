using Quiz.Data;
using Quiz.Models;
using Quiz.Repository.Infrastructure.Implementation;
using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.Services.Implementation
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
