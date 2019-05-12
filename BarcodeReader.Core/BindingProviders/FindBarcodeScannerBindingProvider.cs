using System;
using Intersoft.Crosslight;

namespace BarcodeReader.Core.BindingProviders
{
    public class FindBarcodeScannerBindingProvider : BindingProvider
    {
        #region Constructors

        public FindBarcodeScannerBindingProvider()
        {
            ItemBindingDescription itemBinding = new ItemBindingDescription
            {
                DisplayMemberPath = "Name",
                DetailMemberPath = "Address"
            };

            itemBinding.AddBinding("HardwareIcon", BindableProperties.ImageSourceProperty, "Icon");
            itemBinding.AddBinding("HardwareNameLabel", BindableProperties.TextProperty, "Name");
            itemBinding.AddBinding("HardwareDescriptionLabel", BindableProperties.TextProperty, "Address");

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedCommandProperty, "SelectedCommand", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);

            this.AddBinding("HardwareTypeLabel", BindableProperties.TextProperty, "AddDeviceText");
            this.AddBinding("LoadingView", BindableProperties.IsVisibleProperty, "IsLoading");
            this.AddBinding("AddCustomHardwareButton", BindableProperties.CommandProperty, "AddCustomHardwareCommand");
        }

        #endregion
    }
}
