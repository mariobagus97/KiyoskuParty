using System;
using Android.Runtime;
using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.OS;
using BarcodeReader.Core.ViewModels;

namespace BarcodeReader.Android.Fragments
{

    [ImportBinding(typeof(Core.BindingProviders.PeripheralDeviceBindingProvider))]
    public class PeripheralDeviceFragment : Intersoft.Crosslight.Android.v7.Fragment<PeripheralDeviceViewModel>
    {
        #region Constructors

        public PeripheralDeviceFragment()
            : base()
        {
        }

        public PeripheralDeviceFragment(IntPtr javaReference, JniHandleOwnership transfer)
                : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.PeripheralDevice; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.ToolbarSettings.IsVisible = false;

        }

        public override void OnStop()
        {

            this.ViewModel.removelistener();
            base.OnStop();
        }


        #endregion
    }
}
