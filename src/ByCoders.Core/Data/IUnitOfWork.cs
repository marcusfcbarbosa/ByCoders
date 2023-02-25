using System.Threading.Tasks;

namespace ByCoders.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
