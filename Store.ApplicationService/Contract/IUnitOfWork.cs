
using System.Threading.Tasks;

namespace Store.ApplicationService.Contract
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
