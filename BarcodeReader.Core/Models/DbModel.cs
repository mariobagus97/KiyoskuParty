using Intersoft.Crosslight.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using BarcodeReader.Core.Models;
using System;
using System.Linq;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.Data.SQLite;
using System.Collections.Generic;
using BarcodeReader.Infrastructure;
using System.Text;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.Services.Connectivity.Peripheral;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.Core.ModelServices;

namespace BarcodeReader.Core.Models
{
   public class DbModel<T> : EditorViewModelBase<T> where T : class
    {
        public DbModel()
        {
            string dbName = "selfparty.db3";

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();

            this.Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

        }

        protected ISQLiteConnection Db
        {
            get; set;
        }
        
    }
}
