
using Intersoft.Crosslight.Data.SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BarcodeReader.Core.ModelServices.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        ISQLiteAsyncConnection CreateConnection(string dbName);

        Task<IList<T>> GetAllAsync();
        Task<T> GetSingleAsync();

        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}