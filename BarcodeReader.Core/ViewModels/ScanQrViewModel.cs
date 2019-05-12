using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Services.Connectivity;
using Intersoft.Crosslight.Services.Connectivity.Peripheral;
using Intersoft.Crosslight.ViewModels;
using System;

namespace BarcodeReader.ViewModels
{
    public  class ScanQrViewModel :  DetailViewModelBase<Guest>, IPeripheralListener 
    {
        #region Constructors

        public ScanQrViewModel()
        {
            this.Timer = new Timer(this.OnTimer, 0, 0, 4000);
            this.BackCommand = new DelegateCommand(ExecuteBack);
            this.CountDown = 0;
        }
        #endregion
        
        #region Fields

        private byte[] _backgroundImage;

        #endregion

        #region Properties

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public Timer Timer { get; set; }

        public ScannerBluetoothRepository BarcodeRepository { get; set; }

        public DelegateCommand BackCommand { get; set; }

        public int CountDown { get; set; }
       
        public IBarcodeScannerService BarcodeScannerService
        {
            get { return ServiceProvider.GetService<IBarcodeScannerService>(); }
        }
        public ISocketService SocketService
        {
            get { return ServiceProvider.GetService<ISocketService>(); }
        }
        
        public GeneralSettings GeneralSettings { get; set; }
        
        public byte[] BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                if (_backgroundImage != value)
                {
                    _backgroundImage = value;
                    this.OnPropertyChanged("BackgroundImage");
                }
            }
        }

       

        #endregion

        #region Methods

        public  void ShowPresenter(string message)
        {
            try
            {
                Guest clientdata = new Guest();
                string[] splitData = message.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                
                clientdata.GuestId = Guid.NewGuid();
                clientdata.Name = splitData[0];
                clientdata.TableType = splitData[1];
                if (splitData[2] != string.Empty )
                {
                    clientdata.TableNumber = splitData[2];
                    if (clientdata.TableNumber == "\r")
                    {
                        throw new Exception("QR code is wrong");
                    }
                }
                else
                {
                    throw new Exception("QR code is wrong");
                }

                this.NavigationService.Navigate<ClientDetailViewModel>(new NavigationParameter() { Data = clientdata });
            }
            catch
            {
                this.ToastPresenter.Show("QR code is wrong");
            }
        }

        private void ExecuteBack(object parameter)
        {
            this.NavigationService.Close();

        }

        public void OnTimer(object parameter)
        {
            this.AppViewModel.ConnectAsync(this, false);
         }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            this.Timer.Dispose();
            this.Timer = null;
        }

        public void AddListener()
        {
            this.SocketService.AddListener(this);
        }

        public void Removelistener()
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
            this.ShowPresenter(message);
        }

        public override void Navigated(NavigatedParameter parameter)
        {
            try
            {
                base.Navigated(parameter);
                this.Item = parameter.Data as Guest;
            }

            catch (Exception)
            {
                this.MessagePresenter.Show("belum bisa create");
            }

            this.GeneralSettings = Container.Current.Resolve<GeneralSettings>();
            this.BackgroundImage = this.GeneralSettings.ScanQrCodeBackgroundImage;
        }
        #endregion
    }
}