using Intersoft.Crosslight;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.Services.Connectivity.Peripheral;
using Intersoft.Crosslight.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeReader.Core.ViewModels
{
    public class SettingsViewModel : ListViewModelBase<NavigationItem> 
    {
        #region Constructors

        public SettingsViewModel()
        {
            this.Title = "Settings";

            List<NavigationItem> items = new List<NavigationItem>();
            
            items.Add(new NavigationItem("General Settings", typeof(GeneralSettingsViewModel)));
            items.Add(new NavigationItem("Hardware List", typeof(PeripheralDeviceViewModel)));
            items.Add(new NavigationItem("Guest List", typeof(ListGuestViewModel)));

            this.SourceItems = items;
            this.RefreshGroupItems();
        }

        #endregion

        #region Methods

        public override void RefreshGroupItems()
        {
            if (this.Items != null)
                this.GroupItems = this.Items.GroupBy(o => o.Group).Select(o => new GroupItem<NavigationItem>(o)).ToList();
        }
        
        #endregion
    }
}