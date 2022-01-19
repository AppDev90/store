

namespace Store.Infrastructure.Data.Common
{
    public abstract class BaseStoreRepository
    {
        protected readonly StoreDbContext StoreDbContext;

        public BaseStoreRepository(StoreDbContext storeDbContext)
        {
            StoreDbContext = storeDbContext;
        }
    }
}
