using Android.Runtime;
using BarcodeReader.Core.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using System;

namespace BarcodeReader.Android.Fragments
{
    public class GeneralSettingsFragment : FormFragment<GeneralSettingsViewModel>
    {
        #region Constructors

        public GeneralSettingsFragment()
        {
        }

        public GeneralSettingsFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("SaveButton", CommandItemType.Done));
        }

        #endregion
    }
}