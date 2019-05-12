using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Containers;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeReader.Infrastructure
{
    public sealed class CrosslightAppAppService : ApplicationServiceBase
    {
        #region Constructors

        public CrosslightAppAppService(IApplicationContext context)
            : base(context)
        {
        }

        #endregion

        #region Methods

        protected override void OnStart(StartParameter parameter)
        {
            base.OnStart(parameter);

            this.Initialize();
            this.InitializeAppSettings();
            this.InitializeSqliteDb();
            this.InitializeRepositories();
            this.LoadSettings();
            
            this.SetRootViewModel<MainViewModel>();
        }

        private void Initialize()
        {
            AppViewModel appViewModel = new AppViewModel();
            Container.Current.RegisterInstance(appViewModel);
        }

        private void InitializeAppSettings()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.DatabaseName = "selfparty.db3";
            
            Container.Current.RegisterInstance(appSettings);
        }

        private void InitializeRepositories()
        {
            Container.Current.Register<ISecurityRepository, SecurityRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<IGuestRepository, GuestRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<IScannerBluetoothRepository, ScannerBluetoothRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<ISettingsRepository, SettingsRepository>().WithLifetimeManager(new ContainerLifetime());
            
        }

        private void InitializeSqliteDb()
        {
            Type[] types = new Type[] { typeof(Guest), typeof(Settings), typeof(ScannerBluetooth), typeof(Security) };
            this.InitializeSqliteDb(types);
        }

        private void InitializeSqliteDb(Type[] types)
        {
            string dbName = "selfparty.db3";

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();

            ISQLiteConnection db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

            foreach (Type type in types)
            {
                if (!db.TableExists(type))
                    db.CreateTable(type);
                else
                    db.MigrateTable(type);
            }

            if (db.Table<Security>().ToList().Count == 0)
            {
                List<Security> security = new List<Security>();
                security.Add(new Security() { SecurityId = Guid.NewGuid(), PinNumber = "6666" });
                db.InsertAll(security);
            }
        }

        private async void LoadSettings()
        {
            SettingsRepository settingsRepository = new SettingsRepository();
            Settings settings = await settingsRepository.GetSingleAsync();
            
            if (settings == null)
            {
                settings = new Settings
                {
                    SettingsId = Guid.NewGuid(),
                    Name = "GeneralSettings"
                };

                GeneralSettings general = new GeneralSettings();
                string json = SimpleJson.SerializeObject(general);
                settings.Data = json;

                await settingsRepository.InsertAsync(settings);
            }

            GeneralSettings generalSettings = SimpleJson.DeserializeObject<GeneralSettings>(settings.Data);
            generalSettings.ConvertToByte();

            Container.Current.RegisterInstance(generalSettings);
        }
        
        #endregion
    }
}