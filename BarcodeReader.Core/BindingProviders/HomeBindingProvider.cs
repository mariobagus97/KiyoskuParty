using Intersoft.Crosslight;

namespace BarcodeReader
{
    public class ScanQrBindingProvider : BindingProvider
    {
        #region Constructors

        public ScanQrBindingProvider()
        {
            this.AddBinding("SearchText", BindableProperties.TextProperty, new BindingDescription("Name", BindingMode.TwoWay, UpdateSourceTrigger.PropertyChanged));
            this.AddBinding("BtnBack", BindableProperties.CommandProperty, "BackCommand");
            this.AddBinding("BackgroundImage", BindableProperties.ImageSourceProperty, "BackgroundImage");
        }

        #endregion
    }
}