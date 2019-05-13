using BarcodeReader.Core.ModelServices.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarcodeReader.Core.ModelServices
{
    public class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        #region Constructors
        
        public RepositoryBase() : this("selfparty.db3")
        {
        }

        public RepositoryBase(string dbName)
        {
            this.Db = this.CreateConnection(dbName);
        }

        #endregion

        #region Properties

        public ISQLiteAsyncConnection Db { get; private set; }

        #endregion

        public virtual ISQLiteAsyncConnection CreateConnection(string dbName)
        {
            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            Func<string, ISQLiteAsyncConnection> factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();
            ISQLiteAsyncConnection db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

            return db;
        }

        public virtual Task<int> DeleteAsync(T entity)
        {
            return this.Db.DeleteAsync(entity);
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            IList<T> items = await this.Db.Table<T>().ToListAsync();
            return items.ToObservable();
        }

        public virtual async Task<T> GetSingleAsync()
        {
            T items = await this.Db.Table<T>().FirstOrDefaultAsync();
            return items;
        }

        public virtual async Task<IList<T>> GetQuery(QueryDescriptor query)
        {
            IList<T> items = await this.Db.Table<T>().Parse(query).ToListAsync();

            return items.ToObservable();
        }

        public virtual Task<int> InsertAsync(T entity)
        {
            return this.Db.InsertAsync(entity);
        }

        public virtual Task<int> UpdateAsync(T entity)
        {
            return this.Db.UpdateAsync(entity);
        }

        //public async void ClearTableAsync(T entity)
        //{
        //   await this.Db.ClearTableAsync<entity>();


        //  //  Db.ClearTableAsync<Guest>();
        //}

        //public virtual Task<int> ClearTableAsync(T entity)
        //{
        //    T a = new T();
        //    return this.Db.ClearTableAsync<T>();
        //}
    }
}