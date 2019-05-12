using BarcodeReader.Core.Models;
using Intersoft.Crosslight.ViewModels;

namespace BarcodeReader.Core.ViewModels
{
    public class ValidationViewModel : EditorViewModelBase<Security>
    {
        #region fields
        private string _pinNumber;
        #endregion

        #region properties
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
