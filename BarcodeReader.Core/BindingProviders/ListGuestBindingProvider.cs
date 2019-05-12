using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Core.BindingProviders
{
    public class ListGuestBindingProvider : BindingProvider
    {
        #region Constructors

        public ListGuestBindingProvider()
        {

            ItemBindingDescription itemBinding = new ItemBindingDescription();
            //{
            //    ImagePlaceholder = "orang.jpg"
            //};

            itemBinding.AddBinding("NameLabel", BindableProperties.TextProperty, "Name");
            itemBinding.AddBinding("TableNumberLabel", BindableProperties.TextProperty, "TableNumber");
            itemBinding.AddBinding("TableTypeLabel", BindableProperties.TextProperty, "TableType");


            itemBinding.AddBinding("NumberLabel", BindableProperties.TextProperty, "NumberLabel");




            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.SelectedItemsProperty, "SelectedItems", BindingMode.TwoWay);
            
            this.AddBinding("BtnEmail", BindableProperties.CommandProperty, "EmailCommand");
            this.AddBinding("BtnClearData", BindableProperties.CommandProperty, "BtnClearDataCommand");
            
        }
    }

    #endregion
}
