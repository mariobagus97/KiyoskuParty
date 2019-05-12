using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;

namespace BarcodeReader.iOS
{
    [ImportBinding(typeof(SimpleBindingProvider))]
    [RegisterNavigation(DeviceKind.Tablet)]
    public partial class MainViewController_iPad : UIViewController<SimpleViewModel>
    {
        #region Constructors

        public MainViewController_iPad()
            : base("MainViewController_iPad", null)
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