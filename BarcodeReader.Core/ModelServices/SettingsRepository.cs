using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices.Infrastructure;

namespace BarcodeReader.Core.ModelServices
{
    public interface ISettingsRepository : IRepository<Settings>
    {
    }

    public class SettingsRepository : RepositoryBase<Settings>, ISettingsRepository
    {
    }
}
