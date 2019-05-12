using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.Services.Connectivity.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeReader.Core.ViewModels
{
    public class PeripheralDeviceViewModel : DbModel<Object>, IPeripheralListener
    {
        #region construct
        public PeripheralDeviceViewModel()
        {
            this.ScanBluetoothCommand = new DelegateCommand(ExecuteCreate);
        }
        #endregion

        #region properties
        public ScannerBluetoothRepository scannerRepo = new ScannerBluetoothRepository();
        public DelegateCommand ScanBluetoothCommand { get; set; }
        public IBarcodeScannerService BarcodeScannerService
        {
            get { return ServiceProvider.GetService<IBarcodeScannerService>(); }
        }
        public ISocketService SocketService
        {
            get { return ServiceProvider.GetService<ISocketService>(); }
        }
        #endregion

        #region methods
        private void ExecuteCreate(object parameter)
        {
            this.DialogPresenter.Show<FindBarcodeScannerViewModel>(new DialogOptions(""), async (dialogResult) =>
            {
                FindBarcodeScannerViewModel viewModel = ((FindBarcodeScannerViewModel)dialogResult.ViewModel);
                string button = dialogResult.Button.ToString();
                if (button == "Positive")
                {
                    if (viewModel.SelectedItem != null)
                    {
                        PeripheralDevice device = viewModel.SelectedItem.GetDevice();

                       bool check = await this.BarcodeScannerService.ConnectAsync(device, false);
                        if (check == true)
                        {
                            this.ToastPresenter.Show("Bluetooth scanner connected");
                        }
                        else
                        {
                            this.ToastPresenter.Show("Bluetooth scanner not connected");
                        }

                        
                        IList<ScannerBluetooth> generalsetting = await scannerRepo.GetAllAsync();

                        if (generalsetting.Count == 0)
                        {
                            ScannerBluetooth setting = new ScannerBluetooth();
                            setting.Name = "scanner";
                            setting.SettingsId = Guid.NewGuid();
                            setting.Data = SimpleJson.SerializeObject(viewModel.SelectedItem);
                            await scannerRepo.InsertAsync(setting);
                        }

                        else
                        {
                            foreach (var settingss in generalsetting)
                            {
                                ScannerBluetooth settings = new ScannerBluetooth();
                                settings.SettingsId = settingss.SettingsId;
                                settings.Name = settingss.Name;
                                settings.Data = SimpleJson.SerializeObject(viewModel.SelectedItem);
                                await scannerRepo.UpdateAsync(settings);
                            }
                        }
                        
                    }
                }
            });
        }

        public override void Navigated(NavigatedParameter parameter)
        {

            base.Navigated(parameter);
            this.SocketService.AddListener(this);
        }

        public void removelistener()
        {
            this.SocketService.RemoveListener(this);
        }

      

        public void OnConnected(PeripheralDevice device)
        {
        }

        public void OnConnecting(PeripheralDevice device)
        {
        }

        public void OnDisconnected(PeripheralDevice device)
        {
             this.BarcodeScannerService.DisconnectAsync(device);
        }

        public void OnMessageReceived(PeripheralDevice device, string message)
        {
        }
        #endregion
    }
}
