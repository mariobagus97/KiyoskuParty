using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using BarcodeReader.Core.ViewModels;
using BarcodeReader.Core.BindingProviders;

namespace BarcodeReader.Android.Fragments
{
    [ImportBinding(typeof(ValidationBindingProvider))]
    public class ValidationFragment : Fragment<ValidationViewModel> 
    {
        #region Constructors

        public ValidationFragment()
        {
        }

        public ValidationFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties


        protected override int ContentLayoutId
        {
            get { return Resource.Layout.Validation; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.ToolbarSettings.IsVisible = false;
        }
        #endregion
    }
}