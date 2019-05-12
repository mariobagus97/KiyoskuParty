using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using System;

namespace BarcodeReader.Core.Models
{
    [Serializable]
    public class Guest : ModelBase
    {
        #region Fields

        private Guid _guestId;
        private string _nameText;
        private string _tableNumber;
        private string _tableType;
        private string _firstScan;
        private string _lastScan;
        private string _numberLabel;

        #endregion

        #region Properties

        [PrimaryKey]
        public Guid GuestId
        {
            get { return _guestId; }
            set
            {
                if (_guestId != value)
                {
                    _guestId = value;
                    this.OnPropertyChanged("GuestId");
                }
            }
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

        

        public string FirstScan
        {
            get { return _firstScan; }
            set
            {
                if (_firstScan != value)
                {
                    _firstScan = value;
                    this.OnPropertyChanged("FirstScan");
                }
            }
        }
        public string Name
        {
            get { return _nameText; }
            set
            {
                if (_nameText != value)
                {
                    _nameText = value;
                    this.OnPropertyChanged("NameText");
                }
            }
        }
        public string LastScan
        {
            get { return _lastScan; }
            set
            {
                if (_lastScan != value)
                {
                    _lastScan = value;
                    this.OnPropertyChanged("LastScan");
                }
            }
        }

        public string TableNumber
        {
            get { return _tableNumber; }
            set
            {
                if (_tableNumber != value)
                {
                    _tableNumber = value;
                    this.OnPropertyChanged("TableNumber");
                }
            }
        }

        public string TableType
        {
            get { return _tableType; }
            set
            {
                if (_tableType != value)
                {
                    _tableType = value;
                    this.OnPropertyChanged("TableType");
                }
            }
        }

        


        #endregion

    }
}
