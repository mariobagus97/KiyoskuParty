using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Core.BindingProviders
{
    public class ClientDetailBindingProvider : BindingProvider
    {
        #region Constructors

        public ClientDetailBindingProvider()
        {
            
            this.AddBinding("LblRegistered", BindableProperties.TextProperty, "Registered", BindingMode.TwoWay);
            this.AddBinding("NameLabel", BindableProperties.TextProperty, "Item.Name", BindingMode.TwoWay);
            this.AddBinding("TableNumberLabel", BindableProperties.TextProperty, "Item.TableNumber", BindingMode.TwoWay);
            this.AddBinding("TableTypeLabel", BindableProperties.TextProperty, "Item.TableType", BindingMode.TwoWay);
            this.AddBinding("BtnClose", BindableProperties.CommandProperty, "CloseCommand");
            this.AddBinding("BtnClose", BindableProperties.TextProperty, "CloseText");

            this.AddBinding("BackgroundImage", BindableProperties.ImageSourceProperty, "BackgroundImage");

        }

        #endregion

    }
}
