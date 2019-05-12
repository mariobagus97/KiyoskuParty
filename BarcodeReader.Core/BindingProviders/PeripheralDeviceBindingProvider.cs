using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Core.BindingProviders
{
    public class PeripheralDeviceBindingProvider : BindingProvider
    {
        public PeripheralDeviceBindingProvider()
        {
            this.AddBinding("ScanBluetooth", BindableProperties.CommandProperty, "ScanBluetoothCommand");
        }
        
    }
}
