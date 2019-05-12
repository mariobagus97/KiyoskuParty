using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using Intersoft.Crosslight.Input;
using System;
using System.Collections.Generic;

namespace BarcodeReader.ViewModels
{
    public class ClientDetailViewModel : DbModel<Guest>
    {
        #region Constructors

        public ClientDetailViewModel()
        {
            this.CloseCommand = new DelegateCommand(ExecuteClose);
            this.Timer = new Timer(this.CheckData, 0, 0, 1000);
            this.CountDown = 30;
            this.UpdateCountDownText();
        }

        #endregion

        #region fields

        private string _closeText;
        private string _registered;
        private byte[] _backgroundImage;

        #endregion

        #region Properties


        public GeneralSettings GeneralSettings { get; set; }

        public GuestRepository guestRepo = new GuestRepository();

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

        public int CountDown { get; set; }

        public string CloseText
        {
            get { return _closeText; }
            set
            {
                if (_closeText != value)
                {
                    _closeText = value;
                    this.OnPropertyChanged("CloseText");
                }
            }
        }
        
        public DelegateCommand CloseCommand { get; set; }

        public string Registered
        {
            get { return _registered; }
            set
            {
                if (_registered != value)
                {
                    _registered = value;
                    this.OnPropertyChanged("Registered");
                }
            }
        }

        public Timer Timer { get; set; }

        #endregion

        #region methods
        public void UpdateCountDownText()
        {
            this.CloseText = "Close (" + this.CountDown + ")";
        }



        public void CheckData(object parameter)
        {
            this.CountDown--;
            this.UpdateCountDownText();


            if (this.CountDown <= 0)
            {
                ServiceProvider.GetService<IViewService>().RunOnUIThread(() =>
                {
                    this.ExecuteClose(null);
                }, 0);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            this.Timer.Dispose();
            this.Timer = null;
        }



        public async override void Navigated(NavigatedParameter parameter)
        {
            try
            {
                base.Navigated(parameter);
                Guest guest = parameter.Data as Guest;

                QueryDescriptor query = new QueryDescriptor();
                query.FilterDescriptors.Add(new FilterDescriptor()
                { PropertyName = "Name", Operator = FilterOperator.IsEqualTo, Value = guest.Name });
                query.FilterDescriptors.Add(new FilterDescriptor()
                { PropertyName = "TableNumber", Operator = FilterOperator.IsEqualTo, Value = guest.TableNumber });
                query.FilterDescriptors.Add(new FilterDescriptor()
                { PropertyName = "TableType", Operator = FilterOperator.IsEqualTo, Value = guest.TableType });

                IList<Guest> checkdata = await guestRepo.GetQuery(query);
                
                if (checkdata.Count == 0)
                {
                    guest.FirstScan = DateTime.Now.ToString();
                    guest.LastScan = DateTime.Now.ToString();
                    await guestRepo.InsertAsync(guest);
                }
                else
                {
                    foreach (Guest AvailableUser in checkdata)
                    {
                        Registered = "You have been registered";
                        AvailableUser.LastScan = DateTime.Now.ToString();
                        await guestRepo.UpdateAsync(AvailableUser);
                    }
                }

                this.GeneralSettings = Container.Current.Resolve<GeneralSettings>();
                this.BackgroundImage = this.GeneralSettings.TableLayoutImage;

               
                    this.Item = guest;
               
            }

            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }


        private void ExecuteClose(object parameter)
        {
            this.NavigationService.Close();
            PeripheralDeviceViewModel peripheral = new PeripheralDeviceViewModel();

        }
        #endregion

    }
}
