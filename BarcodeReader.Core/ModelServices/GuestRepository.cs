using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices.Infrastructure;

namespace BarcodeReader.Core.ModelServices
{
    public interface IGuestRepository : IRepository<Guest>
    {
    }

    public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
    }
}
