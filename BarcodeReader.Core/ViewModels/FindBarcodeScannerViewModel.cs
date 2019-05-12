using BarcodeReader.Core.Models;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BarcodeReader.Core.ViewModels
{
    public class FindBarcodeScannerViewModel : ListViewModelBase<Peripheral>, IBluetoothDiscoveryListener
    {
        #region fields
        private bool _isLoading;

        #endregion

        #region properties

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        public IBluetoothService BluetoothService
        {
            get { return ServiceProvider.GetService<IBluetoothService>(); }
        }

        public Peripheral SelectedPeripheral { get; set; }
        #endregion
        
        #region methods
        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            this.LoadDataCore();
        }
        

        protected override void ExecuteSelect(object parameter)
        {
            base.ExecuteSelect(parameter);

            this.SelectedPeripheral = parameter as Peripheral;
            this.NavigationService.Close();
        }

        private async void LoadDataCore()
        {
            this.IsLoading = true;

            IEnumerable<Peripheral> items = await this.LoadDataAsync();
            this.Items = items;

            this.OnDataLoaded(items);
        }

        protected virtual void OnDataLoaded(IEnumerable<Peripheral> items)
        {
            this.IsLoading = false;
        }

        protected internal Peripheral CreatePeripheral(PeripheralDevice device, string peripheralType)
        {
            Peripheral peripheral = this.CreatePeripheral(peripheralType, InterfaceType.Bluetooth);
            peripheral.Name = device.Name;
            peripheral.Address = device.Address;
            peripheral.PropertiesModel = new PeripheralProperties
            {
                Uuid = BluetoothServiceUuid.SPP,
                HardwareAddress = device.HardwareAddress
            };

            return peripheral;
        }

        protected internal virtual Peripheral CreatePeripheral(string peripheralType, string interfaceType)
        {
            Peripheral peripheral = new Peripheral
            {
                PeripheralId = Guid.NewGuid(),
                Type = peripheralType,
                InterfaceType = interfaceType,
                CreatedBy = "natan",
                CreatedDate = DateTime.Now,
                ModifiedBy = "natan",
                ModifiedDate = DateTime.Now
            };

            return peripheral;
        }

        protected virtual void AddPeripheral(Peripheral peripheral)
        {
            try
            {
                IList list = this.Items as IList;
                if (list != null)
                    list.Add(peripheral);
            }
            catch { } // try catch to ignore multithread issue where the dialog already closed.
        }

        protected async Task<IEnumerable<Peripheral>> LoadDataAsync()
        {
            if (this.BluetoothService != null)
                this.BluetoothService.StartDiscovery(BluetoothServiceUuid.SPP, this);

            return new ObservableCollection<Peripheral>();
        }

        public void OnDeviceFound(PeripheralDevice device)
        {
            if (!string.IsNullOrEmpty(device.Name) &&
                (device.Name.StartsWith("BarCode Scanner") || device.Name.StartsWith("Barcode Scanner") || device.Name.StartsWith("Socket CHS") || device.Name.StartsWith("BT380") || device.Name.StartsWith("BT310") || device.Name.StartsWith("BT383")))
            {
                Peripheral peripheral = this.CreatePeripheral(device, PeripheralType.BarcodeScanner);
                this.AddPeripheral(peripheral);
            }
        }

        public void OnDiscoveryFinish()
        {
        }

        public void OnDiscoveryStart()
        {
        }
        #endregion
    }
}
