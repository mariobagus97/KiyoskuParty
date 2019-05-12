using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;

namespace BarcodeReader.iOS
{
    [ImportBinding(typeof(SimpleBindingProvider))]
    [RegisterNavigation(DeviceKind.Phone)]
    public partial class MainViewController : UIViewController<SimpleViewModel>
    {
        #region Constructors

        public MainViewController()
            : base("MainViewController", null)
        {
        }

        #endregion

        #region Properties

        public override bool HideKeyboardOnTap
        {
            get { return true; }
        }

        #endregion
    }
}