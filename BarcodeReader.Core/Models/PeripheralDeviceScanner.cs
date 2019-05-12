using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.ComponentModel;
using System;

namespace BarcodeReader.Core.Models
{
    [Serializable]
    public class PeripheralDeviceScanner : ModelBase
    {
        #region Fields

        private Guid _peripheralId;
        private string _hardwareAddress;
        private string _peripheralName;

        #endregion

        #region Properties

        [PrimaryKey]
        public Guid PeripheralId
        {
            get { return _peripheralId; }
            set
            {
                if (_peripheralId != value)
                {
                    _peripheralId = value;
                    this.OnPropertyChanged("PeripheralId");
                }
            }
        }

        public string HardwareAddress
        {
            get { return _hardwareAddress; }
            set
            {
                if (_hardwareAddress != value)
                {
                    _hardwareAddress = value;
                    this.OnPropertyChanged("HardwareAddress");
                }
            }
        }

        public string PeripheralName
        {
            get { return _peripheralName; }
            set
            {
                if (_peripheralName != value)
                {
                    _peripheralName = value;
                    this.OnPropertyChanged("PeripheralName");
                }
            }
        }



        #endregion

    }
}
