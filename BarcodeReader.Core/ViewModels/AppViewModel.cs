using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.Services.Connectivity.Peripheral;
using Intersoft.Crosslight.ViewModels;

namespace BarcodeReader.Core.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        #region Properties
        public PeripheralDevice BarcodeScannerDevice { get; set; }
        
        public IBarcodeScannerService BarcodeScannerService
        {
            get { return ServiceProvider.GetService<IBarcodeScannerService>(); }
        }

        #endregion

        #region Method
        public async void ConnectAsync(ViewModelBase owner = null, bool showConnectedToast = true)
        {
            if (this.BarcodeScannerDevice == null)
            {
                ScannerBluetoothRepository ScannerBluetoothRepository = new ScannerBluetoothRepository();
                ScannerBluetooth scannerBluetooth  = await ScannerBluetoothRepository.GetSingleAsync();

                if (scannerBluetooth != null)
                {
                    this.BarcodeScannerDevice = SimpleJson.DeserializeObject<Peripheral>(scannerBluetooth.Data).GetDevice();
                }
            }
            
            if (this.BarcodeScannerDevice != null)
            {
                bool isConnected = await this.BarcodeScannerService.ConnectAsync(this.BarcodeScannerDevice, false);

                if (owner != null)
                {
                    if (isConnected == true)
                    {
                        if (showConnectedToast)
                            owner.ToastPresenter.Show("Bletooth Scanner Connected");
                    }
                    else
                        owner.ToastPresenter.Show("Bletooth Scanner Not connected");
                }
            }
        }
        #endregion
    }
}
