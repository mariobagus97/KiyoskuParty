using Intersoft.Crosslight.Data.ComponentModel;
using System;

namespace BarcodeReader.Core.Models
{
    public class ScannerBluetooth : ModelBase
    {
        #region Fields

        private string _data;
        private string _name;
        private Guid _settingsId;

        #endregion

        #region Properties

        [PrimaryKey]
        public Guid SettingsId
        {
            get { return _settingsId; }
            set
            {
                if (_settingsId != value)
                {
                    _settingsId = value;
                    this.OnPropertyChanged("Settings");
                }
            }
        }

        public string Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        #endregion
    }
}
