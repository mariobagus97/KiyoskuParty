using Intersoft.Crosslight;

namespace BarcodeReader.Core.BindingProviders
{
    public class SettingsBindingProvider : BindingProvider
    {
        #region Constructors

        public SettingsBindingProvider()
        {
            ItemBindingDescription itemBinding = new ItemBindingDescription()
            {
                DisplayMemberPath = "Title",
                NavigateMemberPath = "Target"
            };

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
        }

        #endregion
    }
}