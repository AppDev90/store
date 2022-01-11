using Store.ApplicationService.Contract;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data
{
    public class StoreUnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storeDbContext;

        public StoreUnitOfWork(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _storeDbContext.SaveChangesAsync();
        }
    }
}
