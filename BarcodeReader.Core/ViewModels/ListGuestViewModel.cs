using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices;
using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BarcodeReader.Core.ViewModels
{
    public class ListGuestViewModel : ListViewModelBase<Guest>
    {
        #region construct
        public ListGuestViewModel()
        {
            string dbName = "selfparty.db3";

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();

            this.Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));


            this.EmailCommand = new DelegateCommand(ExecuteSendEmail);
            this.BtnClearDataCommand = new DelegateCommand(ExecuteClearData);

             this.StorageService = ServiceProvider.GetService<ILocalStorageService>();
        }
        #endregion

        #region fields

        private string _numberLabel;
        private int count = 0;

        #endregion

        #region properties

        public ILocalStorageService StorageService { get; set; }

        public IGuestRepository GuestRepository
        {
            get { return Container.Current.Resolve<IGuestRepository>(); }
        }

        public string NumberLabel
        {
            get { return _numberLabel; }
            set
            {
                if (_numberLabel != value)
                {
                    _numberLabel = value;
                    this.OnPropertyChanged("NumberLabel");
                }
            }
        }
        public DelegateCommand EmailCommand { get; set; }
        public DelegateCommand BtnClearDataCommand { get; set; }

        protected ISQLiteAsyncConnection Db { get; set; }
        #endregion


        #region methods

        public override async void Navigated(NavigatedParameter parameter)
        {
            int number = 0;
            base.Navigated(parameter);
            
            List<Guest> client2 = new List<Guest>();
            IList<Guest> client = await GuestRepository.GetAllAsync(); 
            
            foreach (var example in client)
            {
                number++;
                example.NumberLabel = number.ToString();
                client2.Add(example);
            }
            this.Items = client2;
        }
        

        public async void ExecuteClearData (object parameter)
        {
            count++;
            if (count == 3)
            {
                IList<Guest> guest = await GuestRepository.GetAllAsync();
                if (guest.Count != 0)
                { 
                    string[] actions = new string[]
            {
            "No",
            "Yes"
            };
                this.MessagePresenter.Show("Data deleted cannot be returned, sure?", "Confirmation", actions, (resultIndex) =>
                {
                    string response = actions[resultIndex].ToString();
                    if (response == "Yes")
                    {
                        Db.ClearTableAsync<Guest>();
                        this.Items = new List<Guest>();

                        if (CheckFileCsv())
                             this.StorageService.DeleteFileAsync("selfpartys.csv", LocalFolderKind.Data);

                        this.ToastPresenter.Show("All data has been deleted", null, null, ToastDisplayDuration.Immediate, ToastGravity.Bottom);
                    }
                });
            }
                else
                {
                    this.ToastPresenter.Show("No more data can be deleted");
                }
                count = 0;
            }
        }
        
        public async void ExecuteSendEmail(object parameter)
        {
            try
            {
                count++;
                if (count == 3)
                {
                    IList<Guest> guest = await GuestRepository.GetAllAsync();
                    if (guest.Count != 0)
                    {
                        if (CheckFileCsv())
                            await this.StorageService.DeleteFileAsync("selfpartys.csv", LocalFolderKind.Data);
                        
                        await this.StorageService.WriteTextFileAsync("Name,TableType,TableNumber,FirstScan,LastScan\n", "selfpartys.csv", LocalFolderKind.Data, FileWriteMode.Append);

                        if (this.StorageService != null)
                        {
                            string csv;
                            foreach (var loop in guest)
                            {
                                string[] splitData = loop.TableNumber.Split(new string[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);
                                loop.TableNumber = splitData[0];

                                csv = loop.Name + "," + loop.TableType + "," + loop.TableNumber + "," + loop.FirstScan + "," + loop.LastScan + "\n";

                                await this.StorageService.WriteTextFileAsync(csv, "selfpartys.csv", LocalFolderKind.Data, FileWriteMode.Append);
                            }
                            byte[] datas = await this.StorageService.ReadFileAsync("selfpartys.csv", LocalFolderKind.Data);

                            ObservableCollection<MailAttachment> mailAttachments = new ObservableCollection<MailAttachment>();
                            mailAttachments.Add(new MailAttachment("selfpartys.csv", "text/plain", datas));
                            string body = "result";

                            MailMessage mailMessage = new MailMessage("EmailTarget@Email.com", "Log Backup", body, true, mailAttachments);
                            this.MobileService.Mail.ComposeMail(mailMessage, null);
                        }
                        
                    }
                    else
                    {
                        this.ToastPresenter.Show("Request fail, because data is empty");
                    }
                    count = 0;
                }
            }
            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
            
        }

        public bool CheckFileCsv()
        {
            bool check = this.StorageService.IsFileExisted("selfpartys.csv", LocalFolderKind.Data);
            return check;
        }
        
        #endregion

    }
}
