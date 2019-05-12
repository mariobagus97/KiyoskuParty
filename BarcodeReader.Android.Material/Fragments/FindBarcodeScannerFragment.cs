using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using BarcodeReader.Core.BindingProviders;
using BarcodeReader.Core.ViewModels;

namespace BarcodeReader.Android.Fragments
{
    [ImportBinding(typeof(FindBarcodeScannerBindingProvider))]
    public class FindBarcodeScannerFragment : RecyclerViewFragment<FindBarcodeScannerViewModel>
    {
        #region Constructors

        public FindBarcodeScannerFragment()
        {
        }

        public FindBarcodeScannerFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ItemLayoutId
        {
            get { return Resource.Layout.find_hardware_item_layout; }
        }

        protected override bool ShowActionBarUpButton
        {
            get { return true; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            //this.InteractionMode = ListViewInteraction.Navigation;
            this.CellStyle = CellStyle.RightDetail;
            this.ShowSeparator = true;

            this.InteractionMode = ListViewInteraction.ChoiceInput;
            this.ChoiceInputMode = ChoiceInputMode.Single;
            
        }

        #endregion
    }
}
