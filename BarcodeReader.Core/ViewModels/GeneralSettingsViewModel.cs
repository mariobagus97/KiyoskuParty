using BarcodeReader.Core.FormMetaData;
using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using System;

namespace BarcodeReader.Core.ViewModels
{
    public class GeneralSettingsViewModel :  DbModel<GeneralSettings> 
    {
        #region Properties

        public override Type FormMetadataType
        {
            get { return typeof(GeneralSettingsFormMetadata); }
        }

        private GeneralSettings generalsetting;

        public SettingsRepository settingRepo = new SettingsRepository();

        #endregion

        #region Methods


        protected async override void ExecuteSave(object parameter)
        {
            base.ExecuteSave(parameter);



            Settings settings = Db.Table<Settings>().Where(o => o.Name == "GeneralSettings").FirstOrDefault();
            

            this.Item.ConvertToBase64String();

            settings.Data = SimpleJson.SerializeObject(this.Item);
            await settingRepo.UpdateAsync(settings);
        }
        
        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.Item = Container.Current.Resolve<GeneralSettings>();

        }
        #endregion
    }
}
