using Intersoft.Crosslight;

namespace BarcodeReader.Core.BindingProviders
{
    public class MainBindingProvider : BindingProvider
    {
        #region Constructors

        public MainBindingProvider()
        {
            this.AddBinding("BtnHome", BindableProperties.CommandProperty, "NavigateToScanQrCodeCommand");
            this.AddBinding("MainBackgroundImage", BindableProperties.ImageSourceProperty, "MainBackgroundImage");

            this.AddBinding("BtnList", BindableProperties.CommandProperty, "ShowSettingsCommand");
            this.AddBinding("BtnMap", BindableProperties.CommandProperty, "ShowTableLayoutCommand");

            //this.AddBinding("BackgroundImage", BindableProperties.ImageSourceProperty, "BackgroundImage");
        }

        #endregion

    }
}
