using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using System;

namespace BarcodeReader.Core.Models
{
   public class Security : ModelBase
    {
        #region Fields

        private Guid _securityId;
        private string _pinNumber;

        #endregion

        #region Properties

        [PrimaryKey]
        public Guid SecurityId
        {
            get { return _securityId; }
            set
            {
                if (_securityId != value)
                {
                    _securityId = value;
                    this.OnPropertyChanged("SecurityId");
                }
            }
        }

        public string PinNumber
        {
            get { return _pinNumber; }
            set
            {
                if (_pinNumber != value)
                {
                    _pinNumber = value;
                    this.OnPropertyChanged("PinNumber");
                }
            }
        }
       

        #endregion

    }
}
