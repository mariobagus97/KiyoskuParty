using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Services.Barcode.WinPhone;

namespace BarcodeReader.WinPhone
{
    [ViewModelType(typeof(SimpleViewModel))]
    public partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            scanner = new MobileBarcodeScanner(this.Dispatcher);
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        #endregion

        #region Fields

        MobileBarcodeScanner scanner;

        #endregion
    }
}