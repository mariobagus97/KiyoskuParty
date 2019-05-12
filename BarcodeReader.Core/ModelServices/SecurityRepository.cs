using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices.Infrastructure;

namespace BarcodeReader.Core.ModelServices
{
    public interface ISecurityRepository : IRepository<Security>
    {
    }

    public class SecurityRepository : RepositoryBase<Security>, ISecurityRepository
    {
    }
}
