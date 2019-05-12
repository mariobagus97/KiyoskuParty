using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using System;

namespace BarcodeReader.ViewModels
{
    public class MainViewModel : DetailViewModelBase<Guest>
    {
        #region Constructors

        public MainViewModel()
        {
            this.NavigateToScanQrCodeCommand = new DelegateCommand(ExecuteNavigateToScanQrCode);
            this.ShowSettingsCommand = new DelegateCommand(ExecuteShowSettings);
        }

        #endregion

        #region Fields

        private byte[] _mainBackgroundImage;

        #endregion

        #region Properties

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public GeneralSettings GeneralSettings { get; set; }

        public byte[] MainBackgroundImage
        {
            get { return _mainBackgroundImage; }
            set
            {
                if (_mainBackgroundImage != value)
                {
                    _mainBackgroundImage = value;
                    this.OnPropertyChanged("MainBackgroundImage");
                }
            }
        }

        public DelegateCommand NavigateToScanQrCodeCommand { get; set; }

        public ISecurityRepository SecurityRepository
        {
            get { return Container.Current.Resolve<ISecurityRepository>(); }
        }

        public DelegateCommand ShowSettingsCommand { get; set; }

        #endregion

        #region Methods

        public void ExecuteNavigateToScanQrCode(object parameter)
        {
            this.NavigationService.Navigate<ScanQrViewModel>(new NavigationParameter());
        }

        public async void ExecuteShowSettings(object parameter)
        {
            try
            {
                Security security = await this.SecurityRepository.GetSingleAsync();

                this.DialogPresenter.Show<ValidationViewModel>(
                               new DialogOptions()
                               {

                                   Title = "Input Pin Number",
                                   Buttons = (DialogButton.Negative | DialogButton.Positive),
                                   NegativeButtonText = "Cancel",
                                   PositiveButtonText = "Login",

                               }, (dialogResult) =>
                               {
                                   var viewModel = ((ValidationViewModel)dialogResult.ViewModel);

                                   string button = dialogResult.Button.ToString();

                                   if (button == "Positive")
                                   {
                                       if (!string.IsNullOrEmpty(viewModel.PinNumber))
                                       {
                                           if (security.PinNumber == viewModel.PinNumber)
                                           {
                                               ServiceProvider.GetService<IViewService>().RunOnUIThread(() =>
                                               {
                                                   this.NavigationService.Navigate<SettingsViewModel>(new NavigationParameter());
                                                   this.ToastPresenter.Show("Login Success");
                                               }, 1000);
                                           }
                                           else
                                           {
                                               this.ToastPresenter.Show("Wrong pin");
                                           }
                                       }
                                       else
                                       {
                                           this.ToastPresenter.Show("Please enter the pin");
                                       }
                                   }
                               });

            }
            catch (Exception ex)
            {
                this.ToastPresenter.Show(ex.Message);
            }

        }

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.GeneralSettings = Container.Current.Resolve<GeneralSettings>();
            this.MainBackgroundImage = this.GeneralSettings.MainBackgroundImage;

            this.AppViewModel.ConnectAsync(this);
        }

        #endregion
    }
}